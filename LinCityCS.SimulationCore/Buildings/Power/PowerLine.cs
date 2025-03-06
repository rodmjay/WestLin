using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a power line that transports high voltage electricity.
    /// </summary>
    public class PowerLine : Construction
    {
        private int capacity;

        /// <summary>
        /// Gets or sets a value indicating whether the power line is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the PowerLine class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public PowerLine(ConstructionGroup group)
        {
            Group = group;
            IsOperational = false;
            capacity = PowerConstants.PowerLineCapacity;

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.HiVolt] = capacity;
            CommodityMaxProduction[Commodity.HiVolt] = capacity;
        }

        /// <summary>
        /// Performs a simulation step for the power line.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Power lines are always operational when not bulldozed
            IsOperational = true;

            // Power lines don't consume or produce anything, they just transport
            // The actual transport is handled by the simulation engine
        }

        /// <summary>
        /// Reports information about the power line.
        /// </summary>
        /// <returns>A string containing information about the power line.</returns>
        public override string Report()
        {
            return $"Power Line at ({X}, {Y}), Operational: {IsOperational}, Capacity: {capacity}";
        }
    }
}
