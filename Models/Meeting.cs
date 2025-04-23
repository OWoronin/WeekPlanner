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
        public Meeting(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty,  WeekDaysEnum weekDay, DateTime creationDate, string location) : base(name, dscription, priority, difficulty, weekDay, creationDate)
        {
            Location = location;    
        }

        public override string ToString()
        {
            return $"{base.ToString()}, location: {Location}";
        }

        public void UpdatePlannerItem(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, WeekDaysEnum weekDay, string location)
        {
            Location = location; 
            UpdatePlannerItem(name, dscription, priority, difficulty, weekDay);
        }
    }
}
