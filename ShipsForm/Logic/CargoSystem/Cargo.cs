using ShipsForm.Logic.NodeSystem;
using ShipsForm.Logic.ShipSystem.Ships;
using ShipsForm.SupportEntities;


namespace ShipsForm.Logic.CargoSystem
{
    class Cargo
    {
        private SupportEntities.Point? m_crds;

        public SupportEntities.Point Coords { get { return m_crds; } }

        public void ConnectToShip(Ship ship)
        {

        }

        public Cargo(Node nodeToSpawn)
        {
            m_crds = nodeToSpawn.GetCoords;
        }

        public Cargo(SupportEntities.Point pointToSpawn)
        {
            m_crds = pointToSpawn;
        }
    }

    class CargoContainer : Cargo
    {
        public CargoContainer(Node node) : base(node) { }
        public CargoContainer(SupportEntities.Point point) : base(point) { }
    }

    class CargoTanker : Cargo
    {
        public CargoTanker(Node node) : base(node) { }
        public CargoTanker(SupportEntities.Point point) : base(point) { }
    }

    interface ICargoFactory
    {
        CargoContainer CreateContainer(SupportEntities.Point p);
        CargoTanker CreateTanker(SupportEntities.Point p);
    }

    class CargoFactory : ICargoFactory
    {
        public CargoContainer CreateContainer(SupportEntities.Point pointToSpawn)
        {
            return new CargoContainer(pointToSpawn);
        }
        public CargoTanker CreateTanker(SupportEntities.Point pointToSpawn)
        {
            return new CargoTanker(pointToSpawn);
        }
    }
}
