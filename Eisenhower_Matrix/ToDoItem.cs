using System;
namespace Eisenhower_Matrix
{
    public class ToDoItem
    {
        public string Title { get; private set; }
        public DateTime Deadline { get; private set; }
        public bool IsDone { get; private set; }

        public ToDoItem(string Title, DateTime Deadline) {
            this.Title = Title;
            this.Deadline = Deadline;
            IsDone = false;
        }
        public DateTime GetDeadLine() {
            return Deadline;
        }
        public string GetTitle() {
            return Title;
        }
        public void Mark() {
            IsDone = true;
        }
        public void Unmark() {
            IsDone = false;
        }
        public override string ToString() {
            string FormattedDeadLine = Deadline.ToString("dd-MM");
            string status = IsDone ? "[x]" : "[]";
            return $"{status} {FormattedDeadLine} {Title}";
        }
    }
}
