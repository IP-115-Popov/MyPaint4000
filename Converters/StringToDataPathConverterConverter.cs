using Avalonia.Data.Converters;
using Avalonia.Media;
using MyPaint4000.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Converters
{
    public class StringToDataPathConverterConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Geometry.Parse((string)value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
