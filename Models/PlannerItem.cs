using DesktopProjectLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProjectLib.Models
{
    public abstract class PlannerItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriorityEnum Priority { get; set; }
        public DifficultyEnum Difficulty { get; set; }

        public WeekDaysEnum WeekDay { get; set; }
        public DateTime CreationDate { get; set; }

        public PlannerItem(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, WeekDaysEnum weekDay, DateTime creationDate)
        {
            Name = name;
            Description = dscription;
            Priority = priority;
            Difficulty = difficulty;
            WeekDay = weekDay;
            CreationDate = creationDate;

        }

        public override bool Equals(object? obj)
        {
            return obj is PlannerItem item && ToString().Equals(item.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}, description: {Description}, the priority: {Priority}, difficulty: {Difficulty}, day of the week: {WeekDay}, creation date: {CreationDate}";
        }


        public void UpdatePlannerItem(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, WeekDaysEnum weekDay)
        {
            Name = name;
            Description = dscription;
            Priority = priority;
            Difficulty = difficulty;
            WeekDay = weekDay;
        }
    }
}
