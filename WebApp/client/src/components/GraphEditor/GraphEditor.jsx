import "./GraphEditor.scss";

import GraphBox from "./components/GraphBox";
import GraphToolbar from "./components/GraphToolbar";

const GraphEditor = () => {
  return (
    <div className="graph-editor">
      <GraphToolbar />
      <GraphBox />
    </div>
  );
};

export default GraphEditor;
