using System.Collections.Generic;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Views;

namespace VisualDijkstraRemake.Controllers
{

    public interface IStatesController
    {
        void clearStates();

        void setStates(List<GraphState> states);

        void setCurrentState(GraphState state);
    }

    class StatesController : IStatesController
    {
        private StatesView _view;
        private List<GraphState> _states;

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

            throw new System.NotImplementedException();
        }

        public void setCurrentState(GraphState state)
        {
            throw new System.NotImplementedException();
        }

        public void setStates(List<GraphState> states)
        {
            throw new System.NotImplementedException();
        }
    }
}
