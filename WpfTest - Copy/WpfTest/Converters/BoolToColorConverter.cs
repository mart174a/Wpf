using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfTest.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        Brush falseColor;
        Brush trueColor;
        public BoolToColorConverter(Brush falseBrush, Brush trueBrush)
        {
            falseColor = falseBrush;
            trueColor = trueBrush;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                if((bool)value == true)
                {
                    return trueColor;
                }
                else
                {
                    return falseColor;
                }
            }
            else
            {
                return falseColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
