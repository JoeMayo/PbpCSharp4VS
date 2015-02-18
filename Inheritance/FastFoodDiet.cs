using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class FastFoodDiet : DietBase, IDrink
    {
        public FastFoodDiet()
            : base(DateTime.Now.AddDays(-45))
        {
        }

        public string GetNextDrink()
        {
            return "Beer";
        }

        public override string GetNextMeal()
        {
            return "Hamburger and Fries";
        }
    }
}
