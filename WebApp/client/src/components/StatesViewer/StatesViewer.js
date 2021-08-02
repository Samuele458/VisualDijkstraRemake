import React, { useState, useEffect } from "react";

import axios from "axios";

const StatesViewer = (props) => {
  const [states, setStates] = useState(null);
  const [currentState, setCurrentState] = useState(null);
  const [pathToSolve, setPathToSolve] = useState({
    name: "",
    source: "",
    dest: "",
  });

  useEffect(() => {
    if (
      props.pathToSolve &&
      (pathToSolve.name !== props.pathToSolve.name ||
        pathToSolve.source !== props.pathToSolve.source ||
        pathToSolve.dest !== props.pathToSolve.dest)
    ) {
      setPathToSolve(props.pathToSolve);
    }
  }, [props]);

  useEffect(() => {
    if (pathToSolve)
      axios
        .get(
          `/api/graph/solve?name=${pathToSolve.name}&source=${pathToSolve.source}&dest=${pathToSolve.dest}`
        )
        .then((response) => {
          setStates(response.data);
        })
        .catch((error) => {
          console.log("ERROR LOGOUT", error);
        });
    else {
      setStates(null);
      setCurrentState(null);
    }
  }, [pathToSolve]);

  useEffect(() => {
    if (states) {
      setCurrentState(states[0]);
      props.setState(states[0]);
    }
  }, [states]);

  return (
    <div className="states-viewer">
      <div className="states-picker">
        {states &&
          states.map((s, i) => {
            return (
              <button
                key={i}
                onClick={() => {
                  setCurrentState(states[i]);
                  props.setState(states[i]);
                }}
              >
                {i}
              </button>
            );
          })}
      </div>
      <div className="state-table-box">
        <table className="state-table">
          <tr>
            <th>Node</th>
            <th>Previous</th>
            <th>Distance</th>
          </tr>
          {currentState &&
            currentState.NodesStates.map((s) => {
              return (
                <tr>
                  <th>{s.Name}</th>
                  <th>
                    {s.Previous === "DEFAULT_PREVIOUS_NODE" ? "-" : s.Previous}
                  </th>
                  <th>{s.Distance === 999999999 ? "Inf" : s.Distance}</th>
                </tr>
              );
            })}
        </table>
      </div>
    </div>
  );
};

export default StatesViewer;
