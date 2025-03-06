using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Represents an overlay frame to be rendered on top of a tile.
    /// </summary>
    public class ExtraFrame
    {
        /// <summary>
        /// X-axis movement. Positive values move the frame to the right.
        /// </summary>
        public int MoveX { get; set; }

        /// <summary>
        /// Y-axis movement. Positive values move the frame downwards.
        /// </summary>
        public int MoveY { get; set; }

        /// <summary>
        /// Frame index. Values >= 0 will be rendered as overlay.
        /// </summary>
        public int Frame { get; set; }

        /// <summary>
        /// Resource group from which the overlay frame is chosen.
        /// </summary>
        public ResourceGroup ResourceGroup { get; set; }

        /// <summary>
        /// Initializes a new instance of the ExtraFrame class.
        /// </summary>
        public ExtraFrame()
        {
            MoveX = 0;
            MoveY = 0;
            Frame = 0;
            ResourceGroup = null;
        }
    }
}
