import Dialog from "../../../Dialog";
import axios from "axios";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faTrashAlt,
  faExternalLinkAlt,
} from "@fortawesome/free-solid-svg-icons";

const GraphsMenu = (props) => {
  const loadGraph = (graphObj) => {
    axios
      .get(`/api/graph?Id=${graphObj.id}`)
      .then((response) => {
        props.setGraph(response.data);
      })
      .catch((error) => {
        console.log("ERROR LOGOUT", error);
      });
  };

  const deleteGraph = (graphObj) => {
    axios
      .delete(`/api/graph?Id=${graphObj.id}`)
      .then((response) => {
        props.triggerUpdate();
      })
      .catch((error) => {
        console.log("ERROR LOGOUT", error);
      });
  };

  return (
    <Dialog handleClose={props.handleClose}>
      <h2 style={{ padding: "0rem 0rem 1.5rem 1.5rem" }}>Load a graph</h2>
      <div className="graph-names-box">
        {props.graphs &&
          props.graphs.map((grapObj) => {
            console.log(grapObj);
            let UpdatedOn = new Date(grapObj.updatedOn);

            return (
              <div
                className={
                  grapObj.id === props.currentId
                    ? "graph-name-item current"
                    : "graph-name-item"
                }
              >
                <div className="graph-name-text-box">
                  <h3
                    className="graph-name-text"
                    onClick={() => loadGraph(grapObj)}
                  >
                    {grapObj.name}
                  </h3>
                  <p className="update-date">
                    Last update on
                    {" " +
                      UpdatedOn.toLocaleDateString("en-us", {
                        year: "numeric",
                        month: "short",
                        day: "numeric",
                      }) +
                      " " +
                      UpdatedOn.toLocaleTimeString()}
                  </p>
                </div>
                <div className="graph-name-toolbar">
                  <FontAwesomeIcon
                    icon={faExternalLinkAlt}
                    className="btn-icon"
                    alt="Delete"
                    onClick={() => loadGraph(grapObj)}
                  />
                  <FontAwesomeIcon
                    icon={faTrashAlt}
                    className="btn-icon"
                    alt="Delete"
                    onClick={() => {
                      deleteGraph(grapObj);
                    }}
                  />
                </div>
              </div>
            );
          })}
      </div>
    </Dialog>
  );
};

export default GraphsMenu;
