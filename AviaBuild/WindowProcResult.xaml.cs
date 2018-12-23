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

        public WindowProcResult()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource pr1_ResultViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pr1_ResultViewSource")));
            pr1_ResultViewSource.Source = Pr1_Results;
        }
    }
}
