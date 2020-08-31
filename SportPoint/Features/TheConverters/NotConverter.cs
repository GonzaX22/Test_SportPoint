﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SportPoint.Features.TheConverters
{
    public class NotConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) { 
            bool result;

            if (value is bool input) {
                result = !input;
            }
            else {
                result = false;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
