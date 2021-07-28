import React, { useRef, useState, useEffect } from "react";
import * as d3 from "d3";
import "d3-selection-multi";
import Lodash from "lodash";

import AddNodeIcon from "./icons/add.png";
import AddEdgeIcon from "./icons/route.png";

const GraphBox = (props) => {
  let svg = useRef(null);
  let graphGroup = useRef(null);
  let [graph, setGraph] = useState({});

  let [nodeCreationRequested, setNodeCreationRequested] = useState(false);
  let [nodeCreationText, setNodeCreationText] = useState("");

  let [edgeCreationRequested, setEdgeCreationRequested] = useState(false);
  let [firstNode, setFirstNode] = useState(null);

  let [transformPos, setTransformPos] = useState({ x: 0, y: 0 });

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
    console.log("Attempt to render", 4);
    if (Object.keys(graph).length !== 0 && graphGroup) {
      console.log("rendering", graph, 4);
      d3.select(graphGroup.current).selectAll("*").remove();

      d3.select(svg.current).call(
        d3
          .drag()
          .on("drag", draggedd)
          .on("start", dragstarted)
          .on("end", dragended)
      );

      d3.select(svg.current).call(
        d3.zoom().on("zoom", function (event) {
          console.log(svg);
          d3.select(graphGroup.current).attr("transform", event.transform);
        })
      );

      let svgGroup = d3.select(graphGroup.current);

      /*
      let svgGroup = d3
        .select(svg.current)
        .call(
          d3
            .drag()
            .on("drag", draggedd)
            .on("start", dragstarted)
            .on("end", dragended)
        )
        .append("g")
        .attr("transform", "translate(0,0)");
      */

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
        .attr("x", function (d) {
          return (d.dest.x + d.source.x) / 2;
        })
        .attr("y", function (d) {
          return (d.dest.y + d.source.y) / 2;
        });

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
          .attr("x", (edge) => (edge.dest.x + edge.source.x) / 2)
          .attr("y", (edge) => (edge.dest.y + edge.source.y) / 2);

        node_text
          .filter(function (n) {
            return n === d;
          })
          .attr("x", d.x - 10)
          .attr("y", d.y + 10);
      }

      /*
      function getTranslation(transform) {
        var g = document.createElementNS("http://www.w3.org/2000/svg", "g");
        g.setAttributeNS(null, "transform", transform);
        var matrix = g.transform.baseVal.consolidate().matrix;
        return [matrix.e, matrix.f];
      }
      */

      function dragstarted(event, d) {
        event.sourceEvent.stopPropagation();
        event.sourceEvent.preventDefault();
      }

      function draggedd(event) {
        //var t = d3.transform(svgGroup.attr("transform")).translate;
        //var t = getTranslation(svgGroup.attr("transform"));
        setTransformPos((previous) => ({
          x: previous.x + event.dx,
          y: previous.y + event.dy,
        }));
        //svgGroup.attr(
        //  "transform",
        //  "translate(" + (t[0] + event.dx) + "," + (t[1] + event.dy) + ")"
        //);
      }

      function dragended(event, d) {}
    }
  }, [graph]);

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
      </div>
      <svg
        className="graph-box"
        ref={svg}
        {...props}
        width="800"
        height="600"
        onClick={(e) => {
          var dim = e.target.getBoundingClientRect();
          var x = e.clientX - dim.left - transformPos.x;
          var y = e.clientY - dim.top - transformPos.y;

          if (
            e.target.className.baseVal === "graph-box" &&
            nodeCreationRequested
          ) {
            if (
              graph.nodes.filter((n) => n.name === nodeCreationText).length ===
              0
            ) {
              let holdGraph = Lodash.cloneDeep(graph);
              holdGraph.nodes.push({ x: x, y: y, name: nodeCreationText });
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
          } else {
          }
          setNodeCreationRequested(false);
        }}
      >
        <g
          ref={graphGroup}
          transform={"translate(" + transformPos.x + "," + transformPos.y + ")"}
        ></g>
      </svg>
    </div>
  );
};

export default GraphBox;
