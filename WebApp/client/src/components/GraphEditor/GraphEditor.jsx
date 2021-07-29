import "./GraphEditor.scss";

import GraphBox from "./components/GraphBox";

const GraphEditor = () => {
  return (
    <div className="graph-editor">
      <div className="graph-sidebar">
        <p>d</p>
      </div>
      <GraphBox />
    </div>
  );
};

export default GraphEditor;
