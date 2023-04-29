using System;
using ShipsForm.Exceptions;
using Newtonsoft.Json;

namespace ShipsForm.Data
{
    class ModelInfo
    {
        public int TileSquare;
        public int FieldWidth;
        public int FieldHeight;
        public int TimeTickMS;
        public int MultiplyTimer;
        public int CellScale;
        static public ModelInfo? Instance;
        private ModelInfo() { }

        static public void Init()
        {
            string filename = "ModelSettings.json";
            using (StreamReader reader = new StreamReader(Application.StartupPath + filename))
            {
                string json = reader.ReadToEnd();
                if (json is null)
                    throw new JsonFileEmptyError($"File settings is Empty. You should fill \\bin\\..\\..\\ModelInfo.json");
                ModelInfo? model = JsonConvert.DeserializeObject<ModelInfo>(json);
                Instance = model;
                Console.WriteLine($"Model's settings successfully read.");
            }
        }
    }
}
