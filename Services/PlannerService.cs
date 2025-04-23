using DesktopProjectLib.Models;
using DesktopProjectLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopProjectLib.Enums;

namespace DesktopProjectLib.Services
{
    public class PlannerService 
    {
        List<PlannerItem> Items = []; 

        //add method with autoincrement implementation and LINQU 
        public void AddItem(PlannerItem plannerItem)
        {
            if (Items.Count == 0)
            {
                plannerItem.Id = 1;
            }
            else
            {
                var id = Items.Select(s => s.Id).Max();
                id++; 
                plannerItem.Id = id;
            }
            Items.Add(plannerItem); 
        }

        public void RemoveItem(int id)
        {
            var removed = Items.RemoveAll(s => s.Id == id);
            if (removed == 0)
            {
                throw new PlannerItemNotFoundException("You are trying to remove Item that doesn't exist.");
            }
        }

        //Generic method -> use bttns in desktop app to select items of specific type
        public List<T> ShowItemsByType<T>() where T : PlannerItem 
        {
            return Items.OfType<T>().ToList();
        }
        
        //Searching also generic
        public List<T> SearchItem<T>(string? phrase, DifficultyEnum? difficulty, PriorityEnum? priority, StatusEnum? status, WeekDaysEnum? weekDaysEnum, string? location, int? beforeHour, bool? partial, bool? rescheduled) where T : PlannerItem
        {
            var items = Items.OfType<T>();
            if (phrase != null) items = items.Where(p => p.Name.Contains(phrase) || p.Description.Contains(phrase));

            if(difficulty != null) items = items.Where(d => d.Difficulty == difficulty);

            if(priority != null ) items = items.Where(p => p.Priority == priority);

            if(status != null) items = items.Where(s => s.Status == status);

            if (weekDaysEnum != null) items = items.Where(w => w.WeekDay == weekDaysEnum);

            if(typeof(T) == typeof(Models.Meeting) && (beforeHour !=null || partial != null || rescheduled != null))
            {
                throw new Exception("Skibidi");
            }

            if (typeof(T) == typeof(Models.Meeting) && location != null)
            {
                items = items.Cast<Models.Meeting>()
                             .Where(t => t.Location == location)
                             .Cast<T>();
            }

            if (typeof(T) == typeof(Models.Reminder) && beforeHour != null)
            {
                items = items.Cast<Models.Reminder>()
                             .Where(t => t.Time.Hour <= beforeHour)
                             .Cast<T>();
            }

            if (typeof(T) == typeof(Models.Task) && partial != null)
            {
                items = items.Cast<Models.Task>()
                             .Where(t => t.Partial == partial)
                             .Cast<T>();
            }

            if (typeof(T) == typeof(Models.Task) && rescheduled != null)
            {
                items = items.Cast<Models.Task>()
                             .Where(t => t.Rescheduled   == rescheduled)
                             .Cast<T>();
            }
            return items.ToList();
        }

    }
}
