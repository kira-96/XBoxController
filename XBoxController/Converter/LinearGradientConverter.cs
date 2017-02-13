namespace XBoxController.Converter
{
    using System;
    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class LinearGradientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            LinearGradientBrush brush = new LinearGradientBrush()
            {
                StartPoint = new Point(0.5, 2),
                EndPoint = new Point(0.5, 0)
            };
            brush.GradientStops.Add(new GradientStop() { Color = Colors.Black, Offset = 1 });
            brush.GradientStops.Add(new GradientStop() { Color = Colors.Green, Offset = (double)value });
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
