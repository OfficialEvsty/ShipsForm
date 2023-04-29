using System.Drawing;
using System.Drawing.Drawing2D;
using ShipsForm.Data;
using ShipsForm.Logic.TilesSystem;

namespace ShipsForm.GUI
{
    internal class Painter
    {
        private int i_lineWidth = 1;
        private PictureBox m_map_box;
        private PictureBox m_ships_box;
        private PictureBox m_nodes_box;

        private float i_cellScale = 1;
        private Field m_field;
        private Size m_pboxes_size = new Size(1600, 900);

        private Brush brush;
        private Pen pen;

        public static Painter? Instance;
        public float CellScale
        {
            get { return i_cellScale; }
            set { i_cellScale = value; }
        }

        public int Width
        {
            get { return i_lineWidth; }
            set { i_lineWidth = value; }
        }

        private Color m_color = Color.Blue;

        public Color Color
        {
            get { return m_color = Color.Blue; }
            set { m_color = value; }
        }

        private Painter(Field field, PictureBox map_box, PictureBox nodes_box, PictureBox ships_box, ModelInfo? sett = null)
        {
            m_field = field;
            m_map_box = map_box;
            m_nodes_box = nodes_box;
            m_ships_box = ships_box;

            brush = new SolidBrush(m_color);
            pen = new Pen(brush);            
            if (sett != null)
            {
                //put code here later
                Width = (int)Math.Sqrt(sett.TileSquare);
                CellScale = sett.CellScale;
            }
            CreatePBoxes();
        }

        public static void Init(Field field, PictureBox map, PictureBox nodes, PictureBox ships, ModelInfo? mf = null)
        {
            if (Instance != null)
                return;
            else
                Instance = new Painter(field, map, nodes, ships, mf);
        }

        public void CreatePBoxes()
        {
            m_nodes_box.Size = m_pboxes_size;
            Bitmap nodes_img = new Bitmap(m_pboxes_size.Width, m_pboxes_size.Height);
            m_nodes_box.Image = nodes_img;
            m_ships_box.Size = m_pboxes_size;
            Bitmap ships_img = new Bitmap(m_pboxes_size.Width, m_pboxes_size.Height);
            m_ships_box.Image = ships_img;
            DrawCells();
        }

        public void DrawCells()
        {
            m_map_box.Size = new Size(1600, 900);
            Bitmap map_img = new Bitmap(1600, 900);
            Graphics graph = Graphics.FromImage(map_img);
            List<string> map = m_field.Map;
            for (int i = 0; i < map.Count; i++)
                for(int j = 0; j < map[i].Length; j++)
                {
                    Rectangle cell_area = new Rectangle((int)(i * Width * CellScale), (int)(j * Width * CellScale), (int)(Width * CellScale), (int)(Width * CellScale));
                    graph.DrawRectangle(pen, cell_area);
                }
            m_map_box.Image = map_img;
            m_map_box.BackColor = Color.Transparent;
        }

        public void ClearShips()
        {
            m_ships_box.Image = new Bitmap(m_pboxes_size.Width, m_pboxes_size.Height);
        }

        public void DrawShip(Tile currentTile, double rotation, Image shipSkin)
        {
            if (currentTile is null)
                return;
            Size shipSize = new Size(50, 50);
            int modifier = Width * (int)CellScale;
            int padding = Width * (int)CellScale / 2;
            int pX = padding - shipSize.Width / 2;
            int pY = padding - shipSize.Height / 2;
            Point positionToDrawAShip = new Point(currentTile.X * modifier + pX, currentTile.Y * modifier + pY);
            Image sizedImg = ChangeSizeImage(shipSkin, shipSize);
            Image rotatedImg = RotateImage(sizedImg, rotation);
            
            m_ships_box.Invoke(delegate 
            {
                Image ships_area_img = m_ships_box.Image;
                Graphics g = Graphics.FromImage(ships_area_img);
                g.DrawImage(rotatedImg, positionToDrawAShip);
                m_ships_box.Image = ships_area_img;
            });
        }

        public void DrawCargoNode(SupportEntities.Point pos, Image nodeSkin)
        {
            Size nodeSize = new Size(20, 20);
            int modifier = Width * (int)CellScale;
            int padding = Width * (int)CellScale / 2;
            int pX = padding - nodeSize.Width / 2;
            int pY = padding - nodeSize.Height / 2;
            Point positionToDrawANode = new Point((int)pos.X + pX, (int)pos.Y + pY);
            Image sizedImg = ChangeSizeImage(nodeSkin, nodeSize);

            m_nodes_box.Invoke(delegate
            {
                Image nodes_area_img = m_nodes_box.Image;
                Graphics g = Graphics.FromImage(nodes_area_img);
                g.DrawImage(sizedImg, positionToDrawANode);
                m_nodes_box.Image = nodes_area_img;
            });
        }

        public static Image ChangeSizeImage(Image img, Size sz)
        {
            Bitmap b1 = new Bitmap(img);
            Bitmap b2 = new Bitmap(b1, sz);
            return b2;
        }

        public static Image RotateImage(Image img, double rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform((float)rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new System.Drawing.Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}
