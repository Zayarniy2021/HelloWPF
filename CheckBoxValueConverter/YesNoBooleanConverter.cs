
using System;
using System.Windows;
using System.Windows.Data;

namespace CheckBoxValueConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "yes":
                case "true":
                case "да":
                    return true;
                case "нет":
                case "no":
                case "false":
                    return false;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "yes";
                if ((bool)value == false)
                    return "no";
            }
            return "null";
        }
    }
}
