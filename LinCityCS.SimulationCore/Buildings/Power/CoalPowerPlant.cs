using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a coal power plant.
    /// </summary>
    public class CoalPowerPlant : Construction
    {
        private int coalConsumption;
        private int wasteProduction;

        /// <summary>
        /// Gets or sets the power output of the coal power plant.
        /// </summary>
        public new int PowerOutput { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the coal power plant is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the CoalPowerPlant class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public CoalPowerPlant(ConstructionGroup group)
        {
            Group = group;
            PowerOutput = 0;
            IsOperational = false;
            coalConsumption = PowerConstants.CoalPowerCoalUsage;
            wasteProduction = PowerConstants.CoalPowerWasteOutput;

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.Coal] = coalConsumption;
            CommodityMaxProduction[Commodity.HiVolt] = PowerConstants.CoalPowerOutput;
            CommodityMaxProduction[Commodity.Waste] = wasteProduction;
        }

        /// <summary>
        /// Performs a simulation step for the coal power plant.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Check if we have enough coal
            bool hasCoal = CommodityStore[Commodity.Coal] >= coalConsumption;

            if (hasCoal)
            {
                // Consume coal
                CommodityStore[Commodity.Coal] -= coalConsumption;

                // Produce power
                CommodityStore[Commodity.HiVolt] += PowerConstants.CoalPowerOutput;
                PowerOutput = PowerConstants.CoalPowerOutput;

                // Produce waste
                CommodityStore[Commodity.Waste] += wasteProduction;

                // Update operational status
                IsOperational = true;
            }
            else
            {
                // Not enough coal, no power production
                PowerOutput = 0;
                IsOperational = false;
            }
        }

        /// <summary>
        /// Reports information about the coal power plant.
        /// </summary>
        /// <returns>A string containing information about the coal power plant.</returns>
        public override string Report()
        {
            return $"Coal Power Plant at ({X}, {Y}), Power Output: {PowerOutput}, Operational: {IsOperational}";
        }
    }
}
