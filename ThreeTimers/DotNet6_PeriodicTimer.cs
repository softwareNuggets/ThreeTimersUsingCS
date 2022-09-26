using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ThreeTimers
{
    public class DotNet6_PeriodicTimer
    {

        PeriodicTimer? pTimer = null;
        DateTime startedAtDateTime;
        TimeSpan elapsedTime, pausedTime;
        TimerCtrl myTimerCtrl;

        public DotNet6_PeriodicTimer(TimerCtrl ctrl)
        {
            this.myTimerCtrl = ctrl;
        }

        public async Task StartAsync()
        {
            //The main purpose behind the PeriodicTimer is to avoid using callbacks.
            pTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            startedAtDateTime = DateTime.Now;
            elapsedTime = new TimeSpan(0, 0, 0, 0);
            pausedTime = new TimeSpan(0, 0, 0, 0);

            while (await pTimer.WaitForNextTickAsync())
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
            }

        }

        public void Reset()
        {
            if (pTimer != null)
            {
                pTimer.Dispose();
                pTimer = null;
            }

            elapsedTime = new TimeSpan(0, 0, 0, 0);
            pausedTime = new TimeSpan(0, 0, 0, 0);

            SetButtonIsEnabledState(btn_start: true, btn_pause: false,
                    btn_resume: false, btn_reset: false, btn_stop: false);

            myTimerCtrl.tbClock.Text = Convert.ToString(
                        new TimeSpan(0, 0, 0));
        }

        public void Pause()
        {
            SetButtonIsEnabledState(btn_start: false, btn_pause: false, btn_stop: false,
                    btn_resume: true, btn_reset: true);
        }

        public void Resume()
        {
            SetButtonIsEnabledState(btn_start: false, btn_resume: false, 
                btn_pause: true, btn_reset: true, btn_stop: true);
        }

        public void Stop()
        {
            if (pTimer != null)
            {
                pTimer.Dispose();
                pTimer = null;
            }

            elapsedTime = new TimeSpan(0, 0, 0, 0);
            pausedTime = new TimeSpan(0, 0, 0, 0);

            SetButtonIsEnabledState(btn_start: true, btn_pause: false,
                btn_resume: false, btn_reset: false, btn_stop: false);
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
