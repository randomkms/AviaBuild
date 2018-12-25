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

        private const string ErrorMessage = "You do not have access rights to use this procedure";

        private void BtnPr1Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCategoryPr1.Text.ToNullableStr();
            var param2 = TbxCehIdPr1.Text.ToNullable<int>();
            try
            {
                var res = context.pr1(param1, param2);
                new WindowProcResult { Pr1_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr2Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = DatePickerStartDatePr2.SelectedDate;
            var param2 = DatePickerEndDatePr2.SelectedDate;
            var param3 = TbxCategoryPr2.Text.ToNullableStr();
            var param4 = TbxCehIdPr2.Text.ToNullable<int>();
            var param5 = TbxAreaIdPr2.Text.ToNullable<int>();
            try
            {
                var res = context.pr2(param1, param2, param3, param4, param5);
                new WindowProcResult { Pr2_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr3Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCehIdPr3.Text.ToNullable<int>();
            var param2 = TbxEngProfPr3.Text.ToNullableStr();
            var param3 = TbxWorkerProfPr3.Text.ToNullableStr();
            try
            {
                var res = context.pr3(param1, param2, param3);
                new WindowProcResult { Pr3_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr4Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCehIdPr4.Text.ToNullable<int>();
            try
            {
                var res = context.pr4(param1);
                new WindowProcResult { Pr4_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr5Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxProductIdPr5.Text.ToNullable<int>();
            try
            {
                var res = context.pr5(param1);
                new WindowProcResult { Pr5_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr6Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCehIdPr6.Text.ToNullable<int>();
            var param2 = TbxAreaIdPr6.Text.ToNullable<int>();
            try
            {
                var res = context.pr6(param1, param2);
                new WindowProcResult { Pr6_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr7Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCehIdPr7.Text.ToNullable<int>();
            var param2 = TbxAreaIdPr7.Text.ToNullable<int>();
            try
            {
                var res = context.pr7(param1, param2);
                new WindowProcResult { Pr7_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr8Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCategoryPr8.Text.ToNullableStr();
            var param2 = TbxCehIdPr8.Text.ToNullable<int>();
            var param3 = TbxAreaIdPr8.Text.ToNullable<int>();
            try
            {
                var res = context.pr8(param1, param2, param3);
                new WindowProcResult { Pr8_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr9Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxProductIdPr9.Text.ToNullable<int>();
            try
            {
                var res = context.pr9(param1);
                new WindowProcResult { Pr9_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr10Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxProductIdPr10.Text.ToNullable<int>();
            try
            {
                var res = context.pr10(param1);
                new WindowProcResult { Pr10_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr11Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxCategoryPr11.Text.ToNullableStr();
            var param2 = TbxTestLabIdPr11.Text.ToNullable<int>();
            var param3 = DatePickerStartDatePr11.SelectedDate;
            var param4 = DatePickerEndDatePr11.SelectedDate;
            try
            {
                var res = context.pr11(param1, param2, param3, param4);
                new WindowProcResult { Pr11_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr12Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxProductIdPr12.Text.ToNullable<int>();
            var param2 = TbxCategoryPr12.Text.ToNullableStr();
            var param3 = TbxTestLabIdPr12.Text.ToNullable<int>();
            var param4 = DatePickerStartDatePr12.SelectedDate;
            var param5 = DatePickerEndDatePr12.SelectedDate;
            try
            {
                var res = context.pr12(param1, param2, param3, param4, param5);
                new WindowProcResult { Pr12_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }

        private void BtnPr13Run_Click(object sender, RoutedEventArgs e)
        {
            var param1 = TbxProductIdPr13.Text.ToNullable<int>();
            var param2 = TbxCategoryPr13.Text.ToNullableStr();
            var param3 = TbxTestLabIdPr13.Text.ToNullable<int>();
            var param4 = DatePickerStartDatePr13.SelectedDate;
            var param5 = DatePickerEndDatePr13.SelectedDate;
            try
            {
                var res = context.pr13(param1, param2, param3, param4, param5);
                new WindowProcResult { Pr13_Results = res.ToList() }.ShowDialog();
            }
            catch
            {
                CustomMessage.Show(ErrorMessage, this);
            }
        }
    }
}
