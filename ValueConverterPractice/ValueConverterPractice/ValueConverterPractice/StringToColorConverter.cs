using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ValueConverterPractice
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var val = value as string;
                switch (val)
                {
                    case "1":
                        return Color.Red;
                        break;
                    case "2":
                        return Color.Green;
                        break;
                    case "3":
                        return Color.Blue;
                }
            }
            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
