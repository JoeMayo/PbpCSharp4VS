using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppDemo.Models
{
    public class MenuModel
    {
        public string MenuName { get; set; }

        public List<Meal> Meals { get; set; }

        public static MenuModel GetMenu()
        {
            return new MenuModel
            {
                MenuName = "Gormet",
                Meals = new List<Meal>
                {
                    new Meal { ID = 1, Name = "Spaghetti" },
                    new Meal { ID = 2, Name = "Cow Pat" },
                    new Meal { ID = 3, Name = "Schnitzel" },
                    new Meal { ID = 4, Name = "Burritto" },
                }
            };
        }
    }
}
