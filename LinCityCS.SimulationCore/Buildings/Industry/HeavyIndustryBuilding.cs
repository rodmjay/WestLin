using System;

namespace LinCityCS.SimulationCore.Buildings.Industry
{
    /// <summary>
    /// Represents a heavy industry building.
    /// </summary>
    public class HeavyIndustryBuilding : Construction
    {
        private int jobsRequired;
        private int oreRequired;
        private int coalRequired;
        private int steelProduction;
        private int wasteProduction;

        /// <summary>
        /// Gets or sets a value indicating whether the heavy industry is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the HeavyIndustryBuilding class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public HeavyIndustryBuilding(ConstructionGroup group)
        {
            Group = group;
            IsOperational = false;
            jobsRequired = IndustryConstants.HeavyIndustryJobsRequired;
            oreRequired = IndustryConstants.HeavyIndustryOreRequired;
            coalRequired = IndustryConstants.HeavyIndustryCoalRequired;
            steelProduction = IndustryConstants.HeavyIndustrySteelProduction;
            wasteProduction = IndustryConstants.HeavyIndustryWasteProduction;

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.Labor] = jobsRequired;
            CommodityMaxConsumption[Commodity.Ore] = oreRequired;
            CommodityMaxConsumption[Commodity.Coal] = coalRequired;
            CommodityMaxProduction[Commodity.Steel] = steelProduction;
            CommodityMaxProduction[Commodity.Waste] = wasteProduction;
        }

        /// <summary>
        /// Performs a simulation step for the heavy industry.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Check if we have enough resources
            bool hasLabor = CommodityStore[Commodity.Labor] >= jobsRequired;
            bool hasOre = CommodityStore[Commodity.Ore] >= oreRequired;
            bool hasCoal = CommodityStore[Commodity.Coal] >= coalRequired;

            if (hasLabor && hasOre && hasCoal)
            {
                // Consume resources
                CommodityStore[Commodity.Labor] -= jobsRequired;
                CommodityStore[Commodity.Ore] -= oreRequired;
                CommodityStore[Commodity.Coal] -= coalRequired;

                // Produce steel
                CommodityStore[Commodity.Steel] += steelProduction;

                // Produce waste
                CommodityStore[Commodity.Waste] += wasteProduction;

                // Update operational status
                IsOperational = true;
            }
            else
            {
                // Not enough resources, no production
                IsOperational = false;
            }
        }

        /// <summary>
        /// Reports information about the heavy industry.
        /// </summary>
        /// <returns>A string containing information about the heavy industry.</returns>
        public override string Report()
        {
            return $"Heavy Industry at ({X}, {Y}), Operational: {IsOperational}, Steel Production: {steelProduction}";
        }
    }
}
