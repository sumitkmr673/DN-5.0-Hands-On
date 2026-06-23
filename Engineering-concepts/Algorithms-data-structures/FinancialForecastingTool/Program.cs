using System;

namespace FinancialForecastingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Corporate Financial Forecasting Tool ---\n");

            Forecaster forecaster = new Forecaster();

            double initialRevenue = 5000000.00;
            double expectedGrowthRate = 0.15;
            int projectionYears = 5;

            Console.WriteLine($"Base Company Revenue: ₹{initialRevenue}");
            Console.WriteLine($"Projected Annual Growth Rate: {expectedGrowthRate * 100}%\n");

            for (int i = 1; i <= projectionYears; i++)
            {
                double projectedValue = forecaster.PredictValue(initialRevenue, expectedGrowthRate, i);
                Console.WriteLine($"[Year {i} Projection] Estimated Revenue: ₹{Math.Round(projectedValue, 2)}");
            }
        }
    }
}