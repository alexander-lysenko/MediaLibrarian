using System;
using System.Globalization;
using System.Windows.Data;

namespace MediaLibrarian.Classes
{
    // https://stackoverflow.com/a/5180824
    internal class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}