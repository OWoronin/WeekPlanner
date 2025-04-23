using DesktopProjectLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProjectLib.Models
{
    public class Reminder : PlannerItem
    {

        public TimeOnly Time {  get; set; }
        public Reminder(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, StatusEnum status, WeekDaysEnum weekDay, DateTime creationDate, TimeOnly time) : base(name, dscription, priority, difficulty, status, weekDay, creationDate)
        {
            this.Time = time;   
        }

        public override string ToString()
        {
            return $"{base.ToString()}, time: {Time}";
        }
    }
}
