using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AviaBuild.Helpers
{
    #region Single Converters
    public class NullToBoolConverter : ConvertorBase<NullToBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter?.ToString() == "Inverse")
                return value == null ? true : false;

            return value == null ? false : true;
        }
    }

    public class StrNullOrSpaceToBoolConverter : ConvertorBase<StrNullOrSpaceToBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace((string)value);
        }
    }

    public class NullToVisibilityConverter : ConvertorBase<NullToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool res;
            if (value is string str)
                res = string.IsNullOrWhiteSpace(str);
            else
                res = value == null;

            if (parameter != null) res = !res;

            return res ? Visibility.Collapsed : Visibility.Visible;
        }
    }

    public class BoolToVisibilityConverter : ConvertorBase<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;

            if (parameter != null)
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;

            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    public class InverseBoolConverter : ConvertorBase<InverseBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }

    public class AdditionConverter : ConvertorBase<AdditionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return System.Convert.ToDouble(value) + System.Convert.ToDouble(parameter);
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }

    public class MultiplyConverter : ConvertorBase<MultiplyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }

    public class DevidedConverter : ConvertorBase<DevidedConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter);
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }

    public class BoolToYesNoConverter : ConvertorBase<BoolToYesNoConverter>
    {
        public string IfTrueText { get; set; } = "Да";
        public string IfFalseText { get; set; } = "Нет";

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return (bool)value ? IfTrueText : IfFalseText;

            return DependencyProperty.UnsetValue;
        }
    }

    public class EnumDescriptionConverter : ConvertorBase<EnumDescriptionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum)
                return (value as Enum).GetDescription();

            return DependencyProperty.UnsetValue;
        }
    }

    public class IsEmptyConverter : ConvertorBase<IsEmptyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value > 0;
        }
    }

    public class StrToShortStr : ConvertorBase<StrToShortStr>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return DependencyProperty.UnsetValue;
            var str = value.ToString();
            var len = System.Convert.ToInt32(parameter);

            return str.Length <= len ? str : str.Substring(0, len) + "...";
        }
    }

    public class TaskStateImgConverter : ConvertorBase<TaskStateImgConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum)) return DependencyProperty.UnsetValue;

            return new Uri("pack://application:,,,/InterfaceTemplates;component/Icons/" + value.ToString() + ".png");
        }
    }
    #endregion

    #region Multi Converters
    public class CenterMultiConvertor : MultiConvertorBase<CenterMultiConvertor>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(values[0]) / 2 - System.Convert.ToDouble(values[1]) / 2;
        }
    }

    public class HorCenterMultiConvertor : MultiConvertorBase<HorCenterMultiConvertor>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double res = System.Convert.ToDouble(values[0]) - ((System.Convert.ToDouble(values[2]) - System.Convert.ToDouble(values[1])) / 2);
            return res < 0 ? 0 : res;
        }
    }

    public class VerCenterMultiConvertor : MultiConvertorBase<VerCenterMultiConvertor>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double res = (System.Convert.ToDouble(values[0]) + System.Convert.ToDouble(values[1]) / 2) - System.Convert.ToDouble(values[2]);
            return res < 0 ? 0 : res;
        }
    }

    public class NumberingConvertor : MultiConvertorBase<NumberingConvertor>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ListView)values[1]).Items.IndexOf(values[0]) + 1;
        }
    }

    public class MultiInverseBoolConverter : MultiConvertorBase<MultiInverseBoolConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.All(val => ((bool)val) == false);
        }
    }
    #endregion
}