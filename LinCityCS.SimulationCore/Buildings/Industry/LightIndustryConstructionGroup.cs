using System;

namespace LinCityCS.SimulationCore.Buildings.Industry
{
    /// <summary>
    /// Represents a construction group for light industry buildings.
    /// </summary>
    public class LightIndustryConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Initializes a new instance of the LightIndustryConstructionGroup class.
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
        public LightIndustryConstructionGroup(
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
            CommodityRuleCount[Commodity.Labor].MaxLoad = 100 * IndustryConstants.LightIndustryJobsRequired;
            
            CommodityRuleCount[Commodity.Goods].Take = false;
            CommodityRuleCount[Commodity.Goods].Give = true;
            CommodityRuleCount[Commodity.Goods].MaxLoad = 100 * IndustryConstants.LightIndustryGoodsProduction;
            
            CommodityRuleCount[Commodity.Waste].Take = false;
            CommodityRuleCount[Commodity.Waste].Give = true;
            CommodityRuleCount[Commodity.Waste].MaxLoad = 100 * IndustryConstants.LightIndustryWasteProduction;
        }

        /// <summary>
        /// Creates a new light industry construction.
        /// </summary>
        /// <returns>A new light industry construction.</returns>
        public override Construction CreateConstruction()
        {
            return new LightIndustryBuilding(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of industry construction groups.
    /// </summary>
    public static partial class IndustryConstructionGroups
    {
        /// <summary>
        /// Light industry construction group.
        /// </summary>
        public static readonly LightIndustryConstructionGroup LightIndustry = new LightIndustryConstructionGroup(
            "Light Industry",
            false,
            1, // Group number
            IndustryConstants.GroupLightIndustrySize,
            IndustryConstants.GroupLightIndustryColour,
            IndustryConstants.GroupLightIndustryCostMul,
            IndustryConstants.GroupLightIndustryBulCost,
            IndustryConstants.GroupLightIndustryFirec,
            IndustryConstants.GroupLightIndustryCost,
            IndustryConstants.GroupLightIndustryTech,
            IndustryConstants.GroupLightIndustryRange
        );
    }
}
