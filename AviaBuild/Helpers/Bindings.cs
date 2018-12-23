using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace AviaBuild.Helpers
{
    public class VisibilityBindingExtension : Binding
    {
        public VisibilityBindingExtension()
        {
            Initialize();
        }

        public VisibilityBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        public VisibilityBindingExtension(string path, object valueToCheck)
    : base(path)
        {
            Initialize();
            this.ValueToCheck = valueToCheck;
        }

        public VisibilityBindingExtension(string path, object valueToCheck, bool isInverse)
: base(path)
        {
            Initialize();
            this.ValueToCheck = valueToCheck;
            IsInverse = isInverse;
        }

        private void Initialize()
        {
            ValueToCheck = Binding.DoNothing;
            IsInverse = false;
            this.Converter = new VisibilityConverter(this);
        }

        [ConstructorArgument("valueToCheck")]
        public object ValueToCheck { get; set; }

        [ConstructorArgument("isInverse")]
        public bool IsInverse { get; set; }

        private class VisibilityConverter : IValueConverter
        {
            public VisibilityConverter(VisibilityBindingExtension switchExtension)
            {
                _switch = switchExtension;
            }

            private VisibilityBindingExtension _switch;

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    if (_switch.IsInverse)
                    {
                        if (value.ToString() != _switch.ValueToCheck.ToString()) return Visibility.Visible;

                        return Visibility.Collapsed;
                    }

                    if (value.ToString() == _switch.ValueToCheck.ToString()) return Visibility.Visible;

                    return Visibility.Collapsed;
                }
                catch
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
    }

    public class SwitchBindingExtension : Binding
    {
        public SwitchBindingExtension()
        {
            Initialize();
        }

        public SwitchBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        public SwitchBindingExtension(string path, object valueIfTrue, object valueIfFalse)
            : base(path)
        {
            Initialize();
            this.ValueIfTrue = valueIfTrue;
            this.ValueIfFalse = valueIfFalse;
        }

        public SwitchBindingExtension(string path, object valueIfTrue, object valueIfFalse, object valueIfNull)
    : base(path)
        {
            Initialize();
            this.ValueIfTrue = valueIfTrue;
            this.ValueIfFalse = valueIfFalse;
            this.ValueIfNull = valueIfNull;
        }

        private void Initialize()
        {
            this.ValueIfTrue = Binding.DoNothing;
            this.ValueIfFalse = Binding.DoNothing;
            this.ValueIfNull = Binding.DoNothing;
            this.Converter = new SwitchConverter(this);
        }

        [ConstructorArgument("valueIfTrue")]
        public object ValueIfTrue { get; set; }

        [ConstructorArgument("valueIfFalse")]
        public object ValueIfFalse { get; set; }

        [ConstructorArgument("valueIfNull")]
        public object ValueIfNull { get; set; }

        private class SwitchConverter : IValueConverter
        {
            public SwitchConverter(SwitchBindingExtension switchExtension)
            {
                _switch = switchExtension;
            }

            private SwitchBindingExtension _switch;

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    bool? b = (bool?)value;
                    if (b == true)
                        return _switch.ValueIfTrue;
                    else if (b == false)
                        return _switch.ValueIfFalse;
                    else return _switch.ValueIfNull;
                }
                catch
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
    }

    public class StringBindingExtension : Binding
    {
        public StringBindingExtension()
        {
            Initialize();
        }

        public StringBindingExtension(string path)
            : base(path)
        {
            Initialize();
        }

        public StringBindingExtension(string path, object argFirst, object argSecond, object valueIfFirst, object valueIfSecond)
: base(path)
        {
            Initialize();
            this.ArgFirst = argFirst;
            this.ArgSecond = argSecond;
            this.ValueIfFirst = valueIfFirst;
            this.ValueIfSecond = valueIfSecond;
        }

        public StringBindingExtension(string path, object argFirst, object argSecond, object valueIfFirst, object valueIfSecond, object valueDefault)
    : base(path)
        {
            Initialize();
            this.ArgFirst = argFirst;
            this.ArgSecond = argSecond;
            this.ValueIfFirst = valueIfFirst;
            this.ValueIfSecond = valueIfSecond;
            this.ValueDefault = valueDefault;
        }

        private void Initialize()
        {
            this.ArgFirst = string.Empty;
            this.ArgSecond = string.Empty;
            this.ValueIfFirst = Binding.DoNothing;
            this.ValueIfSecond = Binding.DoNothing;
            this.ValueDefault = Binding.DoNothing;
            this.Converter = new StrConverter(this);
        }

        [ConstructorArgument("argFirst")]
        public object ArgFirst { get; set; }

        [ConstructorArgument("argSecond")]
        public object ArgSecond { get; set; }

        [ConstructorArgument("valueIfFirst")]
        public object ValueIfFirst { get; set; }

        [ConstructorArgument("valueIfSecond")]
        public object ValueIfSecond { get; set; }

        [ConstructorArgument("valueDefault")]
        public object ValueDefault { get; set; }

        private class StrConverter : IValueConverter
        {
            public StrConverter(StringBindingExtension stringExtension)
            {
                _switchStr = stringExtension;
            }

            private StringBindingExtension _switchStr;

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    string strVal = (string)value;
                    if (strVal == _switchStr.ArgFirst?.ToString())
                        return _switchStr.ValueIfFirst;
                    if (strVal == _switchStr.ArgSecond?.ToString())
                        return _switchStr.ValueIfSecond;
                    return _switchStr.ValueDefault;
                }
                catch
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
    }
}
