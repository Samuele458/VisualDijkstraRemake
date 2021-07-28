import React, { useRef, useState, useEffect } from "react";
import * as d3 from "d3";
import "d3-selection-multi";
import Lodash, { set } from "lodash";

import * as GraphUtils from "../../../../utils/graphUtils";

import AddNodeIcon from "./icons/add.png";
import AddEdgeIcon from "./icons/route.png";
import RemoveIcon from "./icons/delete.png";
import ZoomInIcon from "./icons/zoom-in.png";
import ZoomOutIcon from "./icons/zoom-out.png";
import CheckIcon from "./icons/check.png";

const GraphBox = (props) => {
  let svg = useRef(null);
  let graphGroup = useRef(null);
  let [graph, setGraph] = useState({});

  let [nodeCreationRequested, setNodeCreationRequested] = useState(false);
  let [nodeCreationText, setNodeCreationText] = useState("");

  let [edgeCreationRequested, setEdgeCreationRequested] = useState(false);
  let [firstNode, setFirstNode] = useState(null);

  let [nodeRemovalRequested, setNodeRemovalRequested] = useState(false);

  let [nodeUnderEdit, setNodeUnderEdit] = useState(null);
  let [inputBoxInfo, setInputBoxInfo] = useState({ text: "", x: 0, y: 0 });

  let [transformPos, setTransformPos] = useState({ x: 0, y: 0 });
  let [scale, setScale] = useState(1);

  useEffect(() => {
    let holdGraph = {
      nodes: [
        { x: 444, y: 275, name: "A" },
        { x: 378, y: 324, name: "B" },
        { x: 478, y: 278, name: "C" },
        { x: 471, y: 256, name: "D" },
      ],
      edges: [
        { source: "A", dest: "D", weight: 3 },
        { source: "D", dest: "C", weight: 3 },
        { source: "B", dest: "C", weight: 3 },
        { source: "B", dest: "A", weight: 3 },
      ],
    };

    holdGraph.edges.forEach(function (edge) {
      edge.source = holdGraph.nodes.find((node) => node.name === edge.source);
      edge.dest = holdGraph.nodes.find((node) => node.name === edge.dest);
    });

    setGraph(holdGraph);
  }, []);

  useEffect(() => {
    if (Object.keys(graph).length !== 0 && graphGroup) {
      d3.select(graphGroup.current).selectAll("*").remove();

      d3.select(svg.current).call(
        d3
          .drag()
          .on("drag", draggedd)
          .on("start", dragstarted)
          .on("end", dragended)
      );

      d3.select(svg.current)
        .call(
          d3.zoom().on("zoom", function (event) {
            if (Math.sign(event.sourceEvent.deltaY) === -1) {
              setScale((previous) => previous * 1.1);
            } else {
              setScale((previous) => previous * 0.9);
            }
          })
        )
        .on("dblclick.zoom", null);

      let svgGroup = d3.select(graphGroup.current);
      var edge = svgGroup
        .append("g")
        .selectAll("line")
        .data(graph.edges)
        .enter()
        .append("line")
        .attr("class", "edge")
        .attr("x1", function (d) {
          return d.source.x;
        })
        .attr("y1", function (d) {
          return d.source.y;
        })
        .attr("x2", function (d) {
          return d.dest.x;
        })
        .attr("y2", function (d) {
          return d.dest.y;
        });

      var weight = svgGroup
        .append("g")
        .selectAll("text")
        .data(graph.edges)
        .enter()
        .append("text")
        .text((d) => d.weight)
        .attr("class", "weight-text")
        .attr("name", (d) => GraphUtils.encodeEdgeName(d.source, d.dest))
        .attr("x", (edge) => GraphUtils.evaluateWeightPos("x", edge))
        .attr("y", (edge) => GraphUtils.evaluateWeightPos("y", edge));

      var node = svgGroup
        .append("g")
        .selectAll("circle")
        .data(graph.nodes)
        .enter()
        .append("circle")
        .attr("name", (d) => d.name)
        .attr("class", "node")
        .attr("r", 30)
        .attr("cx", function (d) {
          return d.x;
        })
        .attr("cy", function (d) {
          return d.y;
        })
        .call(d3.drag().on("drag", dragged));

      var node_text = svgGroup
        .append("g")
        .selectAll("circle")
        .data(graph.nodes)
        .enter()
        .append("text")
        .text((d) => d.name)
        .attr("name", (d) => d.name)
        .attr("class", "node-text")
        .attr("focusable", "true")
        .attr("x", function (d) {
          return d.x - 10;
        })
        .attr("y", function (d) {
          return d.y + 10;
        })
        .call(d3.drag().on("drag", dragged));

      function dragged(event, d) {
        d.x = event.x;
        d.y = event.y;
        console.log(nodeUnderEdit, d.name);

        if (nodeUnderEdit !== null) {
          if (nodeUnderEdit.name === d.name)
            setInputBoxInfo((previous) => ({
              text: previous.text,
              x: event.sourceEvent.clientX,
              y: event.sourceEvent.clientY,
            }));
          else setNodeUnderEdit(null);
        }

        node
          .filter(function (n) {
            return n === d;
          })
          .attr("cx", d.x)
          .attr("cy", d.y);

        edge
          .filter(function (l) {
            return l.source.name === d.name;
          })
          .attr("x1", d.x)
          .attr("y1", d.y);

        edge
          .filter(function (l) {
            return l.dest.name === d.name;
          })
          .attr("x2", d.x)
          .attr("y2", d.y);

        weight
          .filter((edge) => edge.dest === d || edge.source === d)
          .attr("x", (edge) => GraphUtils.evaluateWeightPos("x", edge))
          .attr("y", (edge) => GraphUtils.evaluateWeightPos("y", edge));

        node_text
          .filter(function (n) {
            return n === d;
          })
          .attr("x", d.x - 10)
          .attr("y", d.y + 10);
      }

      function dragstarted(event, d) {
        event.sourceEvent.stopPropagation();
        event.sourceEvent.preventDefault();
      }

      function draggedd(event) {
        setTransformPos((previous) => ({
          x: previous.x + event.dx,
          y: previous.y + event.dy,
        }));

        setInputBoxInfo((previous) => ({
          x: previous.x + event.dx,
          y: previous.y + event.dy,
        }));
      }

      function dragended(event, d) {}
    }
  }, [graph, nodeUnderEdit]);

  return (
    <div className="graph-editor">
      <div className="graph-toolbar">
        <img
          src={AddNodeIcon}
          alt="Add new node"
          onClick={() => {
            setNodeCreationRequested(true);
          }}
        />
        <input
          type="text"
          onChange={(e) => {
            setNodeCreationText(e.target.value);
          }}
          value={nodeCreationText}
        />
        <img
          src={AddEdgeIcon}
          alt="Add new edge"
          onClick={() => {
            setEdgeCreationRequested(true);
          }}
        />
        <img
          src={ZoomInIcon}
          alt="ZoomIn"
          onClick={() => {
            setScale((previous) => previous * 1.1);
          }}
        />
        <img
          src={ZoomOutIcon}
          alt="ZoomOut"
          onClick={() => {
            setScale((previous) => previous * 0.9);
          }}
        />
        <img
          src={RemoveIcon}
          alt="Remove node"
          onClick={() => {
            setNodeRemovalRequested(true);
          }}
        />
      </div>

      <svg
        className="graph-svg"
        ref={svg}
        {...props}
        width="800"
        height="600"
        onDoubleClick={(e) => {
          if (
            e.target.className.baseVal === "node" ||
            e.target.className.baseVal === "node-text"
          ) {
            let name = e.target.getAttribute("name");
            let node = graph.nodes.find((n) => n.name === name);

            //console.log(e);
            setNodeUnderEdit(node);
            console.log("Nodeunderedit: ", name, node, nodeUnderEdit);
            setInputBoxInfo({ text: name, x: e.clientX, y: e.clientY });
          } else if (e.target.className.baseVal === "weight-text") {
            let nodesNames = GraphUtils.decodeEdgeName(
              e.target.getAttribute("name")
            );

            let edge = graph.edges.find(
              (edge) =>
                edge.source.name === nodesNames.source &&
                edge.dest.name === nodesNames.dest
            );
            setNodeUnderEdit(edge);
            setInputBoxInfo({
              text: edge.weight.toString(),
              x: e.clientX,
              y: e.clientY,
            });
          }
        }}
        onClick={(e) => {
          let dim = e.target.getBoundingClientRect();
          let x = e.clientX - dim.left - transformPos.x;
          let y = e.clientY - dim.top - transformPos.y;

          if (
            e.target.className.baseVal === "graph-svg" &&
            nodeCreationRequested
          ) {
            if (
              graph.nodes.filter((n) => n.name === nodeCreationText).length ===
              0
            ) {
              let holdGraph = Lodash.cloneDeep(graph);
              holdGraph.nodes.push({
                x: x * (1 / scale),
                y: y * (1 / scale),
                name: nodeCreationText,
              });
              setGraph(holdGraph);
            }
            //setGraph({ ...graph, dfdf: 3 });
          } else if (
            edgeCreationRequested &&
            firstNode === null &&
            (e.target.className.baseVal === "node" ||
              e.target.className.baseVal === "node-text")
          ) {
            let name = e.target.getAttribute("name");
            let node = graph.nodes.find((n) => n.name === name);

            if (typeof node != "undefined") {
              setFirstNode(node);
            }
            //setEdgeCreationRequested(false);
          } else if (
            edgeCreationRequested &&
            firstNode != null &&
            (e.target.className.baseVal === "node" ||
              e.target.className.baseVal === "node-text")
          ) {
            let name = e.target.getAttribute("name");
            let node = graph.nodes.find((n) => n.name === name);

            if (typeof node != "undefined") {
              let holdGraph = Lodash.cloneDeep(graph);
              holdGraph.edges.push({
                source: holdGraph.nodes.find((n) => n.name === firstNode.name),
                dest: holdGraph.nodes.find((n) => n.name === node.name),
                weight: 3,
              });

              setGraph(holdGraph);
            }

            setEdgeCreationRequested(false);
            setFirstNode(null);
          } else if (
            nodeRemovalRequested &&
            firstNode === null &&
            (e.target.className.baseVal === "node" ||
              e.target.className.baseVal === "node-text")
          ) {
            let name = e.target.getAttribute("name");
            let holdGraph = Lodash.cloneDeep(graph);
            holdGraph.nodes = holdGraph.nodes.filter(
              (node) => node.name !== name
            );
            holdGraph.edges = holdGraph.edges.filter(
              (edge) => edge.source.name !== name && edge.dest.name !== name
            );

            setGraph(holdGraph);
            setNodeRemovalRequested(false);
          } else {
            setNodeUnderEdit(null);
          }

          setNodeCreationRequested(false);
        }}
      >
        <g
          ref={graphGroup}
          className="graph-group"
          transform={
            "translate(" +
            transformPos.x +
            "," +
            transformPos.y +
            ") scale(" +
            scale +
            ")"
          }
        ></g>
      </svg>
      <div
        id="graph-input-box"
        style={{
          top: inputBoxInfo.y + 30,
          left: inputBoxInfo.x - 100,
          visibility: nodeUnderEdit === null ? "hidden" : "visible",
        }}
      >
        <input
          type="text"
          className="input-text"
          value={inputBoxInfo.text}
          onChange={(e) => {
            setInputBoxInfo((previous) => ({
              ...previous,
              text: e.target.value,
            }));
          }}
        />
        <img
          src={CheckIcon}
          className="submit"
          onClick={() => {
            let holdGraph = Lodash.cloneDeep(graph);

            if (typeof nodeUnderEdit.weight === "undefined") {
              holdGraph.nodes.find(
                (node) => node.name === nodeUnderEdit.name
              ).name = inputBoxInfo.text;
            } else {
              holdGraph.edges.find(
                (edge) =>
                  edge.source.name === nodeUnderEdit.source.name &&
                  edge.dest.name === nodeUnderEdit.dest.name
              ).weight = parseInt(inputBoxInfo.text);
            }
            setGraph(holdGraph);
            setNodeUnderEdit(null);
          }}
        />
      </div>
    </div>
  );
};

export default GraphBox;
