using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a construction group for power lines.
    /// </summary>
    public class PowerLineConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the PowerLineConstructionGroup class.
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
        public PowerLineConstructionGroup(
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
            CommodityRuleCount[Commodity.HiVolt].Take = true;
            CommodityRuleCount[Commodity.HiVolt].Give = true;
            CommodityRuleCount[Commodity.HiVolt].MaxLoad = 100 * PowerConstants.PowerLineCapacity;
        }

        /// <summary>
        /// Creates a new power line construction.
        /// </summary>
        /// <returns>A new power line construction.</returns>
        public override Construction CreateConstruction()
        {
            return new PowerLine(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of power-related construction groups.
    /// </summary>
    public static partial class PowerConstructionGroups
    {
        /// <summary>
        /// Power line construction group.
        /// </summary>
        public static readonly PowerLineConstructionGroup PowerLine = new PowerLineConstructionGroup(
            "Power Line",
            false,
            5, // Group number
            PowerConstants.GroupPowerLineSize,
            PowerConstants.GroupPowerLineColour,
            PowerConstants.GroupPowerLineCostMul,
            PowerConstants.GroupPowerLineBulCost,
            PowerConstants.GroupPowerLineFirec,
            PowerConstants.GroupPowerLineCost,
            PowerConstants.GroupPowerLineTech,
            PowerConstants.GroupPowerLineRange
        );
    }
}
