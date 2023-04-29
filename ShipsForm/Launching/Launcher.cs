using ShipsForm.Logic.ShipSystem.Ships;
using ShipsForm.Logic.FraghtSystem;
using ShipsForm.Logic.CargoSystem;
using ShipsForm.Logic.NodeSystem;
using ShipsForm.Timers;
using ShipsForm.Logic;

namespace ShipsForm.Launching
{
    class Launcher
    {
        public Launcher()
        {
            TimerData myTimer = new TimerData();
            NetworkNodes.InitNetwork();
            Node node1 = NetworkNodes.Network.AddNode(new SupportEntities.Point(100, 201), 5);
            Node node2 = NetworkNodes.Network.AddNode(new SupportEntities.Point(400, 500), 8);
            Node node3 = NetworkNodes.Network.AddNode(new SupportEntities.Point(1500, 500), 2);
            Dictionary<Cargo, int> requiredCargo = new Dictionary<Cargo, int>();
            requiredCargo.Add(new CargoContainer(node2), 5);
            Dictionary<Cargo, int> requiredCargo1 = new Dictionary<Cargo, int>();
            requiredCargo1.Add(new CargoContainer(node1), 5);
            Dictionary<Cargo, int> requiredCargo2 = new Dictionary<Cargo, int>();
            requiredCargo2.Add(new CargoContainer(node3), 8);
            Ship thirdShip = new CargoShip(node3);
            Ship myGreatShip = new CargoShip(node2);
            Ship MYSHIP = new CargoShip(node1);
            Manager manager = new Manager();
            manager.AssignShip(myGreatShip);
            manager.AssignShip(MYSHIP);
            manager.AssignShip(thirdShip);
            manager.AssignNode(node1);
            manager.AssignNode(node2);
            manager.AssignNode(node3);
            IFraghtStrategy voyage = new Voyage();
            Fraght fraght = new Fraght(voyage, requiredCargo, node2, node1);
            Fraght fraght2 = new Fraght(voyage, requiredCargo1, node1, node2);
            Fraght fraght3 = new Fraght(voyage, requiredCargo2, node3, node2);
        }
    }
}
