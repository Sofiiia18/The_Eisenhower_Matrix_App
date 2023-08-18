using System;
namespace Eisenhower_Matrix
{
	public class TodoMatrix {
        private Dictionary<string, ToDoQuarter> TodoQuarters { get; set; }
        public TodoMatrix() {
            TodoQuarters = new Dictionary<string, ToDoQuarter> {
                {"IU", new ToDoQuarter()},  // important - urgent
                {"IN", new ToDoQuarter()},  // important - not urgent
                {"NU", new ToDoQuarter()},  // not important - urgent
                {"NN", new ToDoQuarter()}   // not important - not urgent
            };
        }
        public Dictionary<string, ToDoQuarter> GetQuarters() {
            return TodoQuarters;
        }
        public ToDoQuarter GetQuarter(string status) {
            return TodoQuarters[status];
        }
        public void AddItem(string Title, DateTime DeadLine, bool IsImportant = false) {
            if(IsImportant == false) {
                if((DeadLine - DateTime.Now).TotalHours <= 72) {
                    TodoQuarters["NU"].AddItem(Title, DeadLine);
                } else {
                    TodoQuarters["NN"].AddItem(Title, DeadLine);
                }
            } else {
                if((DeadLine - DateTime.Now).TotalHours <= 72) {
                    TodoQuarters["IU"].AddItem(Title, DeadLine);
                } else {
                    TodoQuarters["IN"].AddItem(Title, DeadLine);
                }
            }
        }
    }
}

