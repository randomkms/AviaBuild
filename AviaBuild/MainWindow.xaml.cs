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
        private AviaBuildDBEntities context;

        public MainWindow(AviaBuildDBEntities context)
        {
            this.context = context;
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var planesViewSource = (CollectionViewSource)this.FindResource("planeViewSource");
            var rocketViewSource = (CollectionViewSource)this.FindResource("rocketViewSource");
            var productViewSource = (CollectionViewSource)this.FindResource("productViewSource");
            var brigadeViewSource = (CollectionViewSource)this.FindResource("brigadeViewSource");
            var cehViewSource = (CollectionViewSource)this.FindResource("cehViewSource");
            var engTehProfViewSource = (CollectionViewSource)this.FindResource("engTehProfViewSource");
            var engTehWorkerViewSource = (CollectionViewSource)this.FindResource("engTehWorkerViewSource");
            var engTehWorkerProfViewSource = (CollectionViewSource)this.FindResource("engTehWorkerProfViewSource");
            var profViewSource = (CollectionViewSource)this.FindResource("profViewSource");
            var testEquipmentViewSource = (CollectionViewSource)this.FindResource("testEquipmentViewSource");
            var testerViewSource = (CollectionViewSource)this.FindResource("testerViewSource");
            var testLabViewSource = (CollectionViewSource)this.FindResource("testLabViewSource");
            var workViewSource = (CollectionViewSource)this.FindResource("workViewSource");
            var workerViewSource = (CollectionViewSource)this.FindResource("workerViewSource");
            var workerProfViewSource = (CollectionViewSource)this.FindResource("workerProfViewSource");

            context.Planes.Load();
            context.Rockets.Load();
            context.Products.Load();
            context.Brigades.Load();
            context.Cehs.Load();
            context.EngTehProfs.Load();
            context.EngTehWorkers.Load();
            context.EngTehWorkerProfs.Load();
            context.Profs.Load();
            context.TestEquipments.Load();
            context.Testers.Load();
            context.TestLabs.Load();
            context.Works.Load();
            context.Workers.Load();
            context.WorkerProfs.Load();

            planesViewSource.Source = context.Planes.Local;
            rocketViewSource.Source = context.Rockets.Local;
            productViewSource.Source = context.Products.Local;
            brigadeViewSource.Source = context.Brigades.Local;
            cehViewSource.Source = context.Cehs.Local;
            engTehProfViewSource.Source = context.EngTehProfs.Local;
            engTehWorkerViewSource.Source = context.EngTehWorkers.Local;
            engTehWorkerProfViewSource.Source = context.EngTehWorkerProfs.Local;
            profViewSource.Source = context.Profs.Local;
            testEquipmentViewSource.Source = context.TestEquipments.Local;
            testerViewSource.Source = context.Testers.Local;
            testLabViewSource.Source = context.Planes.Local;
            workViewSource.Source = context.Works.Local;
            workerViewSource.Source = context.Workers.Local;
            workerProfViewSource.Source = context.WorkerProfs.Local;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RollBack();
        }

        public void RollBack()
        {
            var changedEntries = context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
