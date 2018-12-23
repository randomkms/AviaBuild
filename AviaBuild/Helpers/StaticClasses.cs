using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AviaBuild.Helpers
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = fi.GetCustomAttribute<DescriptionAttribute>(false);
            return attribute != null ? attribute.Description : value.ToString();
        }
    }

    public static class BoolExtension
    {
        public static string ToYesNoValue(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }

    public static class HelpersMethods
    {
        private const int VerticalScrollBarWidth = 50;

        public static void GridViewProportions(ListView listView, params double[] proportions)
        {
            var gView = listView.View as GridView;
            var workingWidth = listView.ActualWidth - VerticalScrollBarWidth;

            if (proportions.Length == 0)
            {
                var sameWidth = 1.0 / gView.Columns.Count * workingWidth;
                foreach (var col in gView.Columns)
                {
                    col.Width = sameWidth;
                }
            }
            else
            {
                for (int i = 0; i < proportions.Length; i++)
                {
                    gView.Columns[i].Width = workingWidth * proportions[i];
                }
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}