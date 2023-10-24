
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            date_picker.BlackoutDates.AddDatesInPast();
            date_picker.BlackoutDates.Add(new CalendarDateRange(DateTime.Today, DateTime.Today.AddDays(1)));
        }

        private void btn_accept_Click(object sender, RoutedEventArgs e)
        {
            Regex imie = new Regex(@"^([A-Z]{1})([a-z]{2,})$");
            Regex nazwisko = new Regex(@"^([A-Z]{1})([a-z]{2,})$");
            Regex data = new Regex(@"^([0-9]{2})([\.]{1})([0-9]{2})([\.]{1})([0-9]{4})$");

            string I = Imie.Text;
            string N = Nazwisko.Text;
            string D = date_picker.Text;
            string IL = IloscOsob.Text;

            if (imie.IsMatch(Imie.Text) == true)
            {
                if (nazwisko.IsMatch(Nazwisko.Text) == true)
                {
                    if (data.IsMatch(date_picker.Text) == true)
                    {
                        if (IL != "")
                        {
                            MessageBox.Show("Imię: " + I + "\nNazwisko: " + N + "\n" + "\nRezerwacja: " + D + "\nIlość osób: " + IL, "Rezerwacja", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        else
                        {
                            MessageBox.Show("Wybierz ilość osób!", "Komunikat", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Wybierz datę!", "Komunikat", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Niepoprawne nazwisko!", "Komunikat", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            { 
                MessageBox.Show("Niepoprawne imię!", "Komunikat", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
