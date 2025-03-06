using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Represents a substation that converts high voltage to low voltage.
    /// </summary>
    public class Substation : Construction
    {
        private int hiVoltConsumption;

        /// <summary>
        /// Gets or sets the power output of the substation.
        /// </summary>
        public new int PowerOutput { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the substation is operational.
        /// </summary>
        public new bool IsOperational { get; set; }

        /// <summary>
        /// Initializes a new instance of the Substation class.
        /// </summary>
        /// <param name="group">The construction group.</param>
        public Substation(ConstructionGroup group)
        {
            Group = group;
            PowerOutput = 0;
            IsOperational = false;
            hiVoltConsumption = PowerConstants.SubstationHiVoltCapacity;

            // Initialize commodity max consumption and production
            CommodityMaxConsumption[Commodity.HiVolt] = hiVoltConsumption;
            CommodityMaxProduction[Commodity.LoVolt] = PowerConstants.SubstationLoVoltOutput;
        }

        /// <summary>
        /// Performs a simulation step for the substation.
        /// </summary>
        public override void DoSimStep()
        {
            if (IsBulldozed)
            {
                return;
            }

            // Check if we have high voltage
            int availableHiVolt = CommodityStore[Commodity.HiVolt];
            bool hasHiVolt = availableHiVolt > 0;

            if (hasHiVolt)
            {
                // Consume high voltage
                int hiVoltToConsume = Math.Min(availableHiVolt, hiVoltConsumption);
                CommodityStore[Commodity.HiVolt] -= hiVoltToConsume;

                // Produce low voltage (with some loss)
                int loVoltProduction = (int)(hiVoltToConsume * 0.9); // 10% loss in conversion
                CommodityStore[Commodity.LoVolt] += loVoltProduction;
                PowerOutput = loVoltProduction;

                // Update operational status
                IsOperational = true;
            }
            else
            {
                // No high voltage, no low voltage production
                PowerOutput = 0;
                IsOperational = false;
            }
        }

        /// <summary>
        /// Reports information about the substation.
        /// </summary>
        /// <returns>A string containing information about the substation.</returns>
        public override string Report()
        {
            return $"Substation at ({X}, {Y}), Power Output: {PowerOutput}, Operational: {IsOperational}";
        }
    }
}
