export const edgeAngle = (edge) => {
  return Math.atan2(edge.dest.x - edge.source.x, edge.dest.y - edge.source.y);
};

export const evaluateWeightPos = (axis, edge) => {
  if (axis === "x") {
    return (
      (edge.dest.x + edge.source.x) / 2 -
      23 * Math.cos(2 * Math.PI - edgeAngle(edge))
    );
  } else if (axis === "y") {
    return (
      (edge.dest.y + edge.source.y) / 2 -
      23 * Math.sin(2 * Math.PI - edgeAngle(edge))
    );
  }
};

export const decodeEdgeName = (name) => {
  const nodes = name.split("-");
  return { source: nodes[0], dest: nodes[1] };
};

export const encodeEdgeName = (source, dest) => {
  return source.name + "-" + dest.name;
};

export const edgeAlreadyExists = (graph, sourceName, destName) => {
  let edgeFound = graph.edges.find(
    (edge) =>
      (edge.source.name === sourceName && edge.dest.name === destName) ||
      (edge.source.name === destName && edge.dest.name === sourceName)
  );

  return typeof edgeFound !== "undefined";
};

export const encodeGraphReferences = (graph) => {
  graph.edges.forEach((edge) => {
    edge.source = graph.nodes.find((node) => node.name === edge.source);
    edge.dest = graph.nodes.find((node) => node.name === edge.dest);
  });
  return graph;
};

export const decodeGraphReferences = (graph) => {
  graph.edges.forEach((edge) => {
    edge.source = edge.source.name;
    edge.dest = edge.dest.name;
  });
  return graph;
};

export const sanitizeCoordinates = (graph) => {
  graph.nodes.forEach((node) => {
    node.x = Math.round(node.x);
    node.y = Math.round(node.y);
  });
  return graph;
};
