using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a solar power plant.
    /// </summary>
    public class SolarPowerPlant : Construction
    {
        /// <summary>
        /// Gets or sets the power output of the solar power plant.
        /// </summary>
        public new int PowerOutput { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the solar power plant is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the SolarPowerPlant class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public SolarPowerPlant(ConstructionGroup group)
        {
            Group = group;
            PowerOutput = 0;
            IsOperational = false;

            // Initialize commodity max production
            CommodityMaxProduction[Commodity.HiVolt] = PowerConstants.SolarPowerOutput;
        }

        /// <summary>
        /// Performs a simulation step for the solar power plant.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Solar power plants always produce power when not bulldozed
            CommodityStore[Commodity.HiVolt] += PowerConstants.SolarPowerOutput;
            PowerOutput = PowerConstants.SolarPowerOutput;
            IsOperational = true;
        }

        /// <summary>
        /// Reports information about the solar power plant.
        /// </summary>
        /// <returns>A string containing information about the solar power plant.</returns>
        public override string Report()
        {
            return $"Solar Power Plant at ({X}, {Y}), Power Output: {PowerOutput}, Operational: {IsOperational}";
        }
    }
}
