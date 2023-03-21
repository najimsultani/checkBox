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
using System.Windows.Xps.Serialization;

namespace checkBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Preload();

        }
        void Preload()
        {
            rbSmall.IsChecked = true;
            rbDrinkSmall.IsChecked = true;  
        }

        private void btnOrderPizza_Click(object sender, RoutedEventArgs e)
        {
            runReciept.Text = "Customer Name:\n" + txtCustomerName.Text + "\n";

            double amount = 0;  


            bool hasPepperoni = ckPepperoni.IsChecked.Value;
            bool hasExtraCheese = ckCheese.IsChecked.Value; 
            bool hasMushrooms = ckMushrooms.IsChecked.Value;
            bool hasPineapple = ckPineapple.IsChecked.Value;

            bool sizeSmall = rbSmall.IsChecked.Value;
            bool sizeLarge = rbLarge.IsChecked.Value;
            bool sizemedium = rbMedium.IsChecked.Value;
            bool sizeExtraLarge = rbExtraLarge.IsChecked.Value;

            bool drinkSmall = rbDrinkSmall.IsChecked.Value;
            bool drinkmedium = rbDrinkMedium.IsChecked.Value;
            bool drinklarge = rbDrinkLarge.IsChecked.Value;
            bool drinkextralatge = rbDrinkExtraLarge.IsChecked.Value;


            double price = 0;
            //Pizza Size
            runReciept.Text += "Size\n";
            if (sizeSmall)
            {
                price = 13;
                runReciept.Text += "Small";
            }
            else if (sizemedium)
            {
                runReciept.Text += "Medium";
                price = 15;
            }
            else if (sizeLarge)
            {
                runReciept.Text += "Large";
                price = 18;
            }
            else if (sizeExtraLarge)
            {
                runReciept.Text += "Extra Large";
                price = 20;
            }
            runReciept.Text += " - " + price.ToString("c");
            amount += price;


            runReciept.Text += "\nTopping:\n";

            //topping
            if (hasPepperoni == true)
            {
                double toppingPrice = 4;
                runReciept.Text += $"Pepperoni - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            if (hasExtraCheese)
            {
                double toppingPrice = 5;
                runReciept.Text += $"Extra Cheese - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            if (hasMushrooms)
            {
                double toppingPrice = 2;
                runReciept.Text += $"Mushrooms - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }
            if (hasPineapple)
            {
                double toppingPrice = 20;
                runReciept.Text += $"Pineapples - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            //Dink Size
            runReciept.Text += "\nDrink Size\n";
            if (drinkSmall)
            {
                double drinkPrice = 2;
                runReciept.Text += $"Small Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkmedium)
            {
                double drinkPrice = 2.69;
                runReciept.Text += $"Medium Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinklarge)
            {
                double drinkPrice = 3.25;
                runReciept.Text += $"Large Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkextralatge)
            {
                double drinkPrice = 7.50;
                runReciept.Text += $"Extra Large Drink - {drinkPrice.ToString("c")}\n";
                FormatItem("Extra Large Drink", drinkPrice);
                amount += drinkPrice;
            }

            double taxAmount = .1;
            double calculatedTax = amount * taxAmount;
            double totalAmount = amount + taxAmount;

            runReciept.Text += $"\n\n" +
                $"Subtotal: { amount.ToString("c")}\n" +
                $"Tax Amount: {calculatedTax.ToString("c")}\n" +
                $"Total Price: {totalAmount.ToString("c")}";

        }
        public string FormatItem(string item, double amount)
        {
            return $"{item} - {amount.ToString("c")}\n"; 
        }
    }
}
