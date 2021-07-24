using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using VisualDijkstraRemake.Controllers;
using VisualDijkstraRemake.Models;

namespace VisualDijkstraRemake.Views
{
    public partial class StatesView : UserControl
    {


        public IStatesController Controller { get; set; }

        private DataTable _statesData;

        public StatesView()
        {
            InitializeComponent();


            _statesData = new DataTable();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            _statesData.Columns.Add("Name");
            _statesData.Columns.Add("Previous");
            _statesData.Columns.Add("Distance");

            dataGridView1.DataSource = _statesData;
        }


        public void setStates(List<GraphState> states)
        {
            scrollPanel1.Controls.Clear();

            for (int i = 0; i < states.Count; ++i)
            {

                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Click += new System.EventHandler(stateButton_Click);

                scrollPanel1.Controls.Add(btn);
            }
        }

        protected void stateButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            this.setState(Controller.getState(int.Parse(btn.Text) - 1));
        }

        public void setState(GraphState state)
        {
            _statesData.Clear();

            foreach (NodeState node in state.NodesStates)
            {
                DataRow row = _statesData.NewRow();

                row["Name"] = node.Name;
                row["Previous"] = node.Previous;
                row["Distance"] = node.Distance;

                _statesData.Rows.Add(row);
            }
        }


    }
}
