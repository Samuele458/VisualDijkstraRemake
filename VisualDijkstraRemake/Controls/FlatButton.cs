using System.Windows.Forms;

namespace DesktopApp.Controls
{
    class FlatButton : Button
    {

        public FlatButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.TextImageRelation = TextImageRelation.ImageAboveText;
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            //base.OnKeyDown(kevent);

        }


    }
}
