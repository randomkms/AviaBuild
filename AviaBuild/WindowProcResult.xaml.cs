using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AviaBuild
{
    public partial class WindowProcResult : Window
    {
        public List<pr1_Result> Pr1_Results { get; set; }
        public List<pr2_Result> Pr2_Results { get; set; }
        public List<pr3_Result> Pr3_Results { get; set; }
        public List<pr4_Result> Pr4_Results { get; set; }
        public List<pr5_Result> Pr5_Results { get; set; }
        public List<pr6_Result> Pr6_Results { get; set; }
        public List<pr7_Result> Pr7_Results { get; set; }
        public List<pr8_Result> Pr8_Results { get; set; }
        public List<pr9_Result> Pr9_Results { get; set; }
        public List<pr10_Result> Pr10_Results { get; set; }
        public List<pr11_Result> Pr11_Results { get; set; }
        public List<pr12_Result> Pr12_Results { get; set; }
        public List<pr13_Result> Pr13_Results { get; set; }

        public WindowProcResult()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var pr1_ResultViewSource = (CollectionViewSource)this.FindResource("pr1_ResultViewSource");
            var pr2_ResultViewSource = (CollectionViewSource)this.FindResource("pr2_ResultViewSource");
            var pr3_ResultViewSource = (CollectionViewSource)this.FindResource("pr3_ResultViewSource");
            var pr4_ResultViewSource = (CollectionViewSource)this.FindResource("pr4_ResultViewSource");
            var pr5_ResultViewSource = (CollectionViewSource)this.FindResource("pr5_ResultViewSource");
            var pr6_ResultViewSource = (CollectionViewSource)this.FindResource("pr6_ResultViewSource");
            var pr7_ResultViewSource = (CollectionViewSource)this.FindResource("pr7_ResultViewSource");
            var pr8_ResultViewSource = (CollectionViewSource)this.FindResource("pr8_ResultViewSource");
            var pr9_ResultViewSource = (CollectionViewSource)this.FindResource("pr9_ResultViewSource");
            var pr10_ResultViewSource = (CollectionViewSource)this.FindResource("pr10_ResultViewSource");
            var pr11_ResultViewSource = (CollectionViewSource)this.FindResource("pr11_ResultViewSource");
            var pr12_ResultViewSource = (CollectionViewSource)this.FindResource("pr12_ResultViewSource");
            var pr13_ResultViewSource = (CollectionViewSource)this.FindResource("pr13_ResultViewSource");

            pr1_ResultViewSource.Source = Pr1_Results;
            pr2_ResultViewSource.Source = Pr2_Results;
            pr3_ResultViewSource.Source = Pr3_Results;
            pr4_ResultViewSource.Source = Pr4_Results;
            pr5_ResultViewSource.Source = Pr5_Results;
            pr6_ResultViewSource.Source = Pr6_Results;
            pr7_ResultViewSource.Source = Pr7_Results;
            pr8_ResultViewSource.Source = Pr8_Results;
            pr9_ResultViewSource.Source = Pr9_Results;
            pr10_ResultViewSource.Source = Pr10_Results;
            pr11_ResultViewSource.Source = Pr11_Results;
            pr12_ResultViewSource.Source = Pr12_Results;
            pr13_ResultViewSource.Source = Pr13_Results;

            var AllResults = new List<CollectionViewSource>(13)
            {
                pr1_ResultViewSource,
                pr2_ResultViewSource,
                pr3_ResultViewSource,
                pr4_ResultViewSource,
                pr5_ResultViewSource,
                pr6_ResultViewSource,
                pr7_ResultViewSource,
                pr8_ResultViewSource,
                pr9_ResultViewSource,
                pr10_ResultViewSource,
                pr11_ResultViewSource,
                pr12_ResultViewSource,
                pr13_ResultViewSource
            };

            foreach (var res in AllResults)
            {
                if (res.Source != null)
                {
                    TbxLinesCount.Text = (res.Source as ICollection).Count + " lines";
                    return;
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCreateReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
