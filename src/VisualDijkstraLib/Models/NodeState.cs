namespace VisualDijkstraLib.Models
{
    /// <summary>
    ///  Handles a node step, used to represents Dijkstra's algorithm step-by-step
    /// </summary>
    public class NodeState
    {
        public const int INF = 999999999;

        public string Name { get; set; }

        public string Previous { get; set; }

        public int Distance { get; set; }

        public bool Processed { get; set; }


        /// <summary>
        ///  NodeState constructor
        /// </summary>
        /// <param name="name">Node name</param>
        /// <param name="distance">Node distance</param>
        /// <param name="previous">Previous node name</param>
        /// <param name="processed">State to set (true if processed, false otherwise)</param>
        public NodeState(
                    string name = "DEFAULT_NODE",
                    int distance = INF,
                    string previous = "DEFAULT_PREVIOUS_NODE",
                    bool processed = false)
        {
            Name = name;
            Distance = distance;
            Previous = previous;
            Processed = processed;
        }

        /// <summary>
        ///  Log NodeState to debug console
        /// </summary>
        public void LogNodeState()
        {
            System.Diagnostics.Debug.WriteLine("Node: " + Name + " Previous: " + Previous + " Distance: " + Distance + " Processed: " + Processed);
        }
    }


}
