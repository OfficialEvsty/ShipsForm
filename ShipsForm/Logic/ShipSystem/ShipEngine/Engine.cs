using ShipsForm.Data;

namespace ShipsForm.Logic.ShipSystem.ShipEngine
{
    class Engine
    {
        public float MaxSpeedInKM { get; init; }
        public float AverageSpeedInKM { get; private set; }
        public float CaravanSpeedInKM { get; private set; }
        public bool IsStartEngine;

        private float f_currentSpeed;

        public Engine()
        {
            MaxSpeedInKM = 40;
            AverageSpeedInKM = MaxSpeedInKM * 3 / 4;
            f_currentSpeed = AverageSpeedInKM;
        }

        public float Running()
        {
            if (IsStartEngine)
                return f_currentSpeed * ModelInfo.Instance.TimeTickMS * ModelInfo.Instance.MultiplyTimer / 3600;
            return 0;
        }

        public void StartEngine()
        {
            IsStartEngine = true;
        }

        public void StopEngine()
        {
            IsStartEngine = false;
        }

        public void SwitchSpeedInCaravan()
        {
            f_currentSpeed = CaravanSpeedInKM;
        }


    }
}
