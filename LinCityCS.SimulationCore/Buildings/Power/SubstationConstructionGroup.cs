using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a construction group for substations.
    /// </summary>
    public class SubstationConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the SubstationConstructionGroup class.
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
        public SubstationConstructionGroup(
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
            CommodityRuleCount[Commodity.HiVolt].Give = false;
            CommodityRuleCount[Commodity.HiVolt].MaxLoad = 100 * PowerConstants.SubstationHiVoltCapacity;
            
            CommodityRuleCount[Commodity.LoVolt].Take = false;
            CommodityRuleCount[Commodity.LoVolt].Give = true;
            CommodityRuleCount[Commodity.LoVolt].MaxLoad = 100 * PowerConstants.SubstationLoVoltOutput;
        }

        /// <summary>
        /// Creates a new substation construction.
        /// </summary>
        /// <returns>A new substation construction.</returns>
        public override Construction CreateConstruction()
        {
            return new Substation(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of power-related construction groups.
    /// </summary>
    public static partial class PowerConstructionGroups
    {
        /// <summary>
        /// Substation construction group.
        /// </summary>
        public static readonly SubstationConstructionGroup Substation = new SubstationConstructionGroup(
            "Substation",
            false,
            4, // Group number
            PowerConstants.GroupSubstationSize,
            PowerConstants.GroupSubstationColour,
            PowerConstants.GroupSubstationCostMul,
            PowerConstants.GroupSubstationBulCost,
            PowerConstants.GroupSubstationFirec,
            PowerConstants.GroupSubstationCost,
            PowerConstants.GroupSubstationTech,
            PowerConstants.GroupSubstationRange
        );
    }
}
