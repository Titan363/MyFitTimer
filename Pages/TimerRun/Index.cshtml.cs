/*
 * CEN 4031 Advanced Programming Development Framework
 * Class: 3222  Instructor: Tillman  Team: Honey Badger
 * Final Project: MyFitTimer
 * Members: Jacob Leffew, William Kategianes, Sean Meinsen
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Data;
using MyFitTimer.Models;


namespace MyFitTimer.Pages.TimerRun
{
    public class IndexModel : PageModel
    {
        private readonly MyFitTimer.Data.MyFitTimerContext _context;
        [ViewData]
        MyFitTimer.StopwatchTracker newStopWatch { get; set; }
        [BindProperty]
        public string ElapsedTime { get; set; }

        public IndexModel(MyFitTimer.Data.MyFitTimerContext context)
        {
            _context = context;
        }
        public IList<MyFitTimer.Models.TimerRun> TimerRuns { get; set; }

        public async Task OnGetAsync()
        {
            TimerRuns = await _context.TimerRuns.ToListAsync();
            ElapsedTime = "0.00";
        }
        public void OnPostStartTimer()
        {
            newStopWatch = new MyFitTimer.StopwatchTracker(_context);
            newStopWatch.StartStopWatch();

            //TimerStartTime = newStopWatch.startTime;
            HttpContext.Session.SetString("TimerStartTime", newStopWatch.startTime.ToString());

            ElapsedTime = "0.00";
             TimerRuns = _context.TimerRuns.ToList();
        }

        public void OnPostStopTimer()
        {
            newStopWatch = new MyFitTimer.StopwatchTracker(_context);
            newStopWatch.StartStopWatch();
            //System.Threading.Thread.Sleep(5000);
            var TimerStartTime = HttpContext.Session.GetString("TimerStartTime");
            if (String.IsNullOrEmpty(TimerStartTime))
            {
                TimerStartTime = DateTime.Now.ToString();
            }
            DateTime.TryParse(TimerStartTime, out newStopWatch.startTime);
            newStopWatch.EndStopWatch();

            //ElapsedTime = newStopWatch.getElapsedTime().ToString();
            ElapsedTime = GetStopwatchElapsedTime(newStopWatch);

            TimerRuns = _context.TimerRuns.ToList();
        }
        public string GetStopwatchElapsedTime(MyFitTimer.StopwatchTracker stopwatchTracker)
        {
            var datediff = TimeSpan.Zero;
            if (stopwatchTracker.endTime != null)
            {
                if (stopwatchTracker.startTime != null)
                {
                    datediff = stopwatchTracker.endTime - stopwatchTracker.startTime;
                }
            }
            return datediff.ToString();
        }

        public string GetTimerElapsedTime(Models.TimerRun timer)
        {
            var datediff = TimeSpan.Zero;
            if (timer.EndTime != null)
            {
                if (timer.StartTime != null)
                {
                    datediff = timer.EndTime - timer.StartTime;
                }
            }
            return datediff.ToString();
        }
    
    }
}
