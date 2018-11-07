using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PredictYourGradeApp.Converters
{
    public class IntStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var text = value.ToString();

                switch (parameter.ToString())
                {
                    case "sex":
                        return (text == "F") ? 0 : 1;

                    case "studytime":
                    case "traveltime":
                        switch (text)
                        {
                            case "1": 
                            case "2": 
                            case "3": 
                            case "4":
                                return int.Parse(text) - 1;
                            default:
                                return 0;
                        }

                    case "internet":
                        return (text == "yes") ? 0 : 1;

                    case "grade":
                        var number = 0;
                        int.TryParse(value.ToString(), out number);
                        return number;
                    default:
                        break;
                }

                return 0;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = 0;
            int.TryParse(value.ToString(), out number);

            switch (parameter.ToString())
            {
                case "sex":
                    return (number == 0) ? "F" : "M";

                case "traveltime":
                case "studytime":
                    return (number + 1).ToString();

                case "internet":
                    return (number == 0) ? "yes" : "no";

                case "grade":
                    return number;

                default:
                    break;
            }

            return "";
        }
    }
}
