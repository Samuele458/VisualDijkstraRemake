using DesktopApp.Views;
using System;
using System.Collections.Generic;
using VisualDijkstraLib.Models;

namespace DesktopApp.Controllers
{

    public interface IStatesController
    {

        public GraphController GraphController { get; set; }
        void clearStates();

        void setStates(List<GraphState> states);

        void setCurrentState(GraphState state);

        GraphState getState(int index);
    }

    public class StatesController : IStatesController
    {
        private StatesView _view;
        private List<GraphState> _states;

        public GraphController GraphController { get; set; }

        public StatesView View
        {
            get { return _view; }
            set { _view = value; }
        }

        public StatesController(StatesView view, List<GraphState> states)
        {
            this._view = view;
            this._states = states;

        }

        public void clearStates()
        {

            _states = new List<GraphState>();
            _view.Clear();
        }

        public void setCurrentState(GraphState state)
        {
            GraphController.SetState(state);
        }

        public void setStates(List<GraphState> states)
        {
            _states = states;

            _view.SetStates(states);
        }

        public GraphState getState(int index)
        {
            if (index >= 0 && index < _states.Count)
            {
                return _states[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
