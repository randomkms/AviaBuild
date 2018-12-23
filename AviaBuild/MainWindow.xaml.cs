using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AviaBuild
{
    public partial class MainWindow : Window
    {
        AviaBuildDBEntities context;
        CollectionViewSource planesViewSource;
        CollectionViewSource rocketsViewSource;

        public MainWindow(AviaBuildDBEntities context)
        {
            this.context = context;
            InitializeComponent();
            planesViewSource = (CollectionViewSource)FindResource("productPlanesViewSource");
            rocketsViewSource = (CollectionViewSource)FindResource("productRocketsViewSource");
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource productViewSource = ((CollectionViewSource)(this.FindResource("productViewSource")));

            context.Planes.Load();
            context.Rockets.Load();

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.   
            planesViewSource.Source = context.Planes.Local;
            rocketsViewSource.Source = context.Rockets.Local;
            for (int i = 0; i < 8; i++)
                (rocketsViewSource.Source as ObservableCollection<Rocket>).Add(new Rocket());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
