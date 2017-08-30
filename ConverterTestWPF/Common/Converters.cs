using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterTestWPF
{
    class Converters
    {
        public static double ConvertFromFahrenheitToCelcius(double fahrenheitValue)
        {
            return 5.0 / 9.0 * (fahrenheitValue - 32);
        }
        public static double ConvertFromCelciusToFahrenheit(double celsiusValue)
        {
            return (celsiusValue * 9) / 5 + 32;
        }
    }
}
