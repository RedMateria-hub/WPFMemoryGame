using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace MemoryGame;
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        (bool)value ? Visibility.Visible : Visibility.Hidden;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        (Visibility)value == Visibility.Visible;
}