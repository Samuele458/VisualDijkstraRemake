using System.Drawing;
using System.Windows.Forms;
using DesktopApp.Views;

namespace DesktopApp.Controls
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

        public void SetMainControl(GraphView view, Point autoscroll)
        {
            this.Controls.Clear();
            this.Controls.Add(view);

            this.AutoScrollPosition = autoscroll;


        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }


    }
}
