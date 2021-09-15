import {
  faRoute,
  faStepForward,
  faPalette,
  faSave,
} from "@fortawesome/free-solid-svg-icons";

const features = [
  {
    title: "Dijkstra's algorithm",
    text: "Evaluate the shortest path between two nodes",
    icon: faRoute,
  },
  {
    title: "Step-by-step solution",
    text: "Analyze dijkstra's algorithm step by step",
    icon: faStepForward,
  },
  {
    title: "Easy saving to file",
    text: "You can save and read graphs from/to file.",
    icon: faSave,
  },
  {
    title: "Change UI",
    text: "Change the graphical interface according to your style",
    icon: faPalette,
  },
];

export default features;
