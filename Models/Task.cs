using DesktopProjectLib.Enums;

namespace DesktopProjectLib.Models
{
    public class Task : PlannerItem
    {
        public bool Partial { get; set; }
        public bool Rescheduled {  get; set; }

        public StatusEnum Status { get; set; }

        public Task(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, StatusEnum status, WeekDaysEnum weekDay, DateTime creationDate, bool partial, bool rescheduled) : base(name, dscription, priority, difficulty, weekDay, creationDate)
        {
            Partial = partial;
            Rescheduled = rescheduled;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, is this task divided into several days? {Partial}, is this task rescheduled? {Rescheduled}, status: {Status} ";
        }

        public void UpdatePlannerItem(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, StatusEnum status, WeekDaysEnum weekDay, bool partial, bool rescheduled)
        {
            Partial = partial;
            Rescheduled = rescheduled;
            Status = status; 
            UpdatePlannerItem(name, dscription, priority, difficulty, weekDay);
        }
    }
}
