using System;

namespace LinCityCS.SimulationCore.Buildings.Industry
{
    /// <summary>
    /// Represents a construction group for heavy industry buildings.
    /// </summary>
    public class HeavyIndustryConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the HeavyIndustryConstructionGroup class.
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
        public HeavyIndustryConstructionGroup(
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
            CommodityRuleCount[Commodity.Labor].Take = true;
            CommodityRuleCount[Commodity.Labor].Give = false;
            CommodityRuleCount[Commodity.Labor].MaxLoad = 100 * IndustryConstants.HeavyIndustryJobsRequired;
            
            CommodityRuleCount[Commodity.Ore].Take = true;
            CommodityRuleCount[Commodity.Ore].Give = false;
            CommodityRuleCount[Commodity.Ore].MaxLoad = 100 * IndustryConstants.HeavyIndustryOreRequired;
            
            CommodityRuleCount[Commodity.Coal].Take = true;
            CommodityRuleCount[Commodity.Coal].Give = false;
            CommodityRuleCount[Commodity.Coal].MaxLoad = 100 * IndustryConstants.HeavyIndustryCoalRequired;
            
            CommodityRuleCount[Commodity.Steel].Take = false;
            CommodityRuleCount[Commodity.Steel].Give = true;
            CommodityRuleCount[Commodity.Steel].MaxLoad = 100 * IndustryConstants.HeavyIndustrySteelProduction;
            
            CommodityRuleCount[Commodity.Waste].Take = false;
            CommodityRuleCount[Commodity.Waste].Give = true;
            CommodityRuleCount[Commodity.Waste].MaxLoad = 100 * IndustryConstants.HeavyIndustryWasteProduction;
        }

        /// <summary>
        /// Creates a new heavy industry construction.
        /// </summary>
        /// <returns>A new heavy industry construction.</returns>
        public override Construction CreateConstruction()
        {
            return new HeavyIndustryBuilding(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of industry construction groups.
    /// </summary>
    public static partial class IndustryConstructionGroups
    {
        /// <summary>
        /// Heavy industry construction group.
        /// </summary>
        public static readonly HeavyIndustryConstructionGroup HeavyIndustry = new HeavyIndustryConstructionGroup(
            "Heavy Industry",
            false,
            2, // Group number
            IndustryConstants.GroupHeavyIndustrySize,
            IndustryConstants.GroupHeavyIndustryColour,
            IndustryConstants.GroupHeavyIndustryCostMul,
            IndustryConstants.GroupHeavyIndustryBulCost,
            IndustryConstants.GroupHeavyIndustryFirec,
            IndustryConstants.GroupHeavyIndustryCost,
            IndustryConstants.GroupHeavyIndustryTech,
            IndustryConstants.GroupHeavyIndustryRange
        );
    }
}
