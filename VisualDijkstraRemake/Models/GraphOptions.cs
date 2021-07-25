using System;

namespace VisualDijkstraRemake.Models
{


    /// <summary>
    ///  Types of available grids
    /// </summary>
    public enum GridType
    {
        None,
        Light,
        Dark,
        Slim
    }


    /// <summary>
    ///  handling of graph style options
    /// </summary>
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


        /// <summary>
        ///  Save current options in session (handled by Settings)
        /// </summary>
        public void Save()
        {
            Properties.Settings.Default.Save();
        }



    }
}
