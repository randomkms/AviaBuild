using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AviaBuild.Helpers
{
    public class DateNotifier : INotifyPropertyChanged, IDisposable
    {
        //public static DateNotifier Instance { get; } = new DateNotifier();
        private bool m_IsRunning = true;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly PropertyChangedEventArgs currDateTimeChangedEventArgs = new PropertyChangedEventArgs("CurrDateTime");

        private DateNotifier()
        {
            UpdateCurrTime();
        }

        private async void UpdateCurrTime()
        {
            while (m_IsRunning)
            {
                await Task.Delay(1000);
                PropertyChanged?.Invoke(this, currDateTimeChangedEventArgs);
            }
        }

        public void Dispose()
        {
            m_IsRunning = false;
        }

        public DateTime CurrDateTime { get => DateTime.Now; }
    }
}
