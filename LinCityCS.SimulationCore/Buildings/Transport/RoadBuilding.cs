using System;

namespace LinCityCS.SimulationCore.Buildings.Transport
{
    /// <summary>
    /// Represents a road building.
    /// </summary>
    public class RoadBuilding : Construction
    {
        private int capacity;

        /// <summary>
        /// Gets or sets a value indicating whether the road is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the RoadBuilding class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public RoadBuilding(ConstructionGroup group)
        {
            Group = group;
            IsOperational = false;
            capacity = TransportConstants.RoadGoodsCapacity;

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.Goods] = capacity;
            CommodityMaxProduction[Commodity.Goods] = capacity;
        }

        /// <summary>
        /// Performs a simulation step for the road.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Roads are always operational when not bulldozed
            IsOperational = true;

            // Roads don't consume or produce anything, they just transport
            // The actual transport is handled by the simulation engine
        }

        /// <summary>
        /// Reports information about the road.
        /// </summary>
        /// <returns>A string containing information about the road.</returns>
        public override string Report()
        {
            return $"Road at ({X}, {Y}), Operational: {IsOperational}, Capacity: {capacity}";
        }
    }
}
