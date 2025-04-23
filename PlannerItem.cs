using DesktopProjectLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProjectLib
{
    public abstract class PlannerItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriorityEnum Priority { get; set; }
        public DifficultyEnum Difficulty { get; set; }
        public StatusEnum Status { get; set; }
        public WeekDaysEnum WeekDay { get; set; }

        //tutaj nie wiem czy nie lepiej dzień tygodnia zamiast daty? 
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }

        public PlannerItem(int id, string name, string dscription, PriorityEnum priority, DifficultyEnum difficulty, StatusEnum status, WeekDaysEnum weekDay, DateTime creationDate, DateTime dueDate)
        {
            Id = id;
            Name = name;
            Description = dscription;
            Priority = priority;
            Difficulty = difficulty;
            Status = status;
            WeekDay = weekDay;
            CreationDate = creationDate;
            DueDate = dueDate;
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
            return $"Name: {Name}, description: {Description}, the priority: {Priority}, difficulty: {Difficulty}, status: {Status}, day of the week: {WeekDay}, creation date: {CreationDate}, deadline date: {DueDate}";
        }

        //metoda abstrakcyjna: 
        public abstract void MarkAsCompleted();
    }
}
