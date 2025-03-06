using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Contains graphics information for rendering.
    /// </summary>
    public class GraphicsInfo
    {
        /// <summary>
        /// Texture for rendering.
        /// </summary>
        public object Texture { get; set; }

        /// <summary>
        /// Image for rendering.
        /// </summary>
        public object Image { get; set; }

        /// <summary>
        /// X-coordinate for positioning.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-coordinate for positioning.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the GraphicsInfo class.
        /// </summary>
        public GraphicsInfo()
        {
            Texture = null;
            Image = null;
            X = 0;
            Y = 0;
        }
    }

    /// <summary>
    /// Represents a group of resources for rendering and audio.
    /// </summary>
    public class ResourceGroup
    {
        /// <summary>
        /// Unique identifier for this resource group.
        /// </summary>
        public string ResourceID { get; private set; }

        /// <summary>
        /// Indicates whether images have been loaded.
        /// </summary>
        public bool ImagesLoaded { get; set; }

        /// <summary>
        /// Indicates whether sounds have been loaded.
        /// </summary>
        public bool SoundsLoaded { get; set; }

        /// <summary>
        /// Indicates whether this resource group represents a vehicle.
        /// Vehicles are always rendered on the upper left tile.
        /// </summary>
        public bool IsVehicle { get; set; }

        /// <summary>
        /// Collection of sound chunks.
        /// </summary>
        public List<object> Chunks { get; private set; }

        /// <summary>
        /// Collection of graphics information.
        /// </summary>
        public List<GraphicsInfo> GraphicsInfoVector { get; private set; }

        /// <summary>
        /// Dictionary mapping resource IDs to resource groups.
        /// </summary>
        public static Dictionary<string, ResourceGroup> ResMap { get; private set; } = new Dictionary<string, ResourceGroup>();

        /// <summary>
        /// Initializes a new instance of the ResourceGroup class.
        /// </summary>
        /// <param name="tag">Unique identifier for this resource group.</param>
        public ResourceGroup(string tag)
        {
            ResourceID = tag;
            GraphicsInfoVector = new List<GraphicsInfo>();
            Chunks = new List<object>();
            ImagesLoaded = false;
            SoundsLoaded = false;
            IsVehicle = false;

            if (ResMap.ContainsKey(tag))
            {
                Console.WriteLine($"Rejecting {tag} as another ResourceGroup");
            }
            else
            {
                ResMap[tag] = this;
            }
        }

        /// <summary>
        /// Grows the graphics info vector by adding a new element.
        /// </summary>
        public void GrowGraphicsInfoVector()
        {
            GraphicsInfoVector.Add(new GraphicsInfo());
        }
    }
}
