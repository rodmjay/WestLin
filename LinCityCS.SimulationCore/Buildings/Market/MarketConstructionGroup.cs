using System;

namespace LinCityCS.SimulationCore.Buildings.Market
{
    /// <summary>
    /// Represents a construction group for markets.
    /// </summary>
    public class MarketConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the MarketConstructionGroup class.
        /// </summary>
        /// <param name="name">The name of the construction group.</param>
        /// <param name="noCredit">Whether the construction group requires credit.</param>
        /// <param name="group">The group number.</param>
        /// <param name="size">The size of the construction.</param>
        /// <param name="colour">The color of the construction.</param>
        /// <param name="costMul">The cost multiplier of the construction.</param>
        /// <param name="bulCost">The bulldoze cost of the construction.</param>
        /// <param name="fireChance">The fire chance of the construction.</param>
        /// <param name="cost">The cost of the construction.</param>
        /// <param name="tech">The tech level required for the construction.</param>
        /// <param name="range">The range of the construction.</param>
        public MarketConstructionGroup(
            string name,
            bool noCredit,
            int group,
            int size,
            int colour,
            int costMul,
            int bulCost,
            int fireChance,
            int cost,
            int tech,
            int range)
            : base(name, noCredit, group, size, colour, costMul, bulCost, fireChance, cost, tech, range, 0)
        {
            // Set commodity rules
            CommodityRuleCount[Commodity.Food].Take = true;
            CommodityRuleCount[Commodity.Food].Give = true;
            CommodityRuleCount[Commodity.Food].MaxLoad = 100 * MarketConstants.MarketFoodCapacity;
            
            CommodityRuleCount[Commodity.Goods].Take = true;
            CommodityRuleCount[Commodity.Goods].Give = true;
            CommodityRuleCount[Commodity.Goods].MaxLoad = 100 * MarketConstants.MarketGoodsCapacity;
            
            CommodityRuleCount[Commodity.Coal].Take = true;
            CommodityRuleCount[Commodity.Coal].Give = true;
            CommodityRuleCount[Commodity.Coal].MaxLoad = 100 * MarketConstants.MarketCoalCapacity;
            
            CommodityRuleCount[Commodity.Ore].Take = true;
            CommodityRuleCount[Commodity.Ore].Give = true;
            CommodityRuleCount[Commodity.Ore].MaxLoad = 100 * MarketConstants.MarketOreCapacity;
            
            CommodityRuleCount[Commodity.Steel].Take = true;
            CommodityRuleCount[Commodity.Steel].Give = true;
            CommodityRuleCount[Commodity.Steel].MaxLoad = 100 * MarketConstants.MarketSteelCapacity;
        }

        /// <summary>
        /// Creates a new market construction.
        /// </summary>
        /// <returns>A new market construction.</returns>
        public override Construction CreateConstruction()
        {
            return new MarketBuilding(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of market construction groups.
    /// </summary>
    public static partial class MarketConstructionGroups
    {
        /// <summary>
        /// Market construction group.
        /// </summary>
        public static readonly MarketConstructionGroup Market = new MarketConstructionGroup(
            "Market",
            false,
            1, // Group number
            MarketConstants.GroupMarketSize,
            MarketConstants.GroupMarketColour,
            MarketConstants.GroupMarketCostMul,
            MarketConstants.GroupMarketBulCost,
            MarketConstants.GroupMarketFirec,
            MarketConstants.GroupMarketCost,
            MarketConstants.GroupMarketTech,
            MarketConstants.GroupMarketRange
        );
    }
}
