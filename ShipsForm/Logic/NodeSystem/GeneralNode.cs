using ShipsForm.Logic.TilesSystem;
using ShipsForm.GUI;

namespace ShipsForm.Logic.NodeSystem
{
    abstract class GeneralNode : IDrawable
    {
        protected SupportEntities.Point? m_point = null;
        protected Tile m_tileCrds;
        public SupportEntities.Point GetCoords { get { return m_point; } }

        public abstract void DrawMe();
    }
}
