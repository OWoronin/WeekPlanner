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
        public TimeOnly StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public bool IsCancelled { get; private set; }
        public bool IsRescheduled { get; private set; }
        public bool IsCompleted { get; private set; }

        public Meeting(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, WeekDaysEnum weekDay, DateTime creationDate, string location, TimeOnly startTime, int durationMinutes)
            : base(name, dscription, priority, difficulty, weekDay, creationDate)
        {
            Location = location;
            StartTime = startTime;
            DurationMinutes = durationMinutes;
        }

        public void Complete()
        {
            IsCompleted = true;
        }

        public void Cancel()
        {
            IsCancelled = true;
        }

        public void Reschedule(TimeOnly newStartTime, int newDuration)
        {
            StartTime = newStartTime;
            DurationMinutes = newDuration;
            IsRescheduled = true;
        }

        public bool ShouldAutoComplete(DateTime currentTime)
        {
            var meetingDateTime = CreationDate.Date + StartTime.ToTimeSpan();
            return !IsCompleted && !IsCancelled && currentTime >= meetingDateTime.AddMinutes(DurationMinutes);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, location: {Location}, start: {StartTime}, duration (min): {DurationMinutes}";
        }

        public void UpdatePlannerItem(string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, WeekDaysEnum weekDay, string location, TimeOnly startTime, int durationMinutes)
        {
            Location = location;
            StartTime = startTime;
            DurationMinutes = durationMinutes;
            UpdatePlannerItem(name, dscription, priority, difficulty, weekDay);
        }
    }

}
