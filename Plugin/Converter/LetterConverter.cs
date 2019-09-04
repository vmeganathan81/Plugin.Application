using Plugin.App.Model;
using System;
using System.Windows.Data;

namespace Plugin.App.Converter
{

    /// <summary>
    /// Letter MultiValue Converter
    /// </summary>
    public class LetterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int LetterId = 0;
            if (values[0] != null)
            {
                if (!string.IsNullOrEmpty(values[0].ToString()))
                {
                    LetterId = (int)values[0];
                }
            }

            string Name = string.Empty;
            if (values[1] != null)
            {
                Name = (string)values[1];
            }

            string RemoteFileName = string.Empty;
            if (values[2] != null)
            {
                RemoteFileName = (string)values[2];
            }

            string Category = string.Empty;
            if (values[3] != null)
            {
                Category = (string)values[2];
            }

            Letter Letter = new Letter
            {
                LetterID = LetterId,
                RemoteFileName = RemoteFileName,
                Name = Name,
                Category = Category
            };
            return Letter;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
