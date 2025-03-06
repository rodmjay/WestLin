using System;

namespace LinCityCS.SimulationCore.Buildings.Power
{
    /// <summary>
    /// Constants for power-related buildings.
    /// </summary>
    public static class PowerConstants
    {
        // Coal power plant
        public const int GroupPowerCoalSize = 4;
        public const int GroupPowerCoalColour = unchecked((int)0xFF000000);
        public const int GroupPowerCoalCostMul = 5;
        public const int GroupPowerCoalBulCost = 5;
        public const int GroupPowerCoalFirec = 50;
        public const int GroupPowerCoalCost = 1000;
        public const int GroupPowerCoalTech = 10;
        public const int GroupPowerCoalRange = 0;
        public const int CoalPowerOutput = 100;
        public const int CoalPowerCoalUsage = 10;
        public const int CoalPowerWasteOutput = 20;

        // Solar power plant
        public const int GroupPowerSolarSize = 4;
        public const int GroupPowerSolarColour = unchecked((int)0xFFFFFF00);
        public const int GroupPowerSolarCostMul = 10;
        public const int GroupPowerSolarBulCost = 10;
        public const int GroupPowerSolarFirec = 10;
        public const int GroupPowerSolarCost = 2000;
        public const int GroupPowerSolarTech = 50;
        public const int GroupPowerSolarRange = 0;
        public const int SolarPowerOutput = 50;

        // Wind power plant
        public const int GroupPowerWindSize = 2;
        public const int GroupPowerWindColour = unchecked((int)0xFF00FFFF);
        public const int GroupPowerWindCostMul = 5;
        public const int GroupPowerWindBulCost = 5;
        public const int GroupPowerWindFirec = 20;
        public const int GroupPowerWindCost = 500;
        public const int GroupPowerWindTech = 30;
        public const int GroupPowerWindRange = 0;
        public const int WindPowerOutput = 25;

        // Substation
        public const int GroupSubstationSize = 2;
        public const int GroupSubstationColour = unchecked((int)0xFFFF0000);
        public const int GroupSubstationCostMul = 2;
        public const int GroupSubstationBulCost = 2;
        public const int GroupSubstationFirec = 30;
        public const int GroupSubstationCost = 200;
        public const int GroupSubstationTech = 20;
        public const int GroupSubstationRange = 10;
        public const int SubstationHiVoltCapacity = 200;
        public const int SubstationLoVoltOutput = 180;

        // Power line
        public const int GroupPowerLineSize = 1;
        public const int GroupPowerLineColour = unchecked((int)0xFFFF8000);
        public const int GroupPowerLineCostMul = 1;
        public const int GroupPowerLineBulCost = 1;
        public const int GroupPowerLineFirec = 5;
        public const int GroupPowerLineCost = 50;
        public const int GroupPowerLineTech = 10;
        public const int GroupPowerLineRange = 0;
        public const int PowerLineCapacity = 100;
    }
}
