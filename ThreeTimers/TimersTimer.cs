using System;
using System.Timers;
using System.Windows.Threading;

namespace ThreeTimers
{
    public class TimersTimer
    {
        System.Timers.Timer? _timer = null;
        DateTime startedAtDateTime;
        TimeSpan elapsedTime, pausedTime;
        TimerCtrl myTimerCtrl;
        Dispatcher? myCurrentThread;

        public TimersTimer(TimerCtrl ctrl, Dispatcher dispatcher)
        {
            this.myTimerCtrl = ctrl;    
            this.myCurrentThread = dispatcher;
        }

        public void Start()
        {

            _timer = new System.Timers.Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 1000; //1 second

            startedAtDateTime = DateTime.Now;
            pausedTime = new TimeSpan(0, 0, 0);

            // Have the timer fire repeated events (true is the default)
            _timer.AutoReset = true;

            _timer.Enabled = true;
            //_timer.Start();

            SetButtonIsEnabledState(btn_pause: true, btn_reset: true,
                    btn_start: false, btn_resume: false, btn_stop: true);
        }

        private void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            // the Dispatcher maintains a prioritized queue of work items
            // for a specific thread.
            // in order for the background thread to access the Content
            // property of the button, the background thread must 
            // delegate the work to the dispatcher associated with the UI
            // thread.   This is accomplished by using BeginInvoke method 
            // which behave asynchronously

            myCurrentThread?.BeginInvoke(new Action(() =>
            {
                if (myTimerCtrl.btnPause.IsEnabled == true)
                {
                    if (pausedTime.TotalMilliseconds > 0)
                    {
                        elapsedTime -= pausedTime;
                        pausedTime = new TimeSpan(0, 0, 0, 0);
                    }
                    elapsedTime += (DateTime.Now - startedAtDateTime);

                    myTimerCtrl.tbClock.Text = Convert.ToString(
                        new TimeSpan(elapsedTime.Hours, elapsedTime.Minutes,
                                    elapsedTime.Seconds));

                    startedAtDateTime = DateTime.Now;
                }
                else
                {
                    startedAtDateTime = DateTime.Now;
                    pausedTime += DateTime.Now - startedAtDateTime;
                }
            }));
        }

        public void Reset()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }


            SetButtonIsEnabledState(btn_start: true, btn_pause: false,
                btn_resume: false, btn_reset: false, btn_stop: false);

            elapsedTime = new TimeSpan(0, 0, 0);
            pausedTime = new TimeSpan(0, 0, 0);
            myTimerCtrl.tbClock.Text = Convert.ToString(
                        new TimeSpan(0, 0, 0));
        }

        public void Pause()
        {
            SetButtonIsEnabledState(btn_start: false, btn_pause: false,
                btn_resume: true, btn_reset: true, btn_stop: true);
        }

        public void Resume()
        {
            SetButtonIsEnabledState(btn_start: false, btn_pause: true,
                btn_resume: false, btn_reset: true, btn_stop: true);
        }

        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }

            SetButtonIsEnabledState(btn_start: true, btn_pause: false,
                btn_resume: false, btn_reset: true, btn_stop: false);
        }

        private void SetButtonIsEnabledState(bool btn_start, bool btn_pause,
                    bool btn_resume, bool btn_reset, bool btn_stop)
        {
            myTimerCtrl.btnStart.IsEnabled = btn_start;
            myTimerCtrl.btnPause.IsEnabled = btn_pause;
            myTimerCtrl.btnResume.IsEnabled = btn_resume;
            myTimerCtrl.btnReset.IsEnabled = btn_reset;
            myTimerCtrl.btnStop.IsEnabled = btn_stop;
        }
    }
}
