using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConverterTestWPF
{
    class ColorHelper
    {
        public static void RedTextBox(TextBox t)
        {
            //string .
            t.Background = Brushes.Red;
            t.Foreground = Brushes.White;
        }

        public static void YellowTextBox(TextBox t)
        {
            t.Background = Brushes.Yellow;
            t.Foreground = Brushes.Black;
        }
        public static void DefaultTextBox(TextBox t)
        {
            t.Background = SystemColors.WindowBrush;
            t.Foreground = SystemColors.WindowBrush;
        }
        public static void BlueTextBox(TextBox t)
        {
            t.Background = Brushes.Blue;
            t.Foreground = Brushes.White;
        }
    }
}
