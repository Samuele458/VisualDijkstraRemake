import React, { useState, useEffect } from "react";

import axios from "axios";

import useError from "../../hooks/useError";

const StatesViewer = (props) => {
  const [states, setStates] = useState(null);
  const [currentState, setCurrentState] = useState(null);
  const [pathToSolve, setPathToSolve] = useState({
    name: "",
    source: "",
    dest: "",
  });

  const { addError } = useError();

  useEffect(() => {
    if (
      props.pathToSolve &&
      (pathToSolve.name !== props.pathToSolve.name ||
        pathToSolve.source !== props.pathToSolve.source ||
        pathToSolve.dest !== props.pathToSolve.dest)
    ) {
      setPathToSolve(props.pathToSolve);
    }

    if (pathToSolve !== null && props.pathToSolve === null) {
      setStates(null);
      props.setState(null);
    }
  }, [props, pathToSolve]);

  useEffect(() => {
    if (pathToSolve && pathToSolve.name !== "")
      axios
        .get(
          `/api/graph/solve?id=${pathToSolve.id}&source=${pathToSolve.source}&dest=${pathToSolve.dest}`
        )
        .then((response) => {
          setStates(response.data);
        })
        .catch((error) => {
          addError("Server error");
        });
    else {
      setStates(null);
      setCurrentState(null);
    }
  }, [pathToSolve, pathToSolve.name, addError]);

  useEffect(() => {
    if (states) {
      setCurrentState(states[0]);
      props.setState(states[0]);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [states]);

  //if (pathToSolve === null) props.setState(null);

  return (
    <div
      className="states-viewer"
      style={{ visibility: states === null ? "hidden" : "visible" }}
    >
      <div className="states-picker">
        {Array.isArray(states) &&
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
            currentState.NodesStates &&
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
