using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace ConverterTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateFromList();
            PopulateToList();
            ResizeMode = ResizeMode.NoResize;
            ddFrom.SelectedItem = StringHelper.celsius;
            ddTo.SelectedItem = StringHelper.fahrenheit;
        }

        private void PopulateFromList()
        {
            ddFrom.Items.Add(StringHelper.fahrenheit);
            ddFrom.Items.Add(StringHelper.celsius);
        }

        private void PopulateToList()
        {
            ddTo.Items.Add(StringHelper.fahrenheit);
            ddTo.Items.Add(StringHelper.celsius);
        }

        void Valid(string from, string to, double value)
        {
            var result = string.Empty;
            if (from == StringHelper.celsius)
            {
                if (to == StringHelper.fahrenheit)
                {
                    var fValue = Converters.ConvertFromCelciusToFahrenheit(value);
                    result += string.Format(StringHelper.itsF, fValue.ToString());
                    if (fValue >= 68)
                    {
                        ColorHelper.YellowTextBox(txtResult);
                        result += StringHelper.rowBreak + StringHelper.niceDayForARun;
                    }
                    else
                    {
                        ColorHelper.BlueTextBox(txtResult);
                        result += StringHelper.rowBreak + StringHelper.toColdToRun;
                    }
                }
            }
            else if (from == StringHelper.fahrenheit)
            {
                if (to == StringHelper.celsius)
                {
                    var cValue = Converters.ConvertFromFahrenheitToCelcius(value);
                    result += string.Format(StringHelper.itsC, cValue.ToString());
                    if (cValue >= 20)
                    {
                        ColorHelper.YellowTextBox(txtResult);
                        result += StringHelper.rowBreak + StringHelper.niceDayForARun;
                    }
                    else
                    {
                        ColorHelper.BlueTextBox(txtResult);
                        result += StringHelper.rowBreak + StringHelper.toColdToRun;
                    }
                }
            }
            txtResult.Text = result;
        }

        void NotValid()
        {
            ColorHelper.RedTextBox(txtResult);
            txtResult.Text = StringHelper.notAValidEntry;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            double value;
            bool validEntries = false;
            var from = ddFrom.SelectedValue.ToString();
            var to = ddTo.SelectedValue.ToString();
            validEntries = double.TryParse(txtValue.Text.Replace('.', ','), out value);

            if(txtValue.Text == string.Empty)
                ColorHelper.DefaultTextBox(txtResult);
            else if (validEntries)
                Valid(from, to, value);
            else
                NotValid();
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            var toIndex = ddTo.SelectedIndex;
            var fromIndex = ddFrom.SelectedIndex;

            ddFrom.SelectedIndex = toIndex;
            ddTo.SelectedIndex = fromIndex;

            ColorHelper.DefaultTextBox(txtResult);
            txtResult.Text = string.Empty;
            txtValue.Focus();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Extentions.PerformClick(btnConvert);
            }
        }
    }

}
