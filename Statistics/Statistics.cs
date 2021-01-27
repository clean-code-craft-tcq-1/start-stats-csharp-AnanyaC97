using System;
using System.Linq;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {

        public float average = 0;
        public float max = 0;
        public float min = 0;
        public const double NaN = Double.NaN;

        public List<float> CalculateStatistics(List<float> numbers)
        {
            //Implement statistics here
            if (numbers.Count == 0)
            {
                average = (float)NaN;
                max = (float)NaN;
                min = (float)NaN;
            }
            else
            {
                average = numbers.AsQueryable().Average();
                max = numbers.Max();
                min = numbers.Min();
            }

            List<float> results = new List<float> { average, max, min };
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

        public void checkAndAlert(List<float> values)
        {
            if ((values.Max()) >= maxThreshold)
            {
                foreach (var alertVariable in alerters)
                {
                    alertVariable.alert();
                }
            }
        }
    }
}
