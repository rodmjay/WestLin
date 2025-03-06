using System;

namespace LinCityCS.SimulationCore.Buildings
{
    /// <summary>
    /// Constants for building modules.
    /// </summary>
    public static class BuildingConstants
    {
        // General constants
        public const int DaysPerPollution = 14;
        public const int RailPollution = 1;
        public const int DaysPerRailPollution = 30;
        public const int RoadPollution = 1;
        public const int DaysPerRoadPollution = 20;
        public const int UnnatDeathsCost = 500;
        public const int PolDiv = 64;

        // Tax and economy constants
        public const int IncomeTaxRate = 8;
        public const int CoalTaxRate = 15;
        public const int GoodsTaxRate = 1;
        public const int DoleRate = 15;
        public const int TransportCostRate = 14;
        public const int ImPortCostRate = 1;

        // Resource constants
        public const int DaysBetweenCover = 90; // NUMOF_DAYS_IN_MONTH*3
        public const int CoverToleranceDays = 5;
        public const int OreReserve = 1000;
        public const int CoalReserveSize = 10000;
        public const int CoalPerReserve = 1000;

        // Labor constants
        public const int LaborLoadCoal = 18;
        public const int LaborLoadOre = 9;
        public const int LaborLoadSteel = 15;

        // Waste constants
        public const int WasteBurnTime = 350;

        // Interest rate (*10, i.e., 10 is 1%)
        public const int InterestRate = 15;

        // Color constants
        public static int Red(int x) => 32 + x;
        public static int Green(int x) => 64 + x;
        public static int Yellow(int x) => 96 + x;
        public static int Blue(int x) => 128 + x;
        public static int Magenta(int x) => 160 + x;
        public static int Cyan(int x) => 192 + x;
        public static int White(int x) => 224 + x;

        // Group constants
        public const int GroupNameLen = 20;

        // Bare group constants
        public const int GroupBareColour = 76; // green(12)
        public const int GroupBareCost = 0;
        public const int GroupBareCostMul = 1;
        public const int GroupBareBulCost = 1;
        public const int GroupBareTech = 0;
        public const int GroupBareFirec = 0;

        // Water group constants
        public const int GroupWaterColour = 159; // blue(31)
        public const int GroupWaterCost = 1000000;
        public const int GroupWaterCostMul = 2;
        public const int GroupWaterBulCost = 1000000;
        public const int GroupWaterTech = 0;
        public const int GroupWaterFirec = 0;

        // Burnt group constants
        public const int GroupBurntColour = 62; // red(30)
        public const int GroupBurntCost = 0;
        public const int GroupBurntCostMul = 1;
        public const int GroupBurntBulCost = 1000;
        public const int GroupBurntTech = 0;
        public const int GroupBurntFirec = 0;

        // Used group constants
        public const int GroupUsedColour = 76; // green(12)
        public const int GroupUsedCost = 0;
        public const int GroupUsedCostMul = 1;
        public const int GroupUsedBulCost = 0;
        public const int GroupUsedTech = 0;
        public const int GroupUsedFirec = 0;

        // Desert group constants
        public const int GroupDesertColour = 114; // yellow(18)
        public const int GroupDesertCost = 0;
        public const int GroupDesertCostMul = 1;
        public const int GroupDesertBulCost = 1;
        public const int GroupDesertTech = 0;
        public const int GroupDesertFirec = 0;

        // Tree group constants
        public const int GroupTreeColour = 76; // green(12)
        public const int GroupTreeCost = 0;
        public const int GroupTreeCostMul = 1;
        public const int GroupTreeBulCost = 1;
        public const int GroupTreeTech = 0;
        public const int GroupTreeFirec = 0;

        // Tree2 group constants
        public const int GroupTree2Colour = 76; // green(12)
        public const int GroupTree2Cost = 0;
        public const int GroupTree2CostMul = 1;
        public const int GroupTree2BulCost = 1;
        public const int GroupTree2Tech = 0;
        public const int GroupTree2Firec = 0;

        // Tree3 group constants
        public const int GroupTree3Colour = 76; // green(12)
        public const int GroupTree3Cost = 0;
        public const int GroupTree3CostMul = 1;
        public const int GroupTree3BulCost = 1;
        public const int GroupTree3Tech = 0;
        public const int GroupTree3Firec = 0;
    }
}
