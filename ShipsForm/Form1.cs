using ShipsForm.Data;
using ShipsForm.Logic.TilesSystem;
using System.Runtime.InteropServices;
using ShipsForm.Launching;
using ShipsForm.GUI;

namespace ShipsForm
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        public Form1()
        {

            InitializeComponent();
            AllocConsole();
            ModelInfo.Init();
            Database.Init();
            Field.CreateField();

            PictureBox area = new PictureBox();
            area.BackColor = Color.Transparent;
            PictureBox nodes_area = new PictureBox();
            nodes_area.BackColor = Color.Transparent;
            PictureBox ships_area = new PictureBox(); 
            ships_area.BackColor = Color.Transparent;

            /*PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            pb.Image = Image.FromFile(Application.StartupPath + @"\skins\cargo_ship.png");
            pb.BackColor = Color.Transparent;
            pb.Size = new Size(25, 75);
            area.Controls.Add(pb);*/

            Painter.Init(Field.Instance, area, nodes_area, ships_area, ModelInfo.Instance);

            this.Controls.Add(area);
            area.Controls.Add(nodes_area);
            nodes_area.Controls.Add(ships_area);
            
            
            
            Launcher launcher = new Launcher();

        }

        /*public void LoadSettingsFromJson()
        {
            string filename = "appsettings.json";
            string? dir = Path.GetFullPath(filename);
            using (StreamReader reader = new StreamReader(dir))
            {
                string json = reader.ReadToEnd();
                dynamic? array = JsonConvert.DeserializeObject(json);
                if (array == null)
                    throw new EmptyJsonError($"{filename} is empty.");
                foreach(var item in array)
                {
                    Console.WriteLine(item.Value);
                }

            }
        }*/


    }
}