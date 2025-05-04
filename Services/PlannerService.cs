
using ModelTask = DesktopProjectLib.Models.Task;
using ModelMeeting = DesktopProjectLib.Models.Meeting;
using ModelReminder = DesktopProjectLib.Models.Reminder;
using DesktopProjectLib.Enums;
using DesktopProjectLib.Exceptions;
using DesktopProjectLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopProjectLib.Services
{
    public class PlannerService
    {
        private List<PlannerItem> Items = [];

        public event Action<ModelTask>? OnTaskCompleted;
        public event Action<ModelMeeting>? OnMeetingAutoCompleted;

        public void AddItem(PlannerItem plannerItem)
        {
            plannerItem.Id = Items.Count == 0 ? 1 : Items.Max(s => s.Id) + 1;
            Items.Add(plannerItem);
        }

        public void RemoveItem(int id)
        {
            var removed = Items.RemoveAll(s => s.Id == id);
            if (removed == 0)
                throw new PlannerItemNotFoundException("You are trying to remove Item that doesn't exist.");
        }

        public List<T> ShowItemsByType<T>() where T : PlannerItem
        {
            return Items.OfType<T>().ToList();
        }

        public List<T> SearchItem<T>(
            string? phrase,
            DifficultyEnum? difficulty,
            PriorityEnum? priority,
            StatusEnum? status,
            WeekDaysEnum? weekDaysEnum,
            string? location,
            int? beforeHour,
            bool? partial,
            bool? rescheduled
        ) where T : PlannerItem
        {
            if (typeof(T) == typeof(ModelMeeting) && (beforeHour != null || partial != null || rescheduled != null))
                throw new IncorrectSearchParametersException();

            if (typeof(T) == typeof(ModelReminder) && (location != null || partial != null || rescheduled != null))
                throw new IncorrectSearchParametersException();

            if (typeof(T) == typeof(ModelTask) && (beforeHour != null || location != null))
                throw new IncorrectSearchParametersException();

            var items = Items.OfType<T>();

            if (phrase != null)
                items = items.Where(p => p.Name.Contains(phrase) || p.Description.Contains(phrase));
            if (difficulty != null)
                items = items.Where(d => d.Difficulty == difficulty);
            if (priority != null)
                items = items.Where(p => p.Priority == priority);
            if (weekDaysEnum != null)
                items = items.Where(w => w.WeekDay == weekDaysEnum);

            if (typeof(T) == typeof(ModelMeeting) && location != null)
                items = items.Cast<ModelMeeting>().Where(t => t.Location == location).Cast<T>();

            if (typeof(T) == typeof(ModelReminder) && beforeHour != null)
                items = items.Cast<ModelReminder>().Where(t => t.Time.Hour <= beforeHour).Cast<T>();

            if (typeof(T) == typeof(ModelTask) && partial != null)
                items = items.Cast<ModelTask>().Where(t => t.Partial == partial).Cast<T>();

            if (typeof(T) == typeof(ModelTask) && rescheduled != null)
                items = items.Cast<ModelTask>().Where(t => t.Rescheduled == rescheduled).Cast<T>();

            return items.ToList();
        }

        public void CompleteTask(int taskId)
        {
            var task = Items.OfType<ModelTask>().FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new PlannerItemNotFoundException("Task not found.");

            task.Complete();
            OnTaskCompleted?.Invoke(task);
        }

        public void AutoCompleteMeetings(DateTime currentTime)
        {
            foreach (var meeting in Items.OfType<ModelMeeting>())
            {
                if (meeting.ShouldAutoComplete(currentTime))
                {
                    meeting.Complete();
                    OnMeetingAutoCompleted?.Invoke(meeting);
                }
            }
        }


        public List<string> GetTopMeetingLocations(int top = 3)
        {
            return Items
                .OfType<ModelMeeting>()
                .GroupBy(m => m.Location)
                .OrderByDescending(g => g.Count())
                .Take(top)
                .Select(g => g.Key)
                .ToList();
        }


        public List<ModelReminder> GetMorningReminders()
        {
            return Items
                .OfType<ModelReminder>()
                .Where(r => r.Time.Hour < 12)
                .OrderBy(r => r.Time)
                .ToList();
        }
    }
}
