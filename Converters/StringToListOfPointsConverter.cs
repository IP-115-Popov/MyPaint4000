using Avalonia.Data.Converters;
using MyPaint4000.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Converters
{
    public class StringToListOfPointsConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            List<Avalonia.Point> listOfPoints = new List<Avalonia.Point>();
            string[] words = ((string)value).Split(' ');
            foreach (string word in words)
            {
                listOfPoints.Add(Avalonia.Point.Parse(word));
            }
            return listOfPoints;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
