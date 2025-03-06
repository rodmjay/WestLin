using System;

namespace LinCityCS.SimulationCore.Buildings.Residence
{
    /// <summary>
    /// Constants for residence buildings.
    /// </summary>
    public static class ResidenceConstants
    {
        // Residence consumption and production rates
        public const int ResidenceFoodConsumption = 10;
        public const int ResidenceGoodsConsumption = 5;
        public const int ResidencePowerConsumption = 8;
        public const int ResidenceWaterConsumption = 12;
        public const int ResidenceLaborProduction = 15;
        public const int ResidenceWasteProduction = 7;

        // Low-tech, low-density residence
        public const int GroupResidenceLlSize = 1;
        public const int GroupResidenceLlColour = unchecked((int)0xFF00FF00);
        public const int GroupResidenceLlCostMul = 1;
        public const int GroupResidenceLlBulCost = 1;
        public const int GroupResidenceLlFirec = 10;
        public const int GroupResidenceLlCost = 100;
        public const int GroupResidenceLlTech = 0;
        public const int GroupResidenceLlRange = 0;
        public const int GroupResidenceLlMaxPop = 50;

        // Low-tech, medium-density residence
        public const int GroupResidenceMlSize = 2;
        public const int GroupResidenceMlColour = unchecked((int)0xFF00FF00);
        public const int GroupResidenceMlCostMul = 2;
        public const int GroupResidenceMlBulCost = 2;
        public const int GroupResidenceMlFirec = 20;
        public const int GroupResidenceMlCost = 200;
        public const int GroupResidenceMlTech = 10;
        public const int GroupResidenceMlRange = 0;
        public const int GroupResidenceMlMaxPop = 100;

        // Low-tech, high-density residence
        public const int GroupResidenceHlSize = 3;
        public const int GroupResidenceHlColour = unchecked((int)0xFF00FF00);
        public const int GroupResidenceHlCostMul = 3;
        public const int GroupResidenceHlBulCost = 3;
        public const int GroupResidenceHlFirec = 30;
        public const int GroupResidenceHlCost = 300;
        public const int GroupResidenceHlTech = 20;
        public const int GroupResidenceHlRange = 0;
        public const int GroupResidenceHlMaxPop = 200;

        // High-tech, low-density residence
        public const int GroupResidenceLhSize = 1;
        public const int GroupResidenceLhColour = unchecked((int)0xFF00FFFF);
        public const int GroupResidenceLhCostMul = 4;
        public const int GroupResidenceLhBulCost = 4;
        public const int GroupResidenceLhFirec = 5;
        public const int GroupResidenceLhCost = 400;
        public const int GroupResidenceLhTech = 30;
        public const int GroupResidenceLhRange = 0;
        public const int GroupResidenceLhMaxPop = 75;

        // High-tech, medium-density residence
        public const int GroupResidenceMhSize = 2;
        public const int GroupResidenceMhColour = unchecked((int)0xFF00FFFF);
        public const int GroupResidenceMhCostMul = 5;
        public const int GroupResidenceMhBulCost = 5;
        public const int GroupResidenceMhFirec = 10;
        public const int GroupResidenceMhCost = 500;
        public const int GroupResidenceMhTech = 40;
        public const int GroupResidenceMhRange = 0;
        public const int GroupResidenceMhMaxPop = 150;

        // High-tech, high-density residence
        public const int GroupResidenceHhSize = 3;
        public const int GroupResidenceHhColour = unchecked((int)0xFF00FFFF);
        public const int GroupResidenceHhCostMul = 6;
        public const int GroupResidenceHhBulCost = 6;
        public const int GroupResidenceHhFirec = 15;
        public const int GroupResidenceHhCost = 600;
        public const int GroupResidenceHhTech = 50;
        public const int GroupResidenceHhRange = 0;
        public const int GroupResidenceHhMaxPop = 300;
    }
}
