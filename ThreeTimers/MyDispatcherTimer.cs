using System;
using System.Windows.Threading;

namespace ThreeTimers
{
    public class MyDispatcherTimer
    {
        DispatcherTimer? dtimer = null;
        DateTime startedAtDateTime;
        TimeSpan elapsedTime, pausedTime;
        TimerCtrl myTimerCtrl;

        public MyDispatcherTimer(TimerCtrl ctrl)
        {
            this.myTimerCtrl = ctrl;
        }

        public void Start()
        {
            pausedTime = new TimeSpan(0, 0, 0);

            dtimer = new DispatcherTimer(DispatcherPriority.Send);
            dtimer.Interval = new TimeSpan(0, 0, 0, 1);
            dtimer.Tick += Dtimer_Tick;
            dtimer.Start();
            startedAtDateTime = DateTime.Now;

            SetButtonIsEnabledState(btn_pause: true, btn_reset: true,
                    btn_start: false, btn_resume: false, btn_stop: true);
        }

        private void Dtimer_Tick(object? sender, EventArgs e)
        {
            if (myTimerCtrl.btnPause.IsEnabled == true)
            {
                if (pausedTime.TotalMilliseconds > 0)
                {
                    elapsedTime -= pausedTime;
                    pausedTime = new TimeSpan(0, 0, 0);
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
        }

        public void Reset()
        {
            if (dtimer != null)
            {
                dtimer.Stop();
                dtimer = null;
            }

            elapsedTime = new TimeSpan(0, 0, 0);
            pausedTime = new TimeSpan(0, 0, 0);

            SetButtonIsEnabledState(btn_start: true, btn_pause: false,
                    btn_resume: false, btn_reset: false, btn_stop: false);

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
            if (dtimer != null)
            {
                dtimer.Stop();
                dtimer = null;
            }

            elapsedTime = new TimeSpan(0, 0, 0);
            pausedTime = new TimeSpan(0, 0, 0);


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
