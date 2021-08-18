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
  faRoute,
  faGreaterThan,
  faLessThan,
} from "@fortawesome/free-solid-svg-icons";
import CheckIcon from "../../icons/check.png";

import AuthApi from "../../../../AuthApi";
import useError from "../../../../hooks/useError";

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

  //error handling
  const { addError } = useError();

  //requests
  const [nodeCreationRequested, setNodeCreationRequested] = useState(false);
  const [pathRequested, setPathRequested] = useState(false);
  const [edgeCreationRequested, setEdgeCreationRequested] = useState(false);
  const [nodeRemovalRequested, setNodeRemovalRequested] = useState(false);

  //hold first node in multi node requests (like edge creation, etc.)
  const [firstNode, setFirstNode] = useState(null);

  const [pathToSolve, setPathToSolve] = useState(null);

  //solution state
  const [currentState, setCurrentState] = useState(null);

  const [nodeUnderEdit, setNodeUnderEdit] = useState(null);
  const [inputBoxInfo, setInputBoxInfo] = useState({ text: "", x: 0, y: 0 });

  const [weightUnderEdit, setWeightUnderEdit] = useState(null);
  const [weightBoxInfo, setWeightBoxInfo] = useState({
    value: 1,
  });

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

    clearRequests();
    setGraph(graphObj);
  }, [props.graph]);

  useEffect(() => {
    //removing inputbox when zoomin/zoomout
    setNodeUnderEdit(null);
  }, [scale]);

  useEffect(() => {
    if (
      nodeUnderEdit === null &&
      graph.nodes.find((n) => n.name.length === 0)
    ) {
      let holdGraph = Lodash.cloneDeep(graph);
      holdGraph.nodes = holdGraph.nodes.filter((node) => node.name !== "");
      holdGraph.edges = holdGraph.edges.filter(
        (edge) => edge.source.name !== "" && edge.dest.name !== ""
      );

      setGraph(holdGraph);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [nodeUnderEdit]);

  useEffect(() => {
    //graph rendering

    //if both graph and graphBox exist
    if (graph && graphGroup /*&& !Lodash.isEqual(graph, renderedGraph)*/) {
      //setRenderedGraph(Lodash.cloneDeep(graph));

      props.handleGraphChange(graph);
      //removing all previous elements
      d3.select(graphGroup.current).selectAll("*").remove();

      //handling of background drag events
      d3.select(svg.current)
        .call(
          d3
            .drag()
            .on("start", bgDragStarted)
            .on("drag", bgOnDrag)
            .on("end", bgDragEnded)
        )
        .on("dblclick", bgDoubleClick);

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

      svgGroup
        .append("line")
        .attr("id", "edge-creation-line")
        .attr("class", "edge creating-edge")
        .attr("x1", 0)
        .attr("y1", 0)
        .attr("x2", 0)
        .attr("y2", 0);
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
        });
      //.call(d3.drag().on("start", dragStarted).on("drag", dragNode));

      let weight = svgGroup
        .append("g")
        .selectAll("text")
        .data(graph.edges)
        .enter()
        .append("text")
        .text((d) => d.weight)
        .attr("text-anchor", "middle")
        .attr("class", "weight-text noselect")
        .attr("name", (d) => GraphUtils.encodeEdgeName(d.source, d.dest))
        .attr("x", (edge) => GraphUtils.evaluateWeightPos("x", edge))
        .attr("y", (edge) => GraphUtils.evaluateWeightPos("y", edge))
        .on("dblclick", weightDoubleClick);

      let node = svgGroup
        .append("g")
        .selectAll("circle")
        .data(graph.nodes)
        .enter()
        .append("circle")
        .attr("name", (d) => d.name)
        .attr("class", (d) => {
          let className = "node";

          if (firstNode && firstNode.name === d.name) {
            className += " first-node";
          }

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
        .call(
          d3
            .drag()
            .on("start", dragNodeStarted)
            .on("drag", nodeOnDrag)
            .on("end", dragNodeEnded)
        )
        .on("dblclick", nodeDoubleClick);

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
        .call(
          d3
            .drag()
            .on("start", dragNodeStarted)
            .on("drag", nodeOnDrag)
            .on("end", dragNodeEnded)
        )
        .on("dblclick", nodeDoubleClick);

      function weightDoubleClick(e, d) {
        clearRequests();
        setWeightUnderEdit(d);
        setWeightBoxInfo((p) => ({ ...p, value: d.weight }));
      }

      let longPress = null;
      let currentNode = null;
      let nodeOnMouseOver = null;

      function dragNodeStarted(e, d) {
        currentNode = d.name;

        setNodeUnderEdit(null);
        setWeightUnderEdit(null);

        setTimeout(() => {
          if (currentNode === d.name) {
            clearRequests();
            longPress = true;
            nodeOnMouseOver = currentNode;
            d3.select("#edge-creation-line")
              .attr("x1", d.x)
              .attr("y1", d.y)
              .attr("x2", d.x)
              .attr("y2", d.y);
            d3.selectAll(".node").attr("class", (n) =>
              n.name === d.name ? "node creating-edge" : "node"
            );
          }
        }, 350);

        if (edgeCreationRequested && firstNode === null) {
          //creating new node

          let node = graph.nodes.find((n) => n.name === d.name);
          if (typeof node != "undefined") {
            setFirstNode(node);
          }
        } else if (edgeCreationRequested && firstNode !== null) {
          //picking first node of edge

          let node = graph.nodes.find((n) => n.name === d.name);
          if (
            typeof node !== "undefined" &&
            !GraphUtils.edgeAlreadyExists(graph, node.name, firstNode.name) &&
            firstNode.name !== node.name
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
        } else if (nodeRemovalRequested) {
          let holdGraph = Lodash.cloneDeep(graph);
          holdGraph.nodes = holdGraph.nodes.filter(
            (node) => node.name !== d.name
          );
          holdGraph.edges = holdGraph.edges.filter(
            (edge) => edge.source.name !== d.name && edge.dest.name !== d.name
          );

          setGraph(holdGraph);
          setNodeRemovalRequested(false);
        } else if (pathRequested && firstNode === null) {
          let node = graph.nodes.find((n) => n.name === d.name);

          if (typeof node !== "undefined") {
            setFirstNode(node);
          }
        } else if (pathRequested && firstNode !== null) {
          let name = d.name;
          let node = graph.nodes.find((n) => n.name === name);
          if (typeof node !== "undefined") {
            setPathToSolve({
              name: props.name,
              id: props.id,
              source: firstNode.name,
              dest: name,
            });
          }

          setPathRequested(false);
          setFirstNode(null);
        }
      }

      function dragNodeEnded(e, d) {
        let holdGraph = Lodash.cloneDeep(graph);

        if (longPress) {
          d3.select("#edge-creation-line")
            .attr("x1", d.x)
            .attr("y1", d.y)
            .attr("x2", d.x)
            .attr("y2", d.y);

          d3.selectAll(".node").attr("class", "node");

          if (
            GraphUtils.onNode(e.sourceEvent.target) &&
            !GraphUtils.edgeAlreadyExists(
              graph,
              nodeOnMouseOver,
              e.sourceEvent.target.getAttribute("name")
            ) &&
            nodeOnMouseOver !== e.sourceEvent.target.getAttribute("name")
          ) {
            holdGraph.edges.push({
              source: holdGraph.nodes.find((n) => n.name === nodeOnMouseOver),
              dest: holdGraph.nodes.find(
                (n) => n.name === e.sourceEvent.target.getAttribute("name")
              ),
              weight: 3,
            });

            setGraph(holdGraph);
          }
        }
        props.handleGraphChange(holdGraph);

        longPress = null;
        currentNode = null;
      }

      function nodeOnDrag(event, d) {
        if (!nodeUnderEdit)
          if (!longPress) {
            currentNode = null;

            d.x = event.x;
            d.y = event.y;
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
          } else {
            d3.select("#edge-creation-line")
              .attr("x2", event.x + 15)
              .attr("y2", event.y + 15);
          }
      }

      function nodeDoubleClick(e, d) {
        clearRequests();
        setNodeUnderEdit(d);
        setInputBoxInfo({
          text: d.name,
          x: d.x * scale + transformPos.x,
          y: d.y * scale + transformPos.y + 60,
        });

        setInputFocus();
      }

      function bgDragStarted(e) {
        e.sourceEvent.stopPropagation();
        e.sourceEvent.preventDefault();

        setWeightUnderEdit(null);

        if (nodeCreationRequested) {
          if (graph.nodes.filter((n) => n.name === "").length === 0) {
            let holdGraph = Lodash.cloneDeep(graph);
            holdGraph.nodes.push({
              x: (e.x - transformPos.x) * (1 / scale),
              y: (e.y - transformPos.y) * (1 / scale),
              name: "",
            });
            setGraph(holdGraph);

            let node = holdGraph.nodes.find((n) => n.name === "");
            setNodeUnderEdit(node);
            setInputBoxInfo({
              text: "",
              x: e.x,
              y: e.y + 60,
            });
          }
          setNodeCreationRequested(false);
        }

        setEdgeCreationRequested(false);
        setFirstNode(null);
      }

      function bgOnDrag(event) {
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

    function bgDragEnded(e) {}

    function bgDoubleClick(e, d) {
      if (GraphUtils.onBackground(e.target)) {
        clearRequests();
        if (graph.nodes.filter((n) => n.name === "").length === 0) {
          let holdGraph = Lodash.cloneDeep(graph);
          holdGraph.nodes.push({
            x: (e.x - transformPos.x) * (1 / scale),
            y: (e.y - transformPos.y) * (1 / scale),
            name: "",
          });
          setGraph(holdGraph);

          let node = holdGraph.nodes.find((n) => n.name === "");
          setNodeUnderEdit(node);
          setInputBoxInfo({
            text: "",
            x: e.x,
            y: e.y + 60,
          });

          setInputFocus();
        }
      }
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [
    graph,
    currentState,
    nodeCreationRequested,
    edgeCreationRequested,
    pathRequested,
    firstNode,
    transformPos,
  ]);

  const setInputBoxValue = () => {
    let holdGraph = Lodash.cloneDeep(graph);

    if (typeof nodeUnderEdit.weight === "undefined") {
      if (!holdGraph.nodes.find((n) => n.name === inputBoxInfo.text))
        holdGraph.nodes.find((node) => node.name === nodeUnderEdit.name).name =
          inputBoxInfo.text;
      //else addError("Node already exists");
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

  const setWeightValue = () => {
    let holdGraph = Lodash.cloneDeep(graph);

    holdGraph.edges.find(
      (edge) =>
        edge.source.name === weightUnderEdit.source.name &&
        edge.dest.name === weightUnderEdit.dest.name
    ).weight = weightBoxInfo.value;

    setGraph(holdGraph);
    setWeightUnderEdit(null);
  };

  /**
   *  Clear any pending request
   */
  const clearRequests = () => {
    setNodeCreationRequested(false);
    setPathRequested(false);
    setEdgeCreationRequested(false);
    setNodeRemovalRequested(false);
    setFirstNode(null);
    setPathToSolve(null);
    setCurrentState(null);
    setNodeUnderEdit(null);
    setWeightUnderEdit(null);
  };

  return (
    <div className="graph-box-wrapper">
      <div className="graph-toolbar">
        {props.externalButtons &&
          props.externalButtons.map((btn) => {
            return (
              <FontAwesomeIcon
                icon={btn.icon}
                className="btn-icon"
                alt=""
                onClick={btn.onClick}
              />
            );
          })}

        <FontAwesomeIcon
          icon={faPlusCircle}
          className="btn-icon"
          alt="Add new node"
          onClick={() => {
            clearRequests();
            setNodeCreationRequested(true);
          }}
        />

        <FontAwesomeIcon
          icon={faMinusCircle}
          className="btn-icon"
          alt="Remove node"
          onClick={() => {
            clearRequests();
            setNodeRemovalRequested(true);
          }}
        />

        <FontAwesomeIcon
          icon={faLink}
          className="btn-icon"
          alt="Add new edge"
          onClick={() => {
            clearRequests();
            setEdgeCreationRequested(true);
          }}
        />
        {Auth.loggedUser && (
          <FontAwesomeIcon
            icon={faRoute}
            className="btn-icon"
            alt="Evaluate path"
            onClick={() => {
              clearRequests();
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
        /*
        onMouseDown={(e) => {
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
        */
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
        id="weight-box"
        style={{
          visibility: weightUnderEdit ? "visible" : "hidden",
          left: weightUnderEdit
            ? GraphUtils.evaluateWeightPos("x", weightUnderEdit) * scale +
              transformPos.x -
              60
            : 0,
          top: weightUnderEdit
            ? GraphUtils.evaluateWeightPos("y", weightUnderEdit) * scale +
              transformPos.y -
              40
            : 0,
        }}
      >
        <div className="hflex flex-center">
          <FontAwesomeIcon
            icon={faLessThan}
            className="btn-icon"
            alt="Decrement"
            onClick={() => {
              setWeightBoxInfo((p) => ({
                ...p,
                value: p.value - 1 > 0 ? p.value - 1 : p.value,
              }));
            }}
          />
          <input
            type="text"
            className="weight-input"
            value={weightBoxInfo.value}
          />
          <FontAwesomeIcon
            icon={faGreaterThan}
            className="btn-icon"
            alt="Increment"
            onClick={() => {
              setWeightBoxInfo((p) => ({ ...p, value: p.value + 1 }));
            }}
          />
        </div>
        <img
          src={CheckIcon}
          className="submit btn-icon"
          alt=""
          onClick={() => {
            setWeightValue();
          }}
        />{" "}
      </div>
      <div
        id="graph-input-box"
        style={{
          top: inputBoxInfo.y - 20,
          left: inputBoxInfo.x - 30,
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
              text: e.target.value.toUpperCase().match(/^[A-Z0-9]{0,2}$/g)
                ? e.target.value.toUpperCase()
                : previous.text,
            }));
          }}
          onKeyDown={(e) => {
            if (e.keyCode === 13) {
              setInputBoxValue();
            }
          }}
        />
        <img
          src={CheckIcon}
          className="submit btn-icon"
          alt=""
          onClick={() => {
            setInputBoxValue();
          }}
        />
      </div>
      <StatesViewer pathToSolve={pathToSolve} setState={setCurrentState} />
    </div>
  );
};

export default GraphBox;
