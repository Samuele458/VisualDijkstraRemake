import Dialog from "../../../Dialog";
import axios from "axios";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashAlt } from "@fortawesome/free-solid-svg-icons";

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

  return (
    <Dialog handleClose={props.handleClose}>
      <h2 style={{ padding: "0rem 0rem 1.5rem 1.5rem" }}>Load a graph</h2>
      <div className="graph-names-box">
        {props.graphs.map((grapObj) => {
          return (
            <div className="graph-name-item" onClick={() => loadGraph(grapObj)}>
              <div className="graph-name-text-box">
                <h3 className="graph-name-text">{grapObj.name}</h3>
                <p className="update-date">Last update: 23 May 2018 - 16:55</p>
              </div>
              <FontAwesomeIcon icon={faTrashAlt} className="btn-icon" alt="" />
            </div>
          );
        })}
      </div>
    </Dialog>
  );
};

export default GraphsMenu;
