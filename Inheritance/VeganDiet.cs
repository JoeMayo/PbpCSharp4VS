using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class VeganDiet : DietBase, IDrink
    {
        public VeganDiet() : base(DateTime.Now)
        {
        }

        public string GetNextDrink()
        {
            return "Soy Milk";
        }

        public override string GetNextMeal()
        {
            return "Salad";
        }
    }
}
