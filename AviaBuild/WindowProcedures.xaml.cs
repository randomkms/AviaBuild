using AviaBuild.Helpers;
using System;
using System.Collections.Generic;
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
    public partial class WindowProcedures : Window
    {
        public static WindowProcedures Instance { get; private set; }

        private AviaBuildDBEntities context;

        public WindowProcedures(AviaBuildDBEntities context)
        {
            InitializeComponent();
            Instance = this;
            this.context = context;
        }

        private void BtnPr1Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCategoryPr1.Text.ToNullableStr();
            var param2 = TbxCehIdPr1.Text.ToNullable<int>();
            var res = context.pr1(param1, param2);
            new WindowProcResult { Pr1_Results = res.ToList() }.ShowDialog();
        }
    }
}
