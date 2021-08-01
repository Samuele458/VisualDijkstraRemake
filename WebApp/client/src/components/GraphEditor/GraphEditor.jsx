import "./GraphEditor.scss";
import React, { useEffect, useState, useContext } from "react";

import GraphBox from "./components/GraphBox";
import Lodash from "lodash";
import axios from "axios";
import * as GraphUtils from "../../utils/graphUtils";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCloud } from "@fortawesome/free-solid-svg-icons";

import GraphsIcon from "./icons/cloud.png";
import Dialog from "../Dialog";
import AuthApi from "../../AuthApi";

const GraphEditor = () => {
  const Auth = useContext(AuthApi);

  const [currentGraph, setCurrentGraph] = useState({ nodes: [], edges: [] });
  const [currentName, setCurrentName] = useState("Untitled");
  const [alreadyUploaded, setAlreadyUploaded] = useState(false);
  const [displayGraphs, setDisplayGraphs] = useState(false);
  const [graphNames, setGraphNames] = useState([]);

  useEffect(() => {
    if (Auth.loggedUser)
      axios
        .get("/api/user")
        .then((response) => {
          console.log("Done");
          setGraphNames(response.data.Graphs);
        })
        .catch((error) => {
          console.log("ERROR LOGOUT", error);
        });
  }, [alreadyUploaded, Auth.loggedUser]);

  useEffect(() => {
    if (!Auth.loggedUser) {
      setCurrentGraph({ nodes: [], edges: [] });
      setCurrentName("Untitled");
      setAlreadyUploaded(false);
    }
  }, [Auth.loggedUser]);

  const handleGraphChange = (graph) => {
    console.log("Handling graph change...", graph);
    if (alreadyUploaded) {
      console.log("UPDATING");
      axios
        .put("/api/graph", {
          name: currentName,
          data: JSON.stringify(
            GraphUtils.sanitizeCoordinates(
              GraphUtils.decodeGraphReferences(Lodash.cloneDeep(graph))
            )
          ),
        })
        .then((response) => {
          console.log("Done");
          setAlreadyUploaded(true);
        })
        .catch((error) => {
          console.log("ERROR LOGOUT", error);
        });
    } else {
      axios
        .post("/api/graph", {
          name: currentName,
          data: JSON.stringify(
            GraphUtils.sanitizeCoordinates(
              GraphUtils.decodeGraphReferences(Lodash.cloneDeep(graph))
            )
          ),
        })
        .then((response) => {
          console.log("Done");
          setAlreadyUploaded(true);
        })
        .catch((error) => {
          console.log("ERROR LOGOUT", error);
        });
    }
  };

  const handlePathRequest = (sourceName, destName) => {
    console.log(sourceName, "-->", destName);
    axios
      .get(
        `/api/graph/solve?name=${currentName}&source=${sourceName}&dest=${destName}`
      )
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log("ERROR LOGOUT", error);
      });
  };

  const loadGraph = (name) => {
    axios
      .get(`/api/graph?Name=${name}`)
      .then((response) => {
        console.log("Done");
        setCurrentGraph(JSON.parse(response.data.Data));
        setCurrentName(name);
        setAlreadyUploaded(true);
        setDisplayGraphs(false);
      })
      .catch((error) => {
        console.log("ERROR LOGOUT", error);
      });
  };

  return (
    <>
      <div className="graph-editor-box">
        {Auth.loggedUser && (
          <div className="graph-name-box">
            <input
              type="text"
              className="graph-name-input"
              value={currentName}
              onChange={(e) => {
                if (!alreadyUploaded) setCurrentName(e.target.value);
              }}
            />
          </div>
        )}

        <div className="graph-editor">
          {Auth.loggedUser && (
            <div className="graph-sidebar">
              <FontAwesomeIcon
                icon={faCloud}
                className="btn-icon"
                alt="View saved graphs"
                onClick={() => {
                  setDisplayGraphs(true);
                }}
              />
            </div>
          )}
          <GraphBox
            graph={currentGraph}
            handleGraphChange={handleGraphChange}
            handlePathRequest={handlePathRequest}
          />
        </div>
      </div>
      {displayGraphs && (
        <Dialog
          handleClose={() => {
            setDisplayGraphs(false);
          }}
        >
          <h2 style={{ padding: "0rem 0rem 1.5rem 1.5rem" }}>Load a graph</h2>
          <div className="graph-names-box">
            {graphNames.map((name) => {
              return (
                <div
                  className="graph-name-item"
                  onClick={() => loadGraph(name)}
                >
                  <h3 className="graph-name-text">{name}</h3>
                </div>
              );
            })}
          </div>
        </Dialog>
      )}
    </>
  );
};

export default GraphEditor;
