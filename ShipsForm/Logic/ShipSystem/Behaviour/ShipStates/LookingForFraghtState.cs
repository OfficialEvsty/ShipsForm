using ShipsForm.Logic.ShipSystem.Behaviour;

namespace ShipsForm.Logic.ShipSystem.Behaviour.ShipStates
{
    class LookingForFraghtState : State
    {
        public override void OnEntry(ShipBehavior sb)
        {
            Console.WriteLine($"Корабль {sb.Ship.Id} успешно поменял свое состояние на " + sb.State);
            //sb.LookingForFraght(sb.Navigation.FromNode);

        }

        public override void OnExit(ShipBehavior sb)
        {
            Console.WriteLine($"Корабль {sb.Ship.Id} успешно вышел из состояния" + sb.State);
            if (sb.Navigation.FromNode != null && sb.GetFraghtInfo() != null)
                sb.GetFraghtInfo()?.FromNode.LoadingSection.ContractAvailableCargo(sb.GetFraghtInfo());
        }

        public override State NextState()
        {
            return new ShipWaitingForLoadingState();
        }
    }
}
