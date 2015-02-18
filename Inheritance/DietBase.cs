using System;

namespace Inheritance
{
    public abstract class DietBase
    {
        public DateTime StartDate { get; set; }
        const int DefaultDays = 30;

        protected DietBase(DateTime startDate)
        {
            StartDate = startDate;
        }

        public int CalculateDaysElapsed()
        {
            TimeSpan dateSpan = DateTime.Now - StartDate;
            return dateSpan.Days;
        }

        public virtual int EstimateRemainingDays()
        {
            TimeSpan dateSpan = StartDate.AddDays(DefaultDays) - DateTime.Now;
            return dateSpan.Days;
        }

        public abstract string GetNextMeal();
    }
}
