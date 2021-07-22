using System.Windows.Forms;

namespace VisualDijkstraRemake.Controls
{
    class FlatButton : Button
    {

        public FlatButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.TextImageRelation = TextImageRelation.ImageAboveText;
        }


    }
}
