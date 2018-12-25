using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace AviaBuild.Helpers
{
    public enum MessageType
    {
        None,
        Success,
        Info,
        Error
    }

    public partial class CustomMessage
    {
        private BeginStoryboard showMessageAnim;

        private static CustomMessage Instance = new CustomMessage();

        private CustomMessage()
        {
            this.InitializeComponent();

            this.showMessageAnim = this.FindResource("MessageShowAnimation") as BeginStoryboard;
            this.showMessageAnim.Storyboard.Completed += this.OnShowMessageAnimCompleted;
            this.InfoIcon.Visibility = Visibility.Hidden;
            this.ErrorIcon.Visibility = Visibility.Hidden;
            this.DoneIcon.Visibility = Visibility.Hidden;
        }

        public static async void Show(string message, UIElement target, MessageType messageType = MessageType.Error)
        {
            Instance.PlacementTarget = target;
            Instance.IsOpen = true;
            await Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  new Action(() =>
                  {
                      Instance.TblText.Text = message;
                      switch (messageType)
                      {
                          case MessageType.Success:
                              Instance.MessageIconBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#31B404");
                              Instance.DoneIcon.Visibility = Visibility.Visible;
                              break;
                          case MessageType.Info:
                              Instance.MessageIconBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2ECCFA");
                              Instance.InfoIcon.Visibility = Visibility.Visible;
                              break;
                          case MessageType.Error:
                              Instance.MessageIconBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#DF0101");
                              Instance.ErrorIcon.Visibility = Visibility.Visible;
                              break;
                          default:
                              Instance.MessageIconBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#2ECCFA");
                              Instance.InfoIcon.Visibility = Visibility.Visible;
                              break;
                      }

                      if (Instance.Visibility == Visibility.Visible)
                      {
                          Instance.showMessageAnim.Storyboard.Stop();
                          //this.showMessageAnim.Storyboard.SeekAlignedToLastTick(new TimeSpan(0, 0, 0, 2, 250), TimeSeekOrigin.BeginTime);
                      }

                      Instance.StartAnimation();
                  }));
        }

        private void StartAnimation()
        {
            this.Visibility = Visibility.Visible;
            this.showMessageAnim.Storyboard.Begin();
        }

        private void OnShowMessageAnimCompleted(object sender, EventArgs e)
        {
            this.InfoIcon.Visibility = Visibility.Hidden;
            this.ErrorIcon.Visibility = Visibility.Hidden;
            this.DoneIcon.Visibility = Visibility.Hidden;
            this.Visibility = Visibility.Collapsed;
            this.IsOpen = false;
        }
    }
}
