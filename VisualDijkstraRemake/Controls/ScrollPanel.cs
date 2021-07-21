using System.Windows.Forms;
using VisualDijkstraRemake.Views;

namespace VisualDijkstraRemake.Controls
{
    public class ScrollPanel : FlowLayoutPanel
    {


        public ScrollPanel()
        {
            this.AutoScroll = true;

            this.Location = new System.Drawing.Point(40, 91);
            this.Name = "ScrollPanel";
            this.Size = new System.Drawing.Size(330, 301);
            this.TabIndex = 0;

        }

        public void setGraphView(GraphView view)
        {
            this.Controls.Clear();
            this.Controls.Add(view);

            this.AutoScrollPosition = new System.Drawing.Point(5000, 5000);

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            System.Diagnostics.Debug.WriteLine("CLICK");
        }
    }
}
