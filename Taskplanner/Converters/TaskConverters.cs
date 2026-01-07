using System.Globalization;

namespace Taskplanner.Converters
{
    // Konverterar bool (IsCompleted) till färg
    public class CompletedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCompleted && isCompleted)
                return Color.FromArgb("#4CAF50"); // Grön för klara uppgifter
            else
                return Application.Current.RequestedTheme == AppTheme.Dark 
                    ? Colors.White 
                    : Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Konverterar bool (IsCompleted) till ikon
    public class CompletedToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool isCompleted && isCompleted) ? "✅" : "⭕";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Konverterar string till visibility (synlig/dold)
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Konverterar DateTime till visibility
    public class DateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is DateTime date && date != DateTime.MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Konverterar för filter-knapparnas bakgrundsfärg
    public class FilterToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentFilter = value as string;
            var targetFilter = parameter as string;
            
            return currentFilter == targetFilter 
                ? Application.Current.RequestedTheme == AppTheme.Dark 
                    ? Color.FromArgb("#BB86FC") 
                    : Color.FromArgb("#6200EE")
                : Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Konverterar för filter-knapparnas textfärg
    public class FilterToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentFilter = value as string;
            var targetFilter = parameter as string;
            
            return currentFilter == targetFilter ? Colors.White : Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}