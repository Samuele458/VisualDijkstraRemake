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
            this.Size = new System.Drawing.Size(330, 301);
            this.TabIndex = 0;

        }

        public void setMainControl(GraphView view)
        {
            this.Controls.Clear();
            this.Controls.Add(view);

            this.AutoScrollPosition = new System.Drawing.Point(5000, 5000);


        }


    }
}
