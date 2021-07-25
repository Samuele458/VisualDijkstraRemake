using System;

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
                    Properties.Settings.Default.Zoom = value;
                }
            }
        }

        public GridType GridType
        {
            get { return _gridType; }
            set
            {
                _gridType = value;
                Properties.Settings.Default.Grid = value.ToString();
            }
        }


        public GraphOptions()
        {
            GridType = (GridType)Enum.Parse(typeof(GridType), Properties.Settings.Default.Grid, true);
            Zoom = Properties.Settings.Default.Zoom;

        }

        public void Save()
        {
            Properties.Settings.Default.Save();
        }



    }
}
