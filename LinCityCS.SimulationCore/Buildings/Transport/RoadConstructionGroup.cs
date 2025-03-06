using System;

namespace LinCityCS.SimulationCore.Buildings.Transport
{
    /// <summary>
    /// Represents a construction group for roads.
    /// </summary>
    public class RoadConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the RoadConstructionGroup class.
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
        public RoadConstructionGroup(
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
            // Set commodity rules for transport
            CommodityRuleCount[Commodity.None].Take = false;
            CommodityRuleCount[Commodity.None].Give = false;
            
            // Roads can transport goods
            CommodityRuleCount[Commodity.Goods].Take = true;
            CommodityRuleCount[Commodity.Goods].Give = true;
            CommodityRuleCount[Commodity.Goods].MaxLoad = 100 * TransportConstants.RoadGoodsCapacity;
        }

        /// <summary>
        /// Creates a new road construction.
        /// </summary>
        /// <returns>A new road construction.</returns>
        public override Construction CreateConstruction()
        {
            return new RoadBuilding(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of transport-related construction groups.
    /// </summary>
    public static partial class TransportConstructionGroups
    {
        /// <summary>
        /// Road construction group.
        /// </summary>
        public static readonly RoadConstructionGroup Road = new RoadConstructionGroup(
            "Road",
            false,
            1, // Group number
            TransportConstants.GroupRoadSize,
            TransportConstants.GroupRoadColour,
            TransportConstants.GroupRoadCostMul,
            TransportConstants.GroupRoadBulCost,
            TransportConstants.GroupRoadFirec,
            TransportConstants.GroupRoadCost,
            TransportConstants.GroupRoadTech,
            TransportConstants.GroupRoadRange
        );
    }
}
