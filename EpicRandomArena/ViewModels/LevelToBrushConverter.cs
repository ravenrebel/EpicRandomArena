using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using static EpicRandomArena.Models.Attribute;

namespace EpicRandomArena.ViewModels
{
    public class LevelToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Levels)value == Levels.High) return new SolidColorBrush(Color.FromArgb(255, 197, 92, 252));
            else if ((Levels)value == Levels.Middle) return new SolidColorBrush(Color.FromArgb(255, 228, 164, 254)); 
            else return new SolidColorBrush(Color.FromArgb(255, 244, 228, 250));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
