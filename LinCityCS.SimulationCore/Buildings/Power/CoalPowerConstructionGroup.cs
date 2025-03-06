using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a construction group for coal power plants.
    /// </summary>
    public class CoalPowerConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the CoalPowerConstructionGroup class.
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
        public CoalPowerConstructionGroup(
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
            CommodityRuleCount[Commodity.Coal].Take = true;
            CommodityRuleCount[Commodity.Coal].Give = false;
            CommodityRuleCount[Commodity.Coal].MaxLoad = 100 * PowerConstants.CoalPowerCoalUsage;
            
            CommodityRuleCount[Commodity.HiVolt].Take = false;
            CommodityRuleCount[Commodity.HiVolt].Give = true;
            CommodityRuleCount[Commodity.HiVolt].MaxLoad = 100 * PowerConstants.CoalPowerOutput;
            
            CommodityRuleCount[Commodity.Waste].Take = false;
            CommodityRuleCount[Commodity.Waste].Give = true;
            CommodityRuleCount[Commodity.Waste].MaxLoad = 100 * PowerConstants.CoalPowerWasteOutput;
        }

        /// <summary>
        /// Creates a new coal power plant construction.
        /// </summary>
        /// <returns>A new coal power plant construction.</returns>
        public override Construction CreateConstruction()
        {
            return new CoalPowerPlant(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of power-related construction groups.
    /// </summary>
    public static partial class PowerConstructionGroups
    {
        /// <summary>
        /// Coal power plant construction group.
        /// </summary>
        public static readonly CoalPowerConstructionGroup CoalPower = new CoalPowerConstructionGroup(
            "Coal Power Plant",
            false,
            1, // Group number
            PowerConstants.GroupPowerCoalSize,
            PowerConstants.GroupPowerCoalColour,
            PowerConstants.GroupPowerCoalCostMul,
            PowerConstants.GroupPowerCoalBulCost,
            PowerConstants.GroupPowerCoalFirec,
            PowerConstants.GroupPowerCoalCost,
            PowerConstants.GroupPowerCoalTech,
            PowerConstants.GroupPowerCoalRange
        );
    }
}
