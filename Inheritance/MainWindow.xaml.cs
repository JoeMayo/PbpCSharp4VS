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

namespace Inheritance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DietComboBox.ItemsSource =
                new List<string>
                {
                    "Fast Food",
                    "South Beach",
                    "Vegan"
                };
        }

        private void MealButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dietType = DietComboBox.SelectedValue.ToString();
                DietBase diet = DietFactory.GetDietBase(dietType);
                string meal = diet.GetNextMeal();

                MessageBox.Show("Next Meal: " + meal, "Meal");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Please select a diet.", "Error");
            }
        }

        private void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dietType = DietComboBox.SelectedValue.ToString();
                IDrink diet = DietFactory.GetIDrink(dietType);
                string drink = diet.GetNextDrink();

                MessageBox.Show("Next Drink: " + drink, "Drink");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Please select a diet.", "Error");
            }
        }

        //private async void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MealLog logger = null;
        //    try
        //    {
        //        logger = new MealLog();

        //        string dietType = DietComboBox.SelectedValue.ToString();
        //        DietBase dietMeal = DietFactory.GetDietBase(dietType);
        //        IDrink dietDrink = DietFactory.GetIDrink(dietType);
        //        string meal = dietMeal.GetNextMeal();
        //        string drink = dietDrink.GetNextDrink();

        //        await logger.Log(DateTime.Now + " : " + meal + " : " + drink);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Problem logging: " + ex.Message, "Error");
        //    }
        //    finally
        //    {
        //        if (logger != null)
        //            logger.Dispose();
        //    }
        //}

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var logger = new MealLog())
            {
                string dietType = DietComboBox.SelectedValue.ToString();
                DietBase dietMeal = DietFactory.GetDietBase(dietType);
                IDrink dietDrink = DietFactory.GetIDrink(dietType);
                string meal = dietMeal.GetNextMeal();
                string drink = dietDrink.GetNextDrink();

                await logger.Log(DateTime.Now + " : " + meal + " : " + drink);
            }
        }

    }
}
