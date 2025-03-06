using System;
using System.Collections.Generic;

namespace LinCityCS.SimulationCore
{
    /// <summary>
    /// Represents the different types of commodities in the game.
    /// </summary>
    public enum Commodity
    {
        /// <summary>
        /// No commodity.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Food commodity.
        /// </summary>
        Food = 1,
        
        /// <summary>
        /// Labor commodity.
        /// </summary>
        Labor = 2,
        
        /// <summary>
        /// Goods commodity.
        /// </summary>
        Goods = 3,
        
        /// <summary>
        /// Coal commodity.
        /// </summary>
        Coal = 4,
        
        /// <summary>
        /// Ore commodity.
        /// </summary>
        Ore = 5,
        
        /// <summary>
        /// Steel commodity.
        /// </summary>
        Steel = 6,
        
        /// <summary>
        /// Waste commodity.
        /// </summary>
        Waste = 7,
        
        /// <summary>
        /// High voltage electricity commodity.
        /// </summary>
        HiVolt = 8,
        
        /// <summary>
        /// Low voltage electricity commodity.
        /// </summary>
        LoVolt = 9,
        
        /// <summary>
        /// Water commodity.
        /// </summary>
        Water = 10,
        
        /// <summary>
        /// Number of commodities.
        /// </summary>
        Count
    }

    /// <summary>
    /// Represents rules for a commodity.
    /// </summary>
    public class CommodityRule
    {
        /// <summary>
        /// Maximum load of the commodity.
        /// </summary>
        public int MaxLoad { get; set; }
        
        /// <summary>
        /// Indicates whether the commodity can be taken.
        /// </summary>
        public bool Take { get; set; }
        
        /// <summary>
        /// Indicates whether the commodity can be given.
        /// </summary>
        public bool Give { get; set; }

        /// <summary>
        /// Initializes a new instance of the CommodityRule class.
        /// </summary>
        public CommodityRule()
        {
            MaxLoad = 0;
            Take = false;
            Give = false;
        }

        /// <summary>
        /// Initializes a new instance of the CommodityRule class with the specified values.
        /// </summary>
        /// <param name="maxLoad">Maximum load of the commodity.</param>
        /// <param name="take">Indicates whether the commodity can be taken.</param>
        /// <param name="give">Indicates whether the commodity can be given.</param>
        public CommodityRule(int maxLoad, bool take, bool give)
        {
            MaxLoad = maxLoad;
            Take = take;
            Give = give;
        }
    }

    /// <summary>
    /// Provides utility methods for working with commodities.
    /// </summary>
    public static class CommodityUtil
    {
        /// <summary>
        /// Gets the name of a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>The name of the commodity.</returns>
        public static string GetCommodityName(Commodity commodity)
        {
            switch (commodity)
            {
                case Commodity.None:
                    return "None";
                case Commodity.Food:
                    return "Food";
                case Commodity.Labor:
                    return "Labor";
                case Commodity.Coal:
                    return "Coal";
                case Commodity.Goods:
                    return "Goods";
                case Commodity.Ore:
                    return "Ore";
                case Commodity.Steel:
                    return "Steel";
                case Commodity.Waste:
                    return "Waste";
                case Commodity.LoVolt:
                    return "Low Voltage";
                case Commodity.HiVolt:
                    return "High Voltage";
                case Commodity.Water:
                    return "Water";
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Gets the color of a commodity.
        /// </summary>
        /// <param name="commodity">The commodity.</param>
        /// <returns>The color of the commodity as an ARGB value.</returns>
        public static int GetCommodityColor(Commodity commodity)
        {
            unchecked
            {
                switch (commodity)
                {
                    case Commodity.None:
                        return (int)0xFFCCCCCC; // Light Gray
                    case Commodity.Food:
                        return (int)0xFF00FF00; // Green
                    case Commodity.Labor:
                        return (int)0xFFFF0000; // Red
                    case Commodity.Coal:
                        return (int)0xFF000000; // Black
                    case Commodity.Goods:
                        return (int)0xFFFFFF00; // Yellow
                    case Commodity.Ore:
                        return (int)0xFF808080; // Gray
                    case Commodity.Steel:
                        return (int)0xFF0000FF; // Blue
                    case Commodity.Waste:
                        return (int)0xFF800080; // Purple
                    case Commodity.LoVolt:
                        return (int)0xFFFF8000; // Orange
                    case Commodity.HiVolt:
                        return (int)0xFFFF0080; // Pink
                    case Commodity.Water:
                        return (int)0xFF00FFFF; // Cyan
                    default:
                        return (int)0xFFFFFFFF; // White
                }
            }
        }
    }
}
