namespace XBoxController.Converter
{
    using System;
    using Windows.UI.Xaml.Data;

    public class XPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double v = (double)value;
            double pos = 96 *  v - 12;
            return pos;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class YPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double v = (double)value;
            double pos = -96 * v - 12;
            return pos;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
