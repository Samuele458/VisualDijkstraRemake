using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;

namespace VisualDijkstraRemake.Views
{
    class GraphView : PictureBox
    {
        GraphController _controller;

        public GraphView()
        {
            this.BackColor = Color.Red;

        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            Debug.WriteLine("DoubleClicked");
        }
    }
}
