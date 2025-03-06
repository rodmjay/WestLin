using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a construction group for solar power plants.
    /// </summary>
    public class SolarPowerConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the SolarPowerConstructionGroup class.
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
        public SolarPowerConstructionGroup(
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
            CommodityRuleCount[Commodity.HiVolt].MaxLoad = 100 * PowerConstants.SolarPowerOutput;
        }

        /// <summary>
        /// Creates a new solar power plant construction.
        /// </summary>
        /// <returns>A new solar power plant construction.</returns>
        public override Construction CreateConstruction()
        {
            return new SolarPowerPlant(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of power-related construction groups.
    /// </summary>
    public static partial class PowerConstructionGroups
    {
        /// <summary>
        /// Solar power plant construction group.
        /// </summary>
        public static readonly SolarPowerConstructionGroup SolarPower = new SolarPowerConstructionGroup(
            "Solar Power Plant",
            false,
            2, // Group number
            PowerConstants.GroupPowerSolarSize,
            PowerConstants.GroupPowerSolarColour,
            PowerConstants.GroupPowerSolarCostMul,
            PowerConstants.GroupPowerSolarBulCost,
            PowerConstants.GroupPowerSolarFirec,
            PowerConstants.GroupPowerSolarCost,
            PowerConstants.GroupPowerSolarTech,
            PowerConstants.GroupPowerSolarRange
        );
    }
}
