using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Models;

namespace VisualDijkstraRemake
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();



            Graph graphModel = new Graph();
            GraphController graphController = new GraphController(this.graphPictureBox, graphModel);

        }




    }
}
