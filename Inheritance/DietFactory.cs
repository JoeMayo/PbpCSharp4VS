using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class DietFactory
    {
        public static DietBase GetDietBase(string dietType)
        {
            switch (dietType)
            {
                case "Fast Food":
                    return new FastFoodDiet();
                case "South Beach":
                    return new SouthBeachDiet();
                case "Vegan":
                    return new VeganDiet();
                default:
                    throw new ArgumentException("Unknown diet.", "dietType");
            }
        }

        public static IDrink GetIDrink(string dietType)
        {
            switch (dietType)
            {
                case "Fast Food":
                    return new FastFoodDiet();
                case "South Beach":
                    return new SouthBeachDiet();
                case "Vegan":
                    return new VeganDiet();
                default:
                    throw new ArgumentException("Unknown diet.", "dietType");
            }
        }
    }
}
