using ShipsForm.Logic.ShipSystem.ShipNavigation;
using ShipsForm.Logic.ShipSystem.ShipEngine;
using ShipsForm.Logic.ShipSystem.Behaviour;
using ShipsForm.Logic.FraghtSystem;
using ShipsForm.GUI;

namespace ShipsForm.Logic.ShipSystem.Ships
{
    abstract class Ship : IDrawable
    {
        protected static int id_counter = 0;
        public int Id { get; protected set; }
        protected Navigation m_navigationModule;
        //private BoardCargo m_boardCargo;
        protected Engine m_engine;
        protected ShipBehavior m_shipBehavior;
        protected Fraght? m_fraght;
        //list fraght
        public Fraght? Fraght
        {
            get
            {
                return m_fraght;
            }
            set
            {
                if (m_fraght != value)

                    m_fraght = value;
            }
        }
        public ShipBehavior Behavior { get { return m_shipBehavior; } }

        /*public Ship(Node nodeToSpawnShip)
        {
            //TimerData.PropertyChanged += Update;
            m_navigationModule = new Navigation();
            //m_boardCargo = new BoardCargo();
            m_engine = new Engine();
            m_shipBehavior = new ShipBehavior(this, m_engine, m_navigationModule, m_boardCargo);
            nodeToSpawnShip.ShipTryEnterInNode(this);
        }*/

        abstract public void Update();
        /*public void Update()
        {
            
        }*/

        public abstract void DrawMe();

    }
}
