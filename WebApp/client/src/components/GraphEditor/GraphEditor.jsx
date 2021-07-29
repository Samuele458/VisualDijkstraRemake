import "./GraphEditor.scss";
import React, { useEffect, useState } from "react";

import GraphBox from "./components/GraphBox";
import axios from "axios";
const GraphEditor = () => {
  const [currentGraph, setCurrentGraph] = useState(undefined);

  useEffect(() => {
    console.log("URL: ", process.env.REACT_APP_API);
    axios.get(`/api/graph/?name=grafo3`).then((res) => {
      let data = res.data[0];
      setCurrentGraph({
        name: data.GraphName,
        data: JSON.parse(data.GraphData),
      });
    });
  }, []);
  console.log(currentGraph);
  return (
    <div className="graph-editor">
      <div className="graph-sidebar">
        <p>{currentGraph && currentGraph.GraphData}</p>
      </div>

      <GraphBox
        graph={
          currentGraph
            ? currentGraph
            : { name: "Untitled", data: { nodes: [], edges: [] } }
        }
      />
    </div>
  );
};

export default GraphEditor;
