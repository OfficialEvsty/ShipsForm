﻿using ShipsForm.SupportEntities.PatternObserver.Observers;
using ShipsForm.Logic.ShipSystem.Behaviour.ShipStates;
using ShipsForm.Logic.ShipSystem.ShipCargoCompartment;
using ShipsForm.Logic.ShipSystem.ShipNavigation;
using ShipsForm.SupportEntities.PatternObserver;
using ShipsForm.Logic.ShipSystem.ShipEngine;
using ShipsForm.Logic.ShipSystem.Ships;
using ShipsForm.Logic.FraghtSystem;
using ShipsForm.Logic.NodeSystem;

namespace ShipsForm.Logic.ShipSystem.Behaviour
{
    class ShipBehavior : IEventObserver<Fraght>
    {
        private Ship m_ship;
        private Engine m_engine;
        private Navigation m_navigationModule;
        private BoardCargo m_boardCargo;

        public Ship Ship { get { return m_ship; } }
        public State State { get; set; }
        public BoardCargo BoardCargo { get { return m_boardCargo; } }
        public Navigation Navigation { get { return m_navigationModule; } }
        public Engine Engine { get { return m_engine; } }
        public ShipBehavior(Ship ownShip, Engine eng, Navigation nav, BoardCargo bg)
        {
            m_ship = ownShip;
            m_engine = eng;
            m_navigationModule = nav;
            m_boardCargo = bg;
            State = new ShipWandersState();
            EventObservable.AddEventObserver(this);
        }

        public Fraght? GetFraghtInfo()
        {
            if (m_ship.Fraght != null)
                return m_ship.Fraght;
            return null;
        }

        public void SetStartNode(Node nd)
        {
            m_navigationModule.FromNode = nd;
        }

        public void GoNextState()
        {
            State.OnExit(this);
            State = State.NextState();
            State.OnEntry(this);
        }

        public bool LookingForFraght(Node fromNode)
        {
            if (m_ship.Fraght != null || State is not LookingForFraghtState)
                return false;
            Fraght selectedFraght = FraghtMarket.Fraghts.FirstOrDefault(f => f.FromNode == fromNode);
            if (selectedFraght != null)
            {
                m_ship.Fraght = selectedFraght;
                selectedFraght.Contract(m_ship);
                GoNextState();
                return true;
            }
            return false;
        }

        public void ShipOnLoading()
        {

        }

        public void ShipArriveToNode()
        {

        }

        public void Update(Fraght ev)
        {
            LookingForFraght(m_navigationModule.FromNode);
        }
    }
}
