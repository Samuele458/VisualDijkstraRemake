namespace VisualDijkstraRemake.Models
{

    public enum GridType
    {
        None,
        Light,
        Dark,
        Slim
    }

    public class GraphOptions
    {

        private double _zoom;
        private GridType _gridType;

        public double Zoom
        {
            get { return _zoom; }
            set
            {
                if (value > 0 && value <= 30)
                {
                    _zoom = value;
                }
            }
        }

        public GridType GridType
        {
            get { return _gridType; }
            set { _gridType = value; }
        }


        public GraphOptions()
        {
            Zoom = 10;
            GridType = GridType.Light;
        }



    }
}
