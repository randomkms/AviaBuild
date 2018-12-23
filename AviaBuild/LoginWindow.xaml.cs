using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
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
    public partial class AviaBuildDBEntities : DbContext
    {
        public AviaBuildDBEntities(string connectionString) : base(connectionString)
        {
        }
    }

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private static AviaBuildDBEntities Connect(string userName, string password)
        {
            AviaBuildDBEntities dbContext = null;
            try
            {
                var entityString = new EntityConnectionStringBuilder()
                {
                    Provider = "System.Data.SqlClient",
                    Metadata = "res://*/AviaBuildDBModel.csdl|res://*/AviaBuildDBModel.ssdl|res://*/AviaBuildDBModel.msl",
                    ProviderConnectionString = @"data source=PC-KMS\SQLEXPRESS;initial catalog=AviaBuildDB;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework"
                };
                entityString.ProviderConnectionString += ";user id=" + userName + ";Password=" + password;

                dbContext = new AviaBuildDBEntities(entityString.ConnectionString);
                if (dbContext.Database.Exists())
                    return dbContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            dbContext?.Dispose();
            return null;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var context = Connect(tbxLogin.Text, tbxPass.Password);
            if (context == null)
            {
                MessageBox.Show("Введён не верный логин или пароль!");
                return;
            }

            new MainWindow(context).Show();
            Close();
        }
    }
}
