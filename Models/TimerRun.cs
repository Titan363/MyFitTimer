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

namespace MyFitTimer.Models
{
    public class TimerRun
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }        
        
    }
}