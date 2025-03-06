using System;

namespace LinCityCS.SimulationCore.Buildings.Transport
{
    /// <summary>
    /// Constants for transport-related buildings.
    /// </summary>
    public static class TransportConstants
    {
        // Road
        public const int GroupRoadSize = 1;
        public const int GroupRoadColour = unchecked((int)0xFF808080);
        public const int GroupRoadCostMul = 1;
        public const int GroupRoadBulCost = 1;
        public const int GroupRoadFirec = 0;
        public const int GroupRoadCost = 10;
        public const int GroupRoadTech = 0;
        public const int GroupRoadRange = 0;
        public const int RoadGoodsCapacity = 100;
    }
}
