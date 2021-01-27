using System;
using System.Linq;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {

        public double average = 0.0;
        public double max = 0;
        public double min = 0;
        public const double NaN = Double.NaN;
        public List<double> CalculateStatistics(List<double> numbers)
        {
            //Implement statistics here
            average = numbers.AsQueryable().Average();
            max = numbers.Max();
            min = numbers.Min();

            List<double> results = new List<double> { average, max, min };
            return results;
        }
    }
}
