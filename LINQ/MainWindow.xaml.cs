using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Dish> dishes;
        List<Ingredient> ingredients;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMenu();
        }

        void InitializeMenu()
        {
            dishes = new List<Dish>
            {
                new Dish { ID = 1, Name = "Spaghetti" },
                new Dish { ID = 2, Name = "Cow Pat" },
                new Dish { ID = 3, Name = "Schnitzel" },
                new Dish { ID = 4, Name = "Burrito" },
            };

            ingredients = new List<Ingredient>
            {
                new Ingredient { DishID = 1, Description = "Noodles" },
                new Ingredient { DishID = 1, Description = "Tomato Sauce" },
                new Ingredient { DishID = 2, Description = "Rice" },
                new Ingredient { DishID = 2, Description = "Vegetables" },
                new Ingredient { DishID = 3, Description = "Pork" },
                new Ingredient { DishID = 3, Description = "Yager Sauce" },
                new Ingredient { DishID = 4, Description = "Tortilla" },
                new Ingredient { DishID = 4, Description = "Beans" },
            };

            MenuListBox.ItemsSource = dishes.Select(dish => dish.Name);
        }

        private void StartsWithTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResultsListBox.Items.Clear();

            if (string.IsNullOrWhiteSpace(StartsWithTextBox.Text))
                return;

            var results =
                (from dish in dishes
                 where dish.Name.StartsWith(StartsWithTextBox.Text, StringComparison.InvariantCultureIgnoreCase)
                 join ingredient in ingredients
                    on dish.ID equals ingredient.DishID
                    into ingredientList
                 orderby dish.Name
                 select new
                 {
                     Name = dish.Name,
                     Ingredients = 
                        (from item in ingredientList
                         select item.Description)
                        .ToArray()
                 })
                .ToList();

            foreach (var result in results)
            {
                string recipe = result.Name + ": " + string.Join(", ", result.Ingredients);
                ResultsListBox.Items.Add(recipe);
            }
        }

        private void ReadXmlButton_Click(object sender, RoutedEventArgs e)
        {
            var xmlString = @"<dishes>
  <dish id=""1"" name=""Spaghetti"">
    <ingredients>
      <ingredient>Noodles</ingredient>
      <ingredient>Tomato Sauce</ingredient>
    </ingredients>
  </dish>
  <dish id=""2"" name=""Cow Pat"">
    <ingredients>
      <ingredient>Rice</ingredient>
      <ingredient>Vegetables</ingredient>
    </ingredients>
  </dish>
  <dish id=""3"" name=""Schnitzel"">
    <ingredients>
      <ingredient>Pork</ingredient>
      <ingredient>Yager Sauce</ingredient>
    </ingredients>
  </dish>
  <dish id=""4"" name=""Burrito"">
    <ingredients>
      <ingredient>Tortilla</ingredient>
      <ingredient>Beans</ingredient>
    </ingredients>
  </dish>
</dishes>";
            XDocument doc = XDocument.Parse(xmlString);

            MessageBox.Show(doc.ToString(), "Parse XML String");
        }

        private void CreateXmlButton_Click(object sender, RoutedEventArgs e)
        {
            var dishesXml = CreateDishesXml();

            MessageBox.Show(dishesXml.ToString(), "XML");
        }

        private void CreateObjectsButton_Click(object sender, RoutedEventArgs e)
        {
            var dishesXml = CreateDishesXml();

            var results =
                (from dish in dishesXml.Elements("dish")
                 let dishID = int.Parse(dish.Attribute("id").Value)
                 select new Dish
                 {
                     ID = dishID,
                     Name = dish.Attribute("name").Value
                 })
                .ToList();

            string dishString = string.Join(", ", results.Select(dish => dish.Name));
            MessageBox.Show(dishString, "Objects");
        }

        private static XElement CreateDishesXml()
        {
            XElement dishesXml =
                new XElement("dishes",
                    new XElement("dish",
                        new XAttribute("id", 1),
                        new XAttribute("name", "Spaghetti"),
                        new XElement("ingredients",
                            new XElement("ingredient", "Noodles"),
                            new XElement("ingredient", "Tomato Sauce"))),
                    new XElement("dish",
                        new XAttribute("id", 2),
                        new XAttribute("name", "Cow Pat"),
                        new XElement("ingredients",
                            new XElement("ingredient", "Rice"),
                            new XElement("ingredient", "Vegetables"))),
                    new XElement("dish",
                        new XAttribute("id", 3),
                        new XAttribute("name", "Schnitzel"),
                        new XElement("ingredients",
                            new XElement("ingredient", "Pork"),
                            new XElement("ingredient", "Yager Sauce"))),
                    new XElement("dish",
                        new XAttribute("id", 4),
                        new XAttribute("name", "Burrito"),
                        new XElement("ingredients",
                            new XElement("ingredient", "Tortilla"),
                            new XElement("ingredient", "Beans"))));
            return dishesXml;
        }
    }
}
