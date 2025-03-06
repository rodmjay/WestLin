using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a wind power plant.
    /// </summary>
    public class WindPowerPlant : Construction
    {
        /// <summary>
        /// Gets or sets the power output of the wind power plant.
        /// </summary>
        public new int PowerOutput { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the wind power plant is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the WindPowerPlant class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public WindPowerPlant(ConstructionGroup group)
        {
            Group = group;
            PowerOutput = 0;
            IsOperational = false;

            // Initialize commodity max production
            CommodityMaxProduction[Commodity.HiVolt] = PowerConstants.WindPowerOutput;
        }

        /// <summary>
        /// Performs a simulation step for the wind power plant.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Wind power plants always produce power when not bulldozed
            CommodityStore[Commodity.HiVolt] += PowerConstants.WindPowerOutput;
            PowerOutput = PowerConstants.WindPowerOutput;
            IsOperational = true;
        }

        /// <summary>
        /// Reports information about the wind power plant.
        /// </summary>
        /// <returns>A string containing information about the wind power plant.</returns>
        public override string Report()
        {
            return $"Wind Power Plant at ({X}, {Y}), Power Output: {PowerOutput}, Operational: {IsOperational}";
        }
    }
}
