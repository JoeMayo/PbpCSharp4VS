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

namespace EntityFrameworkDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            using (var ctx = new MealsContext())
            {
                var meals =
                    (from meal in ctx.Meals
                     select meal.Name)
                    .ToList();

                MenuListBox.ItemsSource = meals;
            }
        }

        private void StartsWithTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResultsListBox.Items.Clear();

            if (string.IsNullOrWhiteSpace(StartsWithTextBox.Text))
                return;

            using (var ctx = new MealsContext())
            {
                var results =
                    (from dish in ctx.Meals
                                     .Include("Ingredients")
                     where dish.Name.StartsWith(
                        StartsWithTextBox.Text)
                     orderby dish.Name
                     select dish)
                    .ToList();

                foreach (var result in results)
                {
                    string recipe = result.Name + ": " + string.Join(", ", result.Ingredients.Select(ing => ing.Description));
                    ResultsListBox.Items.Add(recipe);
                }
            }
        }
    }
}
