using System;

namespace FinancialForecastingTool
{
    public class Forecaster
    {
        public double PredictValue(double initialAmount, double annualGrowthRate, int years)
        {
            if (years == 0)
            {
                return initialAmount;
            }

            return PredictValue(initialAmount, annualGrowthRate, years - 1) * (1 + annualGrowthRate);
        }
    }
}