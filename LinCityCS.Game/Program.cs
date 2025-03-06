using System;
using LinCityCS.RenderingUI;
using LinCityCS.SimulationCore;

namespace LinCityCS.Game
{
    /// <summary>
    /// The main class for the LinCityCS game.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Starting LinCityCS...");
            
            try
            {
                using (var game = new LinCityCS.RenderingUI.LinCityGame())
                {
                    game.Run();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
