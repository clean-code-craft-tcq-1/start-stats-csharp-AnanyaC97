using System;
using System.Linq;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {

        public double average = 0.0;
        public double max = 0.0;
        public double min = 0.0;
        public const double NaN = Double.NaN;
        public List<double> CalculateStatistics(List<double> numbers)
        {
            //Implement statistics here
            if (numbers.Count == 0)
            {
                average = NaN;
                max = NaN;
                min = NaN;
            }
            else
            {
                average = numbers.AsQueryable().Average();
                max = numbers.Max();
                min = numbers.Min();
            }

            List<double> results = new List<double> { average, max, min };
            return results;
        }
    }

    
    public interface IAlerter
    {
        void alert();
    }
    public class EmailAlert : IAlerter
    {
        public bool emailSent { get; set; }
        public void alert()
        {
            emailSent = true;
        }
    }
    public class LEDAlert : IAlerter
    {
        public bool ledGlows { get; set; }
        public void alert()
        {
            ledGlows = true;
        }
    }

    public class StatsAlerter
    {
        public float maxThreshold;
        IAlerter[] alerters;
        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            this.maxThreshold = maxThreshold;
            this.alerters = alerters;
        }

        public void checkAndAlert(List<float> numbers)
        {
            if (numbers.Max() >= maxThreshold)
            {
                foreach (var alertVariable in alerters)
                {
                    alertVariable.alert();
                }
            }
        }
    }
}
