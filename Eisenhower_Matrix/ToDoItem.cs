using System;
namespace Eisenhower_Matrix
{
    public class ToDoItem
    {
        private string Title;
        private DateTime Deadline;
        public bool IsDone { get; set; }

        public ToDoItem(string title, DateTime deadline)
        {
            Title = title;
            Deadline = deadline;
            IsDone = false;
        }

        public string GetTitle()
        {
            return Title;
        }

        public DateTime GetDeadline()
        {
            return Deadline;
        }

        public void Mark()
        {
            IsDone = true;
        }

        public void Unmark()
        {
            IsDone = false;
        }

        public override string ToString()
        {
            int day = Deadline.Day;
            int month = Deadline.Month;
            if (IsDone)
                return $"[x] {day}-{month} {Title}";
            return $"[ ] {day}-{month} {Title}";
        }
    }
}
