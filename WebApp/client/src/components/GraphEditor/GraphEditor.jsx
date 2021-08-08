import "./GraphEditor.scss";
import React, { useEffect, useState, useContext } from "react";

import GraphBox from "./components/GraphBox";
import Lodash, { isBuffer } from "lodash";
import axios from "axios";
import * as GraphUtils from "../../utils/graphUtils";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCloud,
  faPencilAlt,
  faCheckCircle,
} from "@fortawesome/free-solid-svg-icons";

import Dialog from "../Dialog";
import AuthApi from "../../AuthApi";

const GraphEditor = () => {
  const Auth = useContext(AuthApi);

  const [currentGraph, setCurrentGraph] = useState({ nodes: [], edges: [] });
  const [savedGraph, setSavedGraph] = useState(null);
  const [currentName, setCurrentName] = useState("Untitled");
  const [currentId, setCurrentId] = useState(null);
  const [alreadyUploaded, setAlreadyUploaded] = useState(false);
  const [displayGraphs, setDisplayGraphs] = useState(false);
  const [graphNames, setGraphNames] = useState([]);
  const [nameUnderEdit, setNameUnderEdit] = useState(false);
  const [tempName, setTempName] = useState();

  useEffect(() => {
    if (alreadyUploaded) {
      console.log("Updating name to: ", currentName);
      axios
        .put("/api/graph", {
          id: currentId,
          name: currentName,
        })
        .then((response) => {
          reloadGraphs();
        })
        .catch((error) => {
          console.log("Error on saving graph: ", error);
        });
    }
  }, [currentName]);

  useEffect(() => {
    if (savedGraph) {
      if (alreadyUploaded) {
        axios
          .put("/api/graph", {
            id: currentId,
            data: JSON.stringify(
              GraphUtils.sanitizeCoordinates(
                GraphUtils.decodeGraphReferences(Lodash.cloneDeep(savedGraph))
              )
            ),
          })
          .then((response) => {
            setAlreadyUploaded(true);
          })
          .catch((error) => {
            console.log("Error on saving graph: ", error);
          });
      } else if (savedGraph.nodes.length > 0) {
        axios
          .post("/api/graph", {
            name: currentName,
            data: JSON.stringify(
              GraphUtils.sanitizeCoordinates(
                GraphUtils.decodeGraphReferences(Lodash.cloneDeep(savedGraph))
              )
            ),
          })
          .then((response) => {
            setCurrentId(response.data.Id);
            setAlreadyUploaded(true);
          })
          .catch((error) => {
            console.log("Error on creating graph: ", error);
          });
      }
    }
  }, [savedGraph]);

  function reloadGraphs() {
    if (Auth.loggedUser)
      axios
        .get("/api/user")
        .then((response) => {
          setGraphNames(response.data.Graphs);
        })
        .catch((error) => {
          console.log("ERROR LOGOUT", error);
        });
  }

  useEffect(() => {
    reloadGraphs();
  }, [alreadyUploaded, Auth.loggedUser]);

  useEffect(() => {
    if (!Auth.loggedUser) {
      setCurrentGraph({ nodes: [], edges: [] });
      setCurrentName("Untitled");
      setAlreadyUploaded(false);
    }
  }, [Auth.loggedUser]);

  const handleGraphChange = (graph) => {
    if (Auth.loggedUser) {
      if (
        !Lodash.isEqual(graph, savedGraph) &&
        !graph.nodes.find((n) => n.name.length === 0)
      ) {
        setSavedGraph(Lodash.cloneDeep(graph));
      }
    }
  };

  const loadGraph = (graphObj) => {
    axios
      .get(`/api/graph?Id=${graphObj.id}`)
      .then((response) => {
        setCurrentId(response.data.Id);
        setCurrentGraph(JSON.parse(response.data.Data));
        setCurrentName(graphObj.name);
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
          <div
            className={
              nameUnderEdit ? "graph-name-box shadow" : "graph-name-box"
            }
          >
            <FontAwesomeIcon
              icon={nameUnderEdit ? faCheckCircle : faPencilAlt}
              className="btn-icon"
              alt=""
              onClick={() => {
                if (!nameUnderEdit) {
                  setTempName(currentName);
                } else {
                  if (tempName.length > 0) setCurrentName(tempName);
                }

                setNameUnderEdit((previous) => !previous);
              }}
            />
            {nameUnderEdit ? (
              <input
                type="text"
                className="graph-name-input"
                value={tempName}
                onChange={(e) => {
                  if (e.target.value.match(/^[A-Za-z0-9\s]*$/g))
                    setTempName(e.target.value);
                }}
                onKeyDown={(e) => {
                  if (e.keyCode === 13) {
                    if (tempName.length > 0) setCurrentName(tempName);
                    setNameUnderEdit((previous) => !previous);
                  }
                }}
              />
            ) : (
              <p className="graph-name-label">{currentName}</p>
            )}
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
            name={currentName}
            handleGraphChange={handleGraphChange}
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
            {graphNames.map((grapObj) => {
              return (
                <div
                  className="graph-name-item"
                  onClick={() => loadGraph(grapObj)}
                >
                  <h3 className="graph-name-text">{grapObj.name}</h3>
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
