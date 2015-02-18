using System;

namespace Classes
{
    public class CompletionMonitor
    {
        readonly Percent threshold;

        public CompletionMonitor() : this(50) { }
        public CompletionMonitor(int threshold)
        {
            this.threshold = threshold;
        }

        public int Threshold
        {
            get { return threshold; }
        }

        Percent current;

        public int Current
        {
            get { return current; }
            set
            {
                current = value;
                CheckIfThresholdReached(current);
            }
        }

        public int CalculateDistanceToThreshold()
        {
            int distance = threshold - current;

            if (distance < 0)
                distance = 0;

            return distance;
        }

        public ThresholdLevel EstimateThreasholdLevel()
        {
            if (current < (threshold - 5))
                return ThresholdLevel.Under;
            else if (current > (threshold + 5))
                return ThresholdLevel.Over;
            else
                return ThresholdLevel.Near;
        }

        int previous;

        void CheckIfThresholdReached(int value)
        {
            if (previous < threshold && value >= threshold)
            {
                if (ThresholdReached != null)
                    ThresholdReached(this, EventArgs.Empty);
            }

            previous = value;
        }

        public event EventHandler ThresholdReached;
    }
}
