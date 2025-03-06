using System;

namespace LinCityCS.SimulationCore.Buildings.Industry
{
    /// <summary>
    /// Represents a light industry building.
    /// </summary>
    public class LightIndustryBuilding : Construction
    {
        private int jobsRequired;
        private int goodsProduction;
        private int wasteProduction;

        /// <summary>
        /// Gets or sets a value indicating whether the light industry is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the LightIndustryBuilding class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public LightIndustryBuilding(ConstructionGroup group)
        {
            Group = group;
            IsOperational = false;
            jobsRequired = IndustryConstants.LightIndustryJobsRequired;
            goodsProduction = IndustryConstants.LightIndustryGoodsProduction;
            wasteProduction = IndustryConstants.LightIndustryWasteProduction;

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.Labor] = jobsRequired;
            CommodityMaxProduction[Commodity.Goods] = goodsProduction;
            CommodityMaxProduction[Commodity.Waste] = wasteProduction;
        }

        /// <summary>
        /// Performs a simulation step for the light industry.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Check if we have enough labor
            bool hasLabor = CommodityStore[Commodity.Labor] >= jobsRequired;

            if (hasLabor)
            {
                // Consume labor
                CommodityStore[Commodity.Labor] -= jobsRequired;

                // Produce goods
                CommodityStore[Commodity.Goods] += goodsProduction;

                // Produce waste
                CommodityStore[Commodity.Waste] += wasteProduction;

                // Update operational status
                IsOperational = true;
            }
            else
            {
                // Not enough labor, no production
                IsOperational = false;
            }
        }

        /// <summary>
        /// Reports information about the light industry.
        /// </summary>
        /// <returns>A string containing information about the light industry.</returns>
        public override string Report()
        {
            return $"Light Industry at ({X}, {Y}), Operational: {IsOperational}, Goods Production: {goodsProduction}";
        }
    }
}
