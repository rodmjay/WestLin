using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a construction group for wind power plants.
    /// </summary>
    public class WindPowerConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the WindPowerConstructionGroup class.
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
        public WindPowerConstructionGroup(
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
            CommodityRuleCount[Commodity.HiVolt].Take = false;
            CommodityRuleCount[Commodity.HiVolt].Give = true;
            CommodityRuleCount[Commodity.HiVolt].MaxLoad = 100 * PowerConstants.WindPowerOutput;
        }

        /// <summary>
        /// Creates a new wind power plant construction.
        /// </summary>
        /// <returns>A new wind power plant construction.</returns>
        public override Construction CreateConstruction()
        {
            return new WindPowerPlant(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of power-related construction groups.
    /// </summary>
    public static partial class PowerConstructionGroups
    {
        /// <summary>
        /// Wind power plant construction group.
        /// </summary>
        public static readonly WindPowerConstructionGroup WindPower = new WindPowerConstructionGroup(
            "Wind Power Plant",
            false,
            3, // Group number
            PowerConstants.GroupPowerWindSize,
            PowerConstants.GroupPowerWindColour,
            PowerConstants.GroupPowerWindCostMul,
            PowerConstants.GroupPowerWindBulCost,
            PowerConstants.GroupPowerWindFirec,
            PowerConstants.GroupPowerWindCost,
            PowerConstants.GroupPowerWindTech,
            PowerConstants.GroupPowerWindRange
        );
    }
}
