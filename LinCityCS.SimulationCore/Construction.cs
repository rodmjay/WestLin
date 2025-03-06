using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Base class for all constructions in the game.
    /// </summary>
    public abstract class Construction
    {
        private Dictionary<Commodity, int> commodityStore = new Dictionary<Commodity, int>();
        private Dictionary<Commodity, int> commodityMaxConsumption = new Dictionary<Commodity, int>();
        private Dictionary<Commodity, int> commodityMaxProduction = new Dictionary<Commodity, int>();

        /// <summary>
        /// Gets or sets the construction group.
        /// </summary>
        public ConstructionGroup? Group { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the construction is bulldozed.
        /// </summary>
        public bool IsBulldozed { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate of the construction.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the construction.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the frame of the construction.
        /// </summary>
        public int Frame { get; set; }

        /// <summary>
        /// Gets or sets the pollution level of the construction.
        /// </summary>
        public int Pollution { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the construction is operational.
        /// </summary>
        public bool IsOperational { get; set; }

        /// <summary>
        /// Gets or sets the power output of the construction.
        /// </summary>
        public int PowerOutput { get; set; }

        /// <summary>
        /// Gets the commodity store.
        /// </summary>
        public Dictionary<Commodity, int> CommodityStore => commodityStore;

        /// <summary>
        /// Gets the commodity maximum consumption.
        /// </summary>
        public Dictionary<Commodity, int> CommodityMaxConsumption => commodityMaxConsumption;

        /// <summary>
        /// Gets the commodity maximum production.
        /// </summary>
        public Dictionary<Commodity, int> CommodityMaxProduction => commodityMaxProduction;

        /// <summary>
        /// Initializes a new instance of the Construction class.
        /// </summary>
        protected Construction()
        {
            Group = null;
            IsBulldozed = false;
            X = 0;
            Y = 0;
            Frame = 0;
            Pollution = 0;
            IsOperational = false;
            PowerOutput = 0;

            // Initialize commodity dictionaries
            foreach (Commodity commodity in Enum.GetValues(typeof(Commodity)))
            {
                commodityStore[commodity] = 0;
                commodityMaxConsumption[commodity] = 0;
                commodityMaxProduction[commodity] = 0;
            }
        }

        /// <summary>
        /// Performs a simulation step for the construction.
        /// </summary>
        public abstract void DoSimStep();

        /// <summary>
        /// Destroys the construction.
        /// </summary>
        public virtual void Destroy()
        {
            IsBulldozed = true;
        }

        /// <summary>
        /// Reports information about the construction.
        /// </summary>
        /// <returns>A string containing information about the construction.</returns>
        public virtual string Report()
        {
            return $"Construction at ({X}, {Y}), Group: {Group?.Name ?? "None"}, Bulldozed: {IsBulldozed}";
        }
    }
}
