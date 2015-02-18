using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class SouthBeachDiet : DietBase, IDrink
    {
        public SouthBeachDiet()
            : base(DateTime.Now.AddDays(-60))
        {
        }

        public string GetNextDrink()
        {
            return "Water";
        }

        public override string GetNextMeal()
        {
            return "Steak";
        }
    }
}
