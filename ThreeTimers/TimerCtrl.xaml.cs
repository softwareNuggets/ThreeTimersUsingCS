using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ThreeTimers
{

    public partial class TimerCtrl : UserControl
    {
        AppTimerType appTimerType = AppTimerType.PeriodicTimer;

        DotNet6_PeriodicTimer? pDotNet6Timer = null;
        MyDispatcherTimer? myDispatcherTimer = null;
        TimersTimer? myTimersTimer = null;

        public TimerCtrl()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            switch (TimerName.SelectedIndex)
            {
                case 0:
                    appTimerType = AppTimerType.PeriodicTimer; break;
                case 1:
                    appTimerType = AppTimerType.DispatcherTimer; break;
                case 2:
                    appTimerType = AppTimerType.TimersTimer; break;
            }

            switch (appTimerType)
            {
                case AppTimerType.PeriodicTimer:
                    {
                        pDotNet6Timer = new DotNet6_PeriodicTimer(this);
                        await pDotNet6Timer.StartAsync();
                    }
                    break;
                case AppTimerType.DispatcherTimer:
                    {
                        myDispatcherTimer = new MyDispatcherTimer(this);
                        myDispatcherTimer.Start();
                    }
                    break;
                case AppTimerType.TimersTimer:
                    {
                        myTimersTimer = new TimersTimer(this, Dispatcher.CurrentDispatcher);
                        myTimersTimer.Start();
                    }
                    break;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            switch (appTimerType)
            {
                case AppTimerType.PeriodicTimer:
                    {
                        pDotNet6Timer?.Pause();
                    }
                    break;
                case AppTimerType.DispatcherTimer:
                    {
                        myDispatcherTimer?.Pause();
                    }
                    break;
                case AppTimerType.TimersTimer:
                    {
                        myTimersTimer?.Pause();
                    }
                    break;
            }
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            switch (appTimerType)
            {
                case AppTimerType.PeriodicTimer:
                    {
                        pDotNet6Timer?.Resume();
                    }
                    break;
                case AppTimerType.DispatcherTimer:
                    {
                        myDispatcherTimer?.Resume();
                    }
                    break;
                case AppTimerType.TimersTimer:
                    {
                        myTimersTimer?.Resume();
                    }
                    break;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            switch (appTimerType)
            {
                case AppTimerType.PeriodicTimer:
                    {
                        pDotNet6Timer?.Stop();
                    }
                    break;
                case AppTimerType.DispatcherTimer:
                    {
                        myDispatcherTimer?.Stop();
                    }
                    break;
                case AppTimerType.TimersTimer:
                    {
                        myTimersTimer?.Stop();
                    }
                    break;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            switch (appTimerType)
            {
                case AppTimerType.PeriodicTimer:
                    {
                        pDotNet6Timer?.Reset();
                    }
                    break;
                case AppTimerType.DispatcherTimer:
                    {
                        myDispatcherTimer?.Reset();
                    }
                    break;
                case AppTimerType.TimersTimer:
                    {
                        myTimersTimer?.Reset();
                    }
                    break;
            }
        }

    }
}