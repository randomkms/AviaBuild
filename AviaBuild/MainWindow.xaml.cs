using AviaBuild.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
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
        private CollectionViewSource areaViewSource;
        private CollectionViewSource planesViewSource;
        private CollectionViewSource rocketViewSource;
        private CollectionViewSource productViewSource;
        private CollectionViewSource brigadeViewSource;
        private CollectionViewSource cehViewSource;
        private CollectionViewSource engTehProfViewSource;
        private CollectionViewSource engTehWorkerViewSource;
        private CollectionViewSource engTehWorkerProfViewSource;
        private CollectionViewSource profViewSource;
        private CollectionViewSource testEquipmentViewSource;
        private CollectionViewSource testerViewSource;
        private CollectionViewSource testLabViewSource;
        private CollectionViewSource workViewSource;
        private CollectionViewSource workerViewSource;
        private CollectionViewSource workerProfViewSource;

        private AviaBuildDBEntities context;

        public MainWindow(AviaBuildDBEntities context)
        {
            this.context = context;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.areaViewSource = (CollectionViewSource)this.FindResource("areaViewSource");
            this.planesViewSource = (CollectionViewSource)this.FindResource("planeViewSource");
            this.rocketViewSource = (CollectionViewSource)this.FindResource("rocketViewSource");
            this.productViewSource = (CollectionViewSource)this.FindResource("productViewSource");
            this.brigadeViewSource = (CollectionViewSource)this.FindResource("brigadeViewSource");
            this.cehViewSource = (CollectionViewSource)this.FindResource("cehViewSource");
            this.engTehProfViewSource = (CollectionViewSource)this.FindResource("engTehProfViewSource");
            this.engTehWorkerViewSource = (CollectionViewSource)this.FindResource("engTehWorkerViewSource");
            this.engTehWorkerProfViewSource = (CollectionViewSource)this.FindResource("engTehWorkerProfViewSource");
            this.profViewSource = (CollectionViewSource)this.FindResource("profViewSource");
            this.testEquipmentViewSource = (CollectionViewSource)this.FindResource("testEquipmentViewSource");
            this.testerViewSource = (CollectionViewSource)this.FindResource("testerViewSource");
            this.testLabViewSource = (CollectionViewSource)this.FindResource("testLabViewSource");
            this.workViewSource = (CollectionViewSource)this.FindResource("workViewSource");
            this.workerViewSource = (CollectionViewSource)this.FindResource("workerViewSource");
            this.workerProfViewSource = (CollectionViewSource)this.FindResource("workerProfViewSource");

            LoadAll();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, this);
            }

            CustomMessage.Show("Successfully saved", this, MessageType.Success);
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshAll();
                LoadAll();
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, this);
            }

            
            CustomMessage.Show("Successfully refreshed", this, MessageType.Success);
        }

        private void BtnRollBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RollBack();
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, this);
            }

            CustomMessage.Show("Successfully rollback", this, MessageType.Success);
        }

        private void LoadAll()
        {
            HelpersMethods.TryFunc(context.Areas.Load);
            HelpersMethods.TryFunc(context.Planes.Load);
            HelpersMethods.TryFunc(context.Rockets.Load);
            HelpersMethods.TryFunc(context.Products.Load);
            HelpersMethods.TryFunc(context.Brigades.Load);
            HelpersMethods.TryFunc(context.Cehs.Load);
            HelpersMethods.TryFunc(context.EngTehProfs.Load);
            HelpersMethods.TryFunc(context.EngTehWorkers.Load);
            HelpersMethods.TryFunc(context.EngTehWorkerProfs.Load);
            HelpersMethods.TryFunc(context.Profs.Load);
            HelpersMethods.TryFunc(context.TestEquipments.Load);
            HelpersMethods.TryFunc(context.Testers.Load);
            HelpersMethods.TryFunc(context.TestLabs.Load);
            HelpersMethods.TryFunc(context.Works.Load);
            HelpersMethods.TryFunc(context.Workers.Load);
            HelpersMethods.TryFunc(context.WorkerProfs.Load);

            areaViewSource.Source = context.Areas.Local;
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
            testLabViewSource.Source = context.TestLabs.Local;
            workViewSource.Source = context.Works.Local;
            workerViewSource.Source = context.Workers.Local;
            workerProfViewSource.Source = context.WorkerProfs.Local;
        }

        private void RefreshAll()
        {
            context.Dispose();
            context = new AviaBuildDBEntities(DataHandler.Instance.CurrConnectionString);
        }

        private void PullAll()
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        private void RollBack()
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

        private void BtnChooseTable_Click(object sender, RoutedEventArgs e)
        {
            var name = (sender as FrameworkElement).Name.Substring(3);
            if (Enum.TryParse(name, out TableNames tableName))
                DataHandler.Instance.CurrTable = tableName;
        }

        private void MenuItemLogOut_Click(object sender, RoutedEventArgs e)
        {
            context.Dispose();
            new LoginWindow().Show();
            Close();
        }

        private void MenuItemGoToProcedures_Click(object sender, RoutedEventArgs e)
        {
            WindowProcedures.Instance?.Close();
            new WindowProcedures(context).Show();
        }
    }

    public class AccTypeToVisibilityConverter : ConvertorBase<AccTypeToVisibilityConverter>
    {
        private static readonly HashSet<TableNames> architectTables = new HashSet<TableNames>
        {
            TableNames.Planes,
            TableNames.Rockets,
            TableNames.Products,
            TableNames.Works,
            TableNames.TestLabs,
            TableNames.TestEquipments,
            TableNames.Cehs,
            TableNames.Areas,
            TableNames.Brigades
        };

        private static readonly HashSet<TableNames> hrManagerTables = new HashSet<TableNames>
        {
            TableNames.Workers,
            TableNames.WorkerProfs,
            TableNames.Profs,
            TableNames.EngTehWorkers,
            TableNames.EngTehWorkerProfs,
            TableNames.EngTehProfs,
            TableNames.Testers
        };

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is AccountTypes accType)) return DependencyProperty.UnsetValue;
            Enum.TryParse(parameter.ToString(), out TableNames tableName);

            switch (accType)
            {
                case AccountTypes.Admin:
                    return Visibility.Visible;
                case AccountTypes.Architect:
                    return architectTables.Contains(tableName) ? Visibility.Visible : Visibility.Collapsed;
                case AccountTypes.HRManager:
                    return hrManagerTables.Contains(tableName) ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }
    }
}
