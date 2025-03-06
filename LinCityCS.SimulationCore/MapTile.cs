using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Represents a tile in the game map.
    /// </summary>
    public class MapTile
    {
        /// <summary>
        /// Gets or sets the X coordinate of the tile.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the tile.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the construction on this tile.
        /// </summary>
        public Construction? Construction { get; set; }

        /// <summary>
        /// Gets or sets the ground type of this tile.
        /// </summary>
        public Ground Ground { get; set; }

        /// <summary>
        /// Gets or sets the pollution level of this tile.
        /// </summary>
        public int Pollution { get; set; }

        /// <summary>
        /// Gets or sets the altitude of this tile.
        /// </summary>
        public int Altitude { get; set; }

        /// <summary>
        /// Gets or sets the water level of this tile.
        /// </summary>
        public int WaterLevel { get; set; }

        /// <summary>
        /// Gets or sets the fire level of this tile.
        /// </summary>
        public int FireLevel { get; set; }

        /// <summary>
        /// Gets or sets the traffic level of this tile.
        /// </summary>
        public int TrafficLevel { get; set; }

        /// <summary>
        /// Gets or sets the crime level of this tile.
        /// </summary>
        public int CrimeLevel { get; set; }

        /// <summary>
        /// Gets or sets the land value of this tile.
        /// </summary>
        public int LandValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the MapTile class.
        /// </summary>
        /// <param name="x">The X coordinate of the tile.</param>
        /// <param name="y">The Y coordinate of the tile.</param>
        public MapTile(int x, int y)
        {
            X = x;
            Y = y;
            Construction = null;
            Ground = Ground.Grass;
            Pollution = 0;
            Altitude = 0;
            WaterLevel = 0;
            FireLevel = 0;
            TrafficLevel = 0;
            CrimeLevel = 0;
            LandValue = 0;
        }

        /// <summary>
        /// Adds pollution to this tile.
        /// </summary>
        /// <param name="amount">The amount of pollution to add.</param>
        public void AddPollution(int amount)
        {
            Pollution += amount;
        }

        /// <summary>
        /// Gets the type of the tile (ground or construction).
        /// </summary>
        /// <returns>A string representing the type of the tile.</returns>
        public string GetTileType()
        {
            if (Construction != null && !Construction.IsBulldozed)
            {
                return "Construction";
            }
            else
            {
                return "Ground";
            }
        }
    }
}
