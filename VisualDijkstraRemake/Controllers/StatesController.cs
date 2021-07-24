using System;
using System.Collections.Generic;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Views;

namespace VisualDijkstraRemake.Controllers
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
        }

        public void setCurrentState(GraphState state)
        {
            throw new System.NotImplementedException();
        }

        public void setStates(List<GraphState> states)
        {
            _states = states;

            _view.setStates(states);
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
