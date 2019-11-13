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
            if ((Levels)value == Levels.High) return new SolidColorBrush(Color.FromArgb(255, 140, 30, 200));
            else if ((Levels)value == Levels.Middle) return new SolidColorBrush(Color.FromArgb(255, 240, 30, 0)); 
            else return new SolidColorBrush(Color.FromArgb(255, 10, 30, 200));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
