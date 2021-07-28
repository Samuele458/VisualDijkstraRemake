export const edgeAngle = (edge) => {
  return Math.atan2(edge.dest.x - edge.source.x, edge.dest.y - edge.source.y);
};

export const evaluateWeightPos = (axis, edge) => {
  if (axis === "x") {
    return (
      (edge.dest.x + edge.source.x) / 2 -
      35 * Math.cos(2 * Math.PI - edgeAngle(edge))
    );
  } else if (axis === "y") {
    return (
      (edge.dest.y + edge.source.y) / 2 -
      35 * Math.sin(2 * Math.PI - edgeAngle(edge))
    );
  }
};
