/**
 * Evaluate the angle (in radians) of a given edge
 * @param {Object} edge - The edge to evaluate the angle of
 * @returns {number} The angle in radians
 */
export const edgeAngle = (edge) => {
  return Math.atan2(edge.dest.x - edge.source.x, edge.dest.y - edge.source.y);
};

/**
 * Evaluate the position of the weight text, for a single axis
 * @param {string} axis - The axis "x" or "y"
 * @param {Object} edge - The edge to which the weight belongs
 * @returns {number} The weight position, for the given axis
 */
export const evaluateWeightPos = (axis, edge) => {
  if (axis.toLowerCase() === "x") {
    return (
      (edge.dest.x + edge.source.x) / 2 -
      23 * Math.cos(2 * Math.PI - edgeAngle(edge))
    );
  } else if (axis.toLowerCase() === "y") {
    return (
      (edge.dest.y + edge.source.y) / 2 -
      23 * Math.sin(2 * Math.PI - edgeAngle(edge))
    );
  }
};

/**
 * Create an edge name attribute like "A-B"
 * @param {string} source - Source node name
 * @param {string} dest - Dest node name
 * @returns
 */
export const encodeEdgeName = (source, dest) => {
  return source.name + "-" + dest.name;
};

/**
 * Converts an edge name attribute in the form "A-B" to Object like { source "A", dest: "B" }
 * @param {string} name - The edge name attrbute in the form "A-B"
 * @returns Object in form { source "A", dest: "B" }
 */
export const decodeEdgeName = (name) => {
  const nodes = name.split("-");
  return { source: nodes[0], dest: nodes[1] };
};

/**
 * Determines if an edge already exists in a given graph object
 * @param {Object} graph - Graph object
 * @param {string} sourceName - Source node name
 * @param {string} destName - Dest node name
 * @returns True if already exists, false otherwise
 */
export const edgeAlreadyExists = (graph, sourceName, destName) => {
  let edgeFound = graph.edges.find(
    (edge) =>
      (edge.source.name === sourceName && edge.dest.name === destName) ||
      (edge.source.name === destName && edge.dest.name === sourceName)
  );

  return typeof edgeFound !== "undefined";
};

/**
 * Substitutes every node name inside edge objects, with its object reference
 * @param {Object} graph - Graph object
 * @returns The graph object
 */
export const encodeGraphReferences = (graph) => {
  graph.edges.forEach((edge) => {
    edge.source = graph.nodes.find((node) => node.name === edge.source);
    edge.dest = graph.nodes.find((node) => node.name === edge.dest);
  });
  return graph;
};

/**
 * Substitutes every node object inside edge objects with its name
 * @param {Object} graph
 * @returns The graph object
 */
export const decodeGraphReferences = (graph) => {
  graph.edges.forEach((edge) => {
    edge.source = edge.source.name;
    edge.dest = edge.dest.name;
  });
  return graph;
};

/**
 * Converts every coordinate to integer
 * @param {*} graph - Grap object
 * @returns The graph object
 */
export const sanitizeCoordinates = (graph) => {
  graph.nodes.forEach((node) => {
    node.x = Math.round(node.x);
    node.y = Math.round(node.y);
  });
  return graph;
};

/**
 * Evaluate path from a given graph state
 * @param {Object} state - State object
 * @returns {Array.String} List of node names, from source to dest
 */
export const evaluatePathFromState = (state) => {
  //TODO handle cases in which there is no path
  let path = [];
  let currentNode = state.Dest;
  while (currentNode !== "DEFAULT_PREVIOUS_NODE") {
    path.push(currentNode);
    currentNode = state.NodesStates.find(
      (s) => s.Name === currentNode
    ).Previous;
  }
  return path;
};

/**
 * Checks is a given event target belongs to a node or not
 * @param {Object} target - Event target
 * @returns {boolean} True if event was on node, false otherwise
 */
export const onNode = (target) => {
  return (
    target.className.baseVal === "node" ||
    target.className.baseVal === "node-text"
  );
};

/**
 * Checks if a given event target belongs to background
 * @param {*} target - Event target
 * @returns {boolean} True if event was on node, false otherwise
 */
export const onBackground = (target) => {
  return target.className.baseVal === "graph-svg";
};

/**
 * Checks if a given event target belongs to edge
 * @param {*} target - Event target
 * @returns {boolean} True if event was on node, false otherwise
 */
export const onEdge = (target) => {
  return target.className.baseval === "weight-text";
};

/**
 * Evaluate delta position between basePos and currentPos.
 * @param {Object} basePos base position, composed of x and y.
 * @param {Object} currentPos - CurrentPosition, composed of x and y.
 * @returns {Object} New position
 */
export const deltaPos = (basePos, currentPos) => {
  return {
    x: basePos.x - currentPos.x,
    y: basePos.y - currentPos.y,
  };
};

/**
 * Chekc if a given node name is valid or not
 * @param {string} name - Node name
 * @returns {boolean} True if name is valid, false otherwise
 */
export const isNodeNameValid = (name) => {
  return name.match(/^[A-Z0-9]{0,3}$/g);
};

/**
 * Check if a given graph name is valid or not
 * @param {string} name - Graph name
 * @returns {boolean} True if name is valid, false otherwise
 */
export const isGraphNameValid = (name) => {
  return name.match(/^[A-Za-z0-9\s]*$/g);
};

/**
 * Check if a given graph in string format is valid or not
 * @param {string} graphString - Graph string in which graph is stored
 * @returns {boolean} True if graph is valid, false otherwise
 */
export const isGraphValid = (graphString) => {
  try {
    //checking if is valid json
    let graphObj = JSON.parse(graphString);

    //checking if nodes and edges arrays exist
    if (
      Object.keys(graphObj).length !== 2 ||
      !Array.isArray(graphObj.nodes) | !Array.isArray(graphObj.edges)
    )
      return false;

    //checking for nodes fields
    for (let i = 0; i < graphObj.nodes.length; i++) {
      let node = graphObj.nodes[i];
      if (
        Object.keys(node).length !== 3 ||
        typeof node.name !== "string" ||
        typeof node.x !== "number" ||
        typeof node.y !== "number"
      )
        return false;
    }

    //checking for duplicates
    let nodeNames = graphObj.nodes.map((n) => n.name);
    if (new Set(nodeNames).size !== nodeNames.length) return false;

    //checking for edges fields
    for (let i = 0; i < graphObj.edges.length; i++) {
      let edge = graphObj.edges[i];
      if (
        Object.keys(edge).length !== 3 ||
        typeof edge.source !== "string" ||
        typeof edge.dest !== "string" ||
        typeof edge.weight !== "number"
      )
        return false;

      //checking for edges names
      if (
        nodeNames.indexOf(edge.source) > 0 &&
        nodeNames.indexOf(edge.dest) > 0 &&
        graphObj.edges.filter((e) => {
          return (
            (e.source === edge.source && e.dest === edge.dest) ||
            (e.source === edge.dest && e.dest === edge.source)
          );
        }).length > 1
      )
        return false;
    }
  } catch (e) {
    return false;
  }

  //edge is valid
  return true;
};
