using ShipsForm.Logic.ShipSystem.Ships;
using ShipsForm.Logic.NodeSystem;
using ShipsForm.GUI;
using ShipsForm.Timers;

namespace ShipsForm.Logic
{
    internal class Manager
    {
        private List<Ship> m_ships = new List<Ship>();
        private List<GeneralNode> m_nodes = new List<GeneralNode>();
        private List<IDrawable> drawables = new List<IDrawable>();

        public Manager()
        {
            TimerData.PropertyChanged += ProccedShipsLogic;
        }
        public List<Ship> Ships
        {
            get { return m_ships; }
        }

        public List<GeneralNode> Nodes
        {
            get { return m_nodes; }
        }

        public void AssignShip(Ship newShip)
        {
            m_ships.Add(newShip);
            drawables.Add(newShip);
        }

        public void AssignNode(GeneralNode newNode)
        {
            m_nodes.Add(newNode);
            drawables.Add(newNode);
        }

        public void ProccedShipsLogic()
        {
            foreach(Ship ship in Ships)
            {
                ship.Update();
            }
            DrawModels();
        }

        public void DrawModels()
        {
            Painter.Instance.ClearShips();
            foreach (IDrawable dw in drawables)
                dw.DrawMe();
        }

    }
}
