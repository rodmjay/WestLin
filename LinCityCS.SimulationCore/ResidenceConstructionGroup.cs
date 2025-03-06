using System;
using LinCityCS.SimulationCore.Buildings.Residence;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Represents a construction group for residences.
    /// </summary>
    public class ResidenceConstructionGroup : ConstructionGroup
    {
        /// <summary>
        /// Gets the type of residence.
        /// </summary>
        public ResidenceType ResidenceType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ResidenceConstructionGroup class.
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
        /// <param name="residenceType">The type of residence.</param>
        public ResidenceConstructionGroup(
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
            int range,
            ResidenceType residenceType)
            : base(name, noCredit, group, size, colour, costMul, bulCost, fireChance, cost, tech, range, 0)
        {
            ResidenceType = residenceType;

            // Set commodity rules
            CommodityRuleCount[Commodity.Food].Take = true;
            CommodityRuleCount[Commodity.Food].Give = false;
            CommodityRuleCount[Commodity.Food].MaxLoad = 100 * ResidenceConstants.ResidenceFoodConsumption;
            
            CommodityRuleCount[Commodity.Goods].Take = true;
            CommodityRuleCount[Commodity.Goods].Give = false;
            CommodityRuleCount[Commodity.Goods].MaxLoad = 100 * ResidenceConstants.ResidenceGoodsConsumption;
            
            CommodityRuleCount[Commodity.LoVolt].Take = true;
            CommodityRuleCount[Commodity.LoVolt].Give = false;
            CommodityRuleCount[Commodity.LoVolt].MaxLoad = 100 * ResidenceConstants.ResidencePowerConsumption;
            
            CommodityRuleCount[Commodity.Water].Take = true;
            CommodityRuleCount[Commodity.Water].Give = false;
            CommodityRuleCount[Commodity.Water].MaxLoad = 100 * ResidenceConstants.ResidenceWaterConsumption;
            
            CommodityRuleCount[Commodity.Labor].Take = false;
            CommodityRuleCount[Commodity.Labor].Give = true;
            CommodityRuleCount[Commodity.Labor].MaxLoad = 100 * ResidenceConstants.ResidenceLaborProduction;
            
            CommodityRuleCount[Commodity.Waste].Take = false;
            CommodityRuleCount[Commodity.Waste].Give = true;
            CommodityRuleCount[Commodity.Waste].MaxLoad = 100 * ResidenceConstants.ResidenceWasteProduction;
        }

        /// <summary>
        /// Creates a new residence construction.
        /// </summary>
        /// <returns>A new residence construction.</returns>
        public override Construction CreateConstruction()
        {
            return new ResidenceBuilding(this);
        }
    }

    /// <summary>
    /// Static class that provides instances of residence construction groups.
    /// </summary>
    public static partial class ResidenceConstructionGroups
    {
        /// <summary>
        /// Low-tech, low-density residence construction group.
        /// </summary>
        public static readonly ResidenceConstructionGroup ResidenceLL = new ResidenceConstructionGroup(
            "Low-Tech, Low-Density Residence",
            false,
            1, // Group number
            ResidenceConstants.GroupResidenceLlSize,
            ResidenceConstants.GroupResidenceLlColour,
            ResidenceConstants.GroupResidenceLlCostMul,
            ResidenceConstants.GroupResidenceLlBulCost,
            ResidenceConstants.GroupResidenceLlFirec,
            ResidenceConstants.GroupResidenceLlCost,
            ResidenceConstants.GroupResidenceLlTech,
            ResidenceConstants.GroupResidenceLlRange,
            ResidenceType.LL
        );

        /// <summary>
        /// Low-tech, medium-density residence construction group.
        /// </summary>
        public static readonly ResidenceConstructionGroup ResidenceML = new ResidenceConstructionGroup(
            "Low-Tech, Medium-Density Residence",
            false,
            2, // Group number
            ResidenceConstants.GroupResidenceMlSize,
            ResidenceConstants.GroupResidenceMlColour,
            ResidenceConstants.GroupResidenceMlCostMul,
            ResidenceConstants.GroupResidenceMlBulCost,
            ResidenceConstants.GroupResidenceMlFirec,
            ResidenceConstants.GroupResidenceMlCost,
            ResidenceConstants.GroupResidenceMlTech,
            ResidenceConstants.GroupResidenceMlRange,
            ResidenceType.ML
        );

        /// <summary>
        /// Low-tech, high-density residence construction group.
        /// </summary>
        public static readonly ResidenceConstructionGroup ResidenceHL = new ResidenceConstructionGroup(
            "Low-Tech, High-Density Residence",
            false,
            3, // Group number
            ResidenceConstants.GroupResidenceHlSize,
            ResidenceConstants.GroupResidenceHlColour,
            ResidenceConstants.GroupResidenceHlCostMul,
            ResidenceConstants.GroupResidenceHlBulCost,
            ResidenceConstants.GroupResidenceHlFirec,
            ResidenceConstants.GroupResidenceHlCost,
            ResidenceConstants.GroupResidenceHlTech,
            ResidenceConstants.GroupResidenceHlRange,
            ResidenceType.HL
        );

        /// <summary>
        /// High-tech, low-density residence construction group.
        /// </summary>
        public static readonly ResidenceConstructionGroup ResidenceLH = new ResidenceConstructionGroup(
            "High-Tech, Low-Density Residence",
            false,
            4, // Group number
            ResidenceConstants.GroupResidenceLhSize,
            ResidenceConstants.GroupResidenceLhColour,
            ResidenceConstants.GroupResidenceLhCostMul,
            ResidenceConstants.GroupResidenceLhBulCost,
            ResidenceConstants.GroupResidenceLhFirec,
            ResidenceConstants.GroupResidenceLhCost,
            ResidenceConstants.GroupResidenceLhTech,
            ResidenceConstants.GroupResidenceLhRange,
            ResidenceType.LH
        );

        /// <summary>
        /// High-tech, medium-density residence construction group.
        /// </summary>
        public static readonly ResidenceConstructionGroup ResidenceMH = new ResidenceConstructionGroup(
            "High-Tech, Medium-Density Residence",
            false,
            5, // Group number
            ResidenceConstants.GroupResidenceMhSize,
            ResidenceConstants.GroupResidenceMhColour,
            ResidenceConstants.GroupResidenceMhCostMul,
            ResidenceConstants.GroupResidenceMhBulCost,
            ResidenceConstants.GroupResidenceMhFirec,
            ResidenceConstants.GroupResidenceMhCost,
            ResidenceConstants.GroupResidenceMhTech,
            ResidenceConstants.GroupResidenceMhRange,
            ResidenceType.MH
        );

        /// <summary>
        /// High-tech, high-density residence construction group.
        /// </summary>
        public static readonly ResidenceConstructionGroup ResidenceHH = new ResidenceConstructionGroup(
            "High-Tech, High-Density Residence",
            false,
            6, // Group number
            ResidenceConstants.GroupResidenceHhSize,
            ResidenceConstants.GroupResidenceHhColour,
            ResidenceConstants.GroupResidenceHhCostMul,
            ResidenceConstants.GroupResidenceHhBulCost,
            ResidenceConstants.GroupResidenceHhFirec,
            ResidenceConstants.GroupResidenceHhCost,
            ResidenceConstants.GroupResidenceHhTech,
            ResidenceConstants.GroupResidenceHhRange,
            ResidenceType.HH
        );
    }
}
