namespace VisualDijkstraRemake.Models
{
    public class NodeState
    {
        public const int INF = 999999999;

        public string Name { get; set; }

        public string Previous { get; set; }

        public int Distance { get; set; }

        public bool Processed { get; set; }


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

        public void logNodeState()
        {
            System.Diagnostics.Debug.WriteLine("Node: " + Name + " Previous: " + Previous + " Distance: " + Distance + " Processed: " + Processed);
        }
    }


}
