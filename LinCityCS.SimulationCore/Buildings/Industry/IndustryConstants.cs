using System;

namespace LinCityCS.SimulationCore.Buildings.Industry
{
    /// <summary>
    /// Constants for industry buildings.
    /// </summary>
    public static class IndustryConstants
    {
        // Light industry
        public const int GroupLightIndustrySize = 2;
        public const int GroupLightIndustryColour = unchecked((int)0xFFFF8000);
        public const int GroupLightIndustryCostMul = 3;
        public const int GroupLightIndustryBulCost = 3;
        public const int GroupLightIndustryFirec = 30;
        public const int GroupLightIndustryCost = 300;
        public const int GroupLightIndustryTech = 10;
        public const int GroupLightIndustryRange = 0;
        public const int LightIndustryJobsRequired = 20;
        public const int LightIndustryGoodsProduction = 15;
        public const int LightIndustryWasteProduction = 10;

        // Heavy industry
        public const int GroupHeavyIndustrySize = 4;
        public const int GroupHeavyIndustryColour = unchecked((int)0xFF800000);
        public const int GroupHeavyIndustryCostMul = 5;
        public const int GroupHeavyIndustryBulCost = 5;
        public const int GroupHeavyIndustryFirec = 50;
        public const int GroupHeavyIndustryCost = 1000;
        public const int GroupHeavyIndustryTech = 30;
        public const int GroupHeavyIndustryRange = 0;
        public const int HeavyIndustryJobsRequired = 40;
        public const int HeavyIndustryOreRequired = 20;
        public const int HeavyIndustryCoalRequired = 15;
        public const int HeavyIndustrySteelProduction = 10;
        public const int HeavyIndustryWasteProduction = 25;
    }
}
