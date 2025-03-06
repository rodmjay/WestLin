using System;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// The main game engine class that manages the game state and updates.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// Gets the simulation engine.
        /// </summary>
        public SimulationEngine SimulationEngine { get; private set; }

        /// <summary>
        /// Gets the world.
        /// </summary>
        public World World { get; private set; }

        /// <summary>
        /// Gets the total time elapsed in the game.
        /// </summary>
        public static int TotalTime { get; private set; }

        /// <summary>
        /// Gets the construction manager.
        /// </summary>
        public ConstructionManager ConstructionManager { get; private set; }

        /// <summary>
        /// Gets the economy.
        /// </summary>
        public Economy Economy { get; private set; }

        /// <summary>
        /// Gets the statistics.
        /// </summary>
        public Statistics Statistics { get; private set; }

        /// <summary>
        /// Initializes a new instance of the GameEngine class.
        /// </summary>
        /// <param name="width">The width of the world.</param>
        /// <param name="height">The height of the world.</param>
        public GameEngine(int width, int height)
        {
            World = new World(width, height);
            SimulationEngine = new SimulationEngine(World);
            ConstructionManager = new ConstructionManager(World);
            Economy = new Economy();
            Statistics = new Statistics();
            TotalTime = 0;
        }

        /// <summary>
        /// Updates the game state.
        /// </summary>
        public void Update()
        {
            SimulationEngine.Update();
            TotalTime++;
        }

        /// <summary>
        /// Resets the game state.
        /// </summary>
        public void Reset()
        {
            World = new World(World.Width, World.Height);
            SimulationEngine = new SimulationEngine(World);
            ConstructionManager = new ConstructionManager(World);
            Economy = new Economy();
            Statistics = new Statistics();
            TotalTime = 0;
        }
    }
}
