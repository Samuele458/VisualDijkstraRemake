import React, { useRef, useState, useEffect, useContext } from "react";
import * as d3 from "d3";
import "d3-selection-multi";
import Lodash from "lodash";

import * as GraphUtils from "../../../../utils/graphUtils";
import StatesViewer from "../../../StatesViewer";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faMinusCircle,
  faPlusCircle,
  faLink,
  faSearchPlus,
  faSearchMinus,
  faSave,
  faRoute,
} from "@fortawesome/free-solid-svg-icons";

import CheckIcon from "../../icons/check.png";

import AuthApi from "../../../../AuthApi";

const useFocus = () => {
  const htmlElRef = useRef(null);
  const setFocus = () => {
    htmlElRef.current && htmlElRef.current.focus();
  };

  return [htmlElRef, setFocus];
};

const GraphBox = (props) => {
  const Auth = useContext(AuthApi);

  //reference to svg DOM object
  const svg = useRef(null);

  //reference to g dom object
  const graphGroup = useRef(null);

  //current graph model
  const [graph, setGraph] = useState({ nodes: [], edges: [] });

  //requests
  const [nodeCreationRequested, setNodeCreationRequested] = useState(false);
  const [pathRequested, setPathRequested] = useState(true);
  const [edgeCreationRequested, setEdgeCreationRequested] = useState(false);
  const [nodeRemovalRequested, setNodeRemovalRequested] = useState(false);

  //hold first node in multi node requests (like edge creation, etc.)
  const [firstNode, setFirstNode] = useState(null);

  const [pathToSolve, setPathToSolve] = useState(null);

  //solution state
  const [currentState, setCurrentState] = useState(null);

  const [nodeUnderEdit, setNodeUnderEdit] = useState(null);
  const [inputBoxInfo, setInputBoxInfo] = useState({ text: "", x: 0, y: 0 });

  const [transformPos, setTransformPos] = useState({ x: 0, y: 0 });
  const [scale, setScale] = useState(1);

  //handling of focus in input box
  const [inputRef, setInputFocus] = useFocus();

  useEffect(() => {
    //loading new graph from props
    let graphObj = Lodash.cloneDeep(props.graph);
    if (
      graphObj.edges.length > 0 &&
      typeof graphObj.edges[0].source === "string"
    )
      GraphUtils.encodeGraphReferences(graphObj);

    setGraph(graphObj);
  }, [props.graph]);

  useEffect(() => {
    //graph rendering

    //if both graph and graphBox exist
    if (graph && graphGroup) {
      //removing all previous elements
      d3.select(graphGroup.current).selectAll("*").remove();

      //handling of backgraund drag events
      d3.select(svg.current).call(
        d3.drag().on("drag", draggedd).on("start", dragstarted)
      );

      //setting zoom
      d3.select(svg.current)
        .call(
          d3.zoom().on("zoom", (event) => {
            if (Math.sign(event.sourceEvent.deltaY) === -1) {
              setScale((previous) => previous * 1.1);
            } else {
              setScale((previous) => previous * 0.9);
            }
          })
        )
        .on("dblclick.zoom", null);

      //drawable area
      let svgGroup = d3.select(graphGroup.current);

      //egdes
      let edge = svgGroup
        .append("g")
        .selectAll("line")
        .data(graph.edges)
        .enter()
        .append("line")
        .attr("name", (d) => GraphUtils.encodeEdgeName(d.source, d.dest))
        .attr("class", (d) => {
          let className = "edge";
          if (currentState) {
            const sourceState = currentState.NodesStates.find(
              (s) => s.Name === d.source.name
            );

            const destState = currentState.NodesStates.find(
              (s) => s.Name === d.dest.name
            );

            if (
              sourceState.Previous === destState.Name ||
              destState.Previous === sourceState.Name
            ) {
              className += " partial-path";
            }

            let path = GraphUtils.evaluatePathFromState(currentState);
            let sourceFound = path.indexOf(d.source.name);
            let destFound = path.indexOf(d.dest.name);
            console.log(path, destFound, sourceFound);
            if (
              sourceFound !== -1 &&
              destFound !== -1 &&
              Math.abs(destFound - sourceFound) === 1
            )
              className += " path";
          }

          return className;
        })
        .attr("x1", (d) => {
          return d.source.x;
        })
        .attr("y1", (d) => {
          return d.source.y;
        })
        .attr("x2", (d) => {
          return d.dest.x;
        })
        .attr("y2", (d) => {
          return d.dest.y;
        });

      let nodesBg = svgGroup
        .append("g")
        .selectAll("circle")
        .data(graph.nodes)
        .enter()
        .append("circle")
        .attr("name", (d) => d.name)
        .attr("class", "node-bg")
        .attr("r", 30)
        .attr("cx", function (d) {
          return d.x;
        })
        .attr("cy", function (d) {
          return d.y;
        })
        .call(d3.drag().on("drag", dragged).on("start", dragstarted));

      let weight = svgGroup
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

      let node = svgGroup
        .append("g")
        .selectAll("circle")
        .data(graph.nodes)
        .enter()
        .append("circle")
        .attr("name", (d) => d.name)
        .attr("class", (d) => {
          let className = "node";
          if (
            currentState &&
            currentState.NodesStates.find((s) => s.Name === d.name)
          ) {
            const state = currentState.NodesStates.find(
              (s) => s.Name === d.name
            );

            if (state.Previous !== "DEFAULT_PREVIOUS_NODE") {
              className += " partial-path";
            }

            let path = GraphUtils.evaluatePathFromState(currentState);

            if (
              d.name === currentState.Source ||
              d.name === currentState.Dest ||
              path.indexOf(d.name) !== -1
            ) {
              className += " path";
            }
          }

          return className;
        })
        .attr("r", 30)
        .attr("cx", function (d) {
          return d.x;
        })
        .attr("cy", function (d) {
          return d.y;
        })
        .call(d3.drag().on("drag", dragged).on("start", dragstarted));

      let nodeName = svgGroup
        .append("g")
        .selectAll("circle")
        .data(graph.nodes)
        .enter()
        .append("text")
        .text((d) => d.name)
        .attr("name", (d) => d.name)
        .attr("class", "node-text")
        .attr("focusable", "true")
        .attr("text-anchor", "middle")
        .attr("x", function (d) {
          return d.x;
        })
        .attr("y", function (d) {
          return d.y + 10;
        })
        .call(d3.drag().on("drag", dragged).on("start", dragstarted));

      function dragged(event, d) {
        d.x = event.x;
        d.y = event.y;

        //saving file
        //props.handleGraphChange(graph);

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

        nodesBg
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

        nodeName
          .filter(function (n) {
            return n === d;
          })
          .attr("x", d.x)
          .attr("y", d.y + 10);
      }

      function dragstarted(event) {
        event.sourceEvent.stopPropagation();
        //event.sourceEvent.preventDefault();
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
    }
    setInputFocus();
  }, [graph, nodeUnderEdit, currentState, setInputFocus]);

  const setInputBonValue = () => {
    let holdGraph = Lodash.cloneDeep(graph);

    if (typeof nodeUnderEdit.weight === "undefined") {
      holdGraph.nodes.find((node) => node.name === nodeUnderEdit.name).name =
        inputBoxInfo.text;
    } else {
      holdGraph.edges.find(
        (edge) =>
          edge.source.name === nodeUnderEdit.source.name &&
          edge.dest.name === nodeUnderEdit.dest.name
      ).weight = parseInt(inputBoxInfo.text);
    }
    setGraph(holdGraph);
    setNodeUnderEdit(null);
  };

  return (
    <div className="graph-box-wrapper">
      <div className="graph-toolbar">
        {Auth.loggedUser && (
          <FontAwesomeIcon
            icon={faSave}
            className="btn-icon"
            alt="Save"
            onClick={() => {
              props.handleGraphChange(graph);
            }}
          />
        )}

        <FontAwesomeIcon
          icon={faPlusCircle}
          className="btn-icon"
          alt="Add new node"
          onClick={() => {
            setNodeCreationRequested(true);
          }}
        />

        <FontAwesomeIcon
          icon={faMinusCircle}
          className="btn-icon"
          alt="Remove node"
          onClick={() => {
            setNodeRemovalRequested(true);
          }}
        />

        <FontAwesomeIcon
          icon={faLink}
          className="btn-icon"
          alt="Add new edge"
          onClick={() => {
            setEdgeCreationRequested(true);
          }}
        />
        {Auth.loggedUser && (
          <FontAwesomeIcon
            icon={faRoute}
            className="btn-icon"
            alt="Evaluate path"
            onClick={() => {
              setPathRequested(true);
            }}
          />
        )}

        <FontAwesomeIcon
          icon={faSearchPlus}
          className="btn-icon"
          alt="Zoom in"
          onClick={() => {
            setScale((previous) => previous * 1.1);
          }}
        />
        <FontAwesomeIcon
          icon={faSearchMinus}
          className="btn-icon"
          alt="Zoom out"
          onClick={() => {
            setScale((previous) => previous * 0.9);
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

            setNodeUnderEdit(node);
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
            if (graph.nodes.filter((n) => n.name === "").length === 0) {
              let holdGraph = Lodash.cloneDeep(graph);
              holdGraph.nodes.push({
                x: x * (1 / scale),
                y: y * (1 / scale),
                name: "",
              });
              setGraph(holdGraph);

              let node = holdGraph.nodes.find((n) => n.name === "");
              setNodeUnderEdit(node);
              setInputBoxInfo({ text: "", x: e.clientX, y: e.clientY });
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

            if (
              typeof node != "undefined" &&
              !GraphUtils.edgeAlreadyExists(graph, node.name, firstNode.name)
            ) {
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
          } else if (
            pathRequested &&
            firstNode === null &&
            (e.target.className.baseVal === "node" ||
              e.target.className.baseVal === "node-text")
          ) {
            let name = e.target.getAttribute("name");
            let node = graph.nodes.find((n) => n.name === name);

            if (typeof node !== "undefined") {
              setFirstNode(node);
            }
          } else if (
            pathRequested &&
            firstNode != null &&
            (e.target.className.baseVal === "node" ||
              e.target.className.baseVal === "node-text")
          ) {
            let name = e.target.getAttribute("name");
            let node = graph.nodes.find((n) => n.name === name);
            if (typeof node !== "undefined") {
              setPathToSolve({
                name: props.name,
                source: name,
                dest: firstNode.name,
              });
              //console.log(firstNode);
              //props.handlePathRequest(node.name, firstNode.name);
            }

            setPathRequested(false);
            setFirstNode(null);
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
          ref={inputRef}
          value={inputBoxInfo.text}
          onChange={(e) => {
            setInputBoxInfo((previous) => ({
              ...previous,
              text: e.target.value,
            }));
          }}
          onKeyDown={(e) => {
            if (e.keyCode === 13) {
              setInputBonValue();
            }
          }}
        />
        <img
          src={CheckIcon}
          className="submit btn-icon"
          alt=""
          onClick={() => {
            setInputBonValue();
          }}
        />
      </div>
      <StatesViewer pathToSolve={pathToSolve} setState={setCurrentState} />
    </div>
  );
};

export default GraphBox;
