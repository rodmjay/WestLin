using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore.Buildings.Market
{
    /// <summary>
    /// Represents a market building.
    /// </summary>
    public class MarketBuilding : Construction
    {
        private Dictionary<Commodity, int> capacities = new Dictionary<Commodity, int>();

        /// <summary>
        /// Initializes a new instance of the MarketBuilding class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public MarketBuilding(ConstructionGroup group)
        {
            Group = group;

            // Initialize capacities
            capacities[Commodity.Food] = MarketConstants.MarketFoodCapacity;
            capacities[Commodity.Goods] = MarketConstants.MarketGoodsCapacity;
            capacities[Commodity.Coal] = MarketConstants.MarketCoalCapacity;
            capacities[Commodity.Ore] = MarketConstants.MarketOreCapacity;
            capacities[Commodity.Steel] = MarketConstants.MarketSteelCapacity;

            // Initialize commodity max consumption and production
            foreach (var commodity in capacities.Keys)
            {
                CommodityMaxConsumption[commodity] = capacities[commodity];
                CommodityMaxProduction[commodity] = capacities[commodity];
            }
        }

        /// <summary>
        /// Performs a simulation step for the market.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Markets don't consume or produce anything, they just distribute
            // The actual distribution is handled by the simulation engine
        }

        /// <summary>
        /// Reports information about the market.
        /// </summary>
        /// <returns>A string containing information about the market.</returns>
        public override string Report()
        {
            return $"Market at ({X}, {Y})";
        }
    }
}
