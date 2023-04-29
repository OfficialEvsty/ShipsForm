using ShipsForm.Data;

namespace ShipsForm.Logic.TilesSystem
{
    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Square { get { if (ModelInfo.Instance is not null) return ModelInfo.Instance.TileSquare; else return 100; } }
        public float Width { get { return (float)Math.Sqrt(Square); } }
        public int Cost { get; init; }
        public float Distance { get; private set; }
        public float CostDistance { get { return Cost + Distance; } }
        public Tile? Parent { get; init; }

        public static Tile? GetTileCoords(SupportEntities.Point point)
        {
            if (point.X > 0 && point.Y > 0)
                return new Tile() { X = (int)point.X / ModelInfo.Instance.TileSquare, Y = (int)point.Y / ModelInfo.Instance.TileSquare };
            return null;
        }

        public void SetDistance(int targetX, int targetY)
        {
            Distance = Math.Abs(targetX - X) * Width + Math.Abs(targetY - Y) * Width;
        }

    }
}
