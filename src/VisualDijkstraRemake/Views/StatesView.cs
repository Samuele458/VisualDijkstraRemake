using DesktopApp.Controllers;
using DesktopApp.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VisualDijkstraLib.Models;

namespace DesktopApp.Views
{
    public partial class StatesView : UserControl
    {


        public IStatesController Controller { get; set; }

        private readonly DataTable _statesData;

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

        public void SetStates(List<GraphState> states)
        {
            scrollPanel1.Controls.Clear();

            for (int i = 0; i < states.Count; ++i)
            {

                Button btn = new FlatButton();
                btn.Text = (i + 1).ToString();
                btn.Click += new System.EventHandler(stateButton_Click);
                btn.Height = 40;
                btn.Width = 60;
                btn.BackColor = Color.FromArgb(244, 244, 244);
                btn.Margin = new Padding(10);
                btn.Font = new Font("Segoe UI", 14);


                scrollPanel1.Controls.Add(btn);
            }

            if (states.Count > 0)
            {
                SetState(states[states.Count - 1]);
            }
        }

        protected void stateButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            this.SetState(Controller.getState(int.Parse(btn.Text) - 1));

        }

        public void SetState(GraphState state)
        {
            _statesData.Clear();

            foreach (NodeState node in state.NodesStates)
            {
                DataRow row = _statesData.NewRow();

                row["Name"] = node.Name;
                row["Previous"] = node.Previous.Equals("DEFAULT_PREVIOUS_NODE") ? "-" : node.Previous;
                row["Distance"] = node.Distance == 999999999 ? "INF" : node.Distance;

                _statesData.Rows.Add(row);
            }

            Controller.setCurrentState(state);
        }

        public void Clear()
        {
            _statesData.Clear();

            for (int i = scrollPanel1.Controls.Count - 1; i >= 0; --i)
            {
                scrollPanel1.Controls.RemoveAt(i);
            }
        }


    }
}
