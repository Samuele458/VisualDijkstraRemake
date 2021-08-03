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
