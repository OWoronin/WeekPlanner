using DesktopProjectLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProjectLib.Models
{
    public class Meeting : PlannerItem
    {
        public string Location { get; set; }
        public Meeting(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, StatusEnum status, WeekDaysEnum weekDay, DateTime creationDate, string location) : base(name, dscription, priority, difficulty, status, weekDay, creationDate)
        {
            Location = location;    
        }

        public override string ToString()
        {
            return $"{base.ToString()}, location: {Location}";
        }
    }
}
