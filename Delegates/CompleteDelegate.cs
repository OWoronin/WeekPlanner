using System;
using DesktopProjectLib.Models;

namespace DesktopProjectLib.Delegates
{
    
    public delegate void CompleteDelegate(PlannerItem item);

    public static class CompleteDelegateService
    {
        public static void CompleteTask(PlannerItem item)
        {
            if (item is DesktopProjectLib.Models.Task task)
                task.Complete();
        }

        public static void CompleteMeeting(PlannerItem item)
        {
            if (item is Meeting meeting)
                meeting.Complete();
        }


        public static CompleteDelegate GetCompleteDelegate(PlannerItem item)
        {
            return item switch
            {
                DesktopProjectLib.Models.Task => CompleteTask,
                Meeting => CompleteMeeting,
                _ => throw new NotSupportedException("This item type does not support completion.")
            };
        }
    }
}
