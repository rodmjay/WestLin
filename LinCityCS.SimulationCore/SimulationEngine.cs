using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// The simulation engine that drives the game simulation.
    /// </summary>
    public class SimulationEngine
    {
        private World world;
        private int totalTime;

        /// <summary>
        /// Gets the world.
        /// </summary>
        public World World => world;

        /// <summary>
        /// Gets the total time elapsed in the simulation.
        /// </summary>
        public int TotalTime => totalTime;

        /// <summary>
        /// Initializes a new instance of the SimulationEngine class.
        /// </summary>
        /// <param name="world">The world to simulate.</param>
        public SimulationEngine(World world)
        {
            this.world = world;
            totalTime = 0;
        }

        /// <summary>
        /// Updates the simulation.
        /// </summary>
        public void Update()
        {
            // Update all constructions
            for (int x = 0; x < world.Width; x++)
            {
                for (int y = 0; y < world.Height; y++)
                {
                    var tile = world.GetTile(x, y);
                    if (tile.Construction != null && !tile.Construction.IsBulldozed)
                    {
                        tile.Construction.DoSimStep();
                    }
                }
            }

            // Update time
            totalTime++;
        }
    }
}
