using System;
using AchtGewinnt.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AchtGewinnt.UWP.Converter
{
    public class MoodRatingToBoolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {

            if (!(parameter is string param))
            {
                return DependencyProperty.UnsetValue;
            }

            if (!Enum.IsDefined(value.GetType(), value))
            {
                return DependencyProperty.UnsetValue;
            }

            var paramValue = Enum.Parse(value.GetType(), param);

            return paramValue.Equals(value);
        }



        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

            var param = parameter as string;

            return parameter == null ? DependencyProperty.UnsetValue : Enum.Parse<MoodRating>(param);

        }

    }
}
