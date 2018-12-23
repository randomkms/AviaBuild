using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AviaBuild
{
    public enum AccountTypes
    {
        Admin,
        Architect,
        HRManager,
        User
    }

    public enum TableNames
    {
        Areas,
        Planes,
        Rockets,
        Products,
        Brigades,
        Cehs,
        EngTehProfs,
        EngTehWorkers,
        EngTehWorkerProfs,
        Profs,
        TestEquipments,
        Testers,
        TestLabs,
        Works,
        Workers,
        WorkerProfs
    }

    public class DataHandler : INotifyPropertyChanged
    {
        private AccountTypes _accType;
        private TableNames _currTable;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private DataHandler() { }

        public static DataHandler Instance { get; } = new DataHandler();

        public AccountTypes CurrAccType { get => _accType; set { _accType = value; OnPropertyChanged(); } }

        public TableNames CurrTable { get => _currTable; set { _currTable = value; OnPropertyChanged(); } }
    }
}
