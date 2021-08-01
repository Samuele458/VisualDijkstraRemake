import "./GraphEditor.scss";
import React, { useEffect, useState, useContext } from "react";

import GraphBox from "./components/GraphBox";
import Lodash from "lodash";
import axios from "axios";

import AuthApi from "../../AuthApi";

const GraphEditor = () => {
  const Auth = useContext(AuthApi);

  const [currentGraph, setCurrentGraph] = useState({ nodes: [], edges: [] });
  const [currentName, setCurrentName] = useState("Untitled");
  const [wasUploaded, setWasUploaded] = useState(false);

  useEffect(() => {
    if (!Auth.loggedUser) {
      setCurrentGraph({ nodes: [], edges: [] });
      setCurrentName("Untitled");
      setWasUploaded(false);
    }
  }, [Auth.loggedUser]);

  const handleGraphChange = (graph) => {
    console.log("Handling graph change...", graph);

    setCurrentGraph(graph);
  };

  //if (!readyToSave) return null;
  console.log("Re rendering");
  return (
    <div className="graph-editor-box">
      {Auth.loggedUser && (
        <input
          type="text"
          value={currentName}
          onChange={(e) => {
            if (!wasUploaded) setCurrentName(e.target.value);
          }}
        />
      )}

      <div className="graph-editor">
        <div className="graph-sidebar" onClick={() => {}}></div>

        <GraphBox graph={currentGraph} handleGraphChange={handleGraphChange} />
      </div>
    </div>
  );
};

export default GraphEditor;
