using ShipsForm.Logic.ShipSystem.ShipCargoCompartment;
using ShipsForm.Logic.ShipSystem.ShipNavigation;
using ShipsForm.Logic.ShipSystem.ShipEngine;
using ShipsForm.Logic.ShipSystem.Behaviour;
using ShipsForm.Logic.TilesSystem;
using ShipsForm.Logic.NodeSystem;
using ShipsForm.Timers;
using ShipsForm.GUI;

namespace ShipsForm.Logic.ShipSystem.Ships
{
    class CargoShip : Ship
    {
        protected BoardCargo m_boardCargo;

        public CargoShip(Node nodeToSpawnShip)
        {
            id_counter += 1;
            Id = id_counter;
            m_navigationModule = new Navigation();
            m_boardCargo = new BoardCargo();
            m_engine = new Engine();
            m_shipBehavior = new ShipBehavior(this, m_engine, m_navigationModule, m_boardCargo);
            nodeToSpawnShip.ShipTryEnterInNode(this);
        }

        public override void Update()
        {
            if (m_navigationModule != null && m_engine != null)
            {
                m_navigationModule.ObserveMoving(m_engine.Running());
                Console.WriteLine(m_navigationModule.DistanceTraveledOnCurrentTile);
            }

            if (m_navigationModule.CurrentTile is null)
                return;
        }

        public override void DrawMe()
        {
            Tile currentTile = m_navigationModule.CurrentTile;
            double rotation = m_navigationModule.CurrentRotation;
            Image shipImage = Image.FromFile(Application.StartupPath + @"\skins\cargo_ship.png");
            if (Painter.Instance is not null)
                Painter.Instance.DrawShip(currentTile, rotation, shipImage);
        }
    }
}
