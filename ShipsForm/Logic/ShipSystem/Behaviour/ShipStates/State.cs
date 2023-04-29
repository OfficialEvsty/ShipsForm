using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsForm.Logic.ShipSystem.Behaviour.ShipStates
{
    abstract class State
    {
        public delegate void StateChangedEventHadler();
        public abstract void OnEntry(ShipBehavior sb);
        public abstract void OnExit(ShipBehavior sb);
        public abstract State NextState();
    }
}
