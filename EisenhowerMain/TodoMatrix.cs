using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTable;

namespace EisenhowerCore {
    public class TodoMatrix
    {
        private Dictionary<string, TodoQuarter> TodoQuarters { get; set; }
        public TodoMatrix()
        {
            TodoQuarters = new Dictionary<string, TodoQuarter> {
                {"IU", new TodoQuarter()},  // important - urgent
                {"IN", new TodoQuarter()},  // important - not urgent
                {"NU", new TodoQuarter()},  // not important - urgent
                {"NN", new TodoQuarter()}   // not important - not urgent
            };
        }
        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return TodoQuarters;
        }


        public TodoQuarter GetQuarter(string status)
        {
            return TodoQuarters[status];
        }


        public void AddItem(string Title, DateTime DeadLine, bool IsImportant = false)
        {
            if (IsImportant == false)
            {
                if ((DeadLine - DateTime.Now).TotalHours <= 72)
                {
                    TodoQuarters["NU"].AddItem(Title, DeadLine);
                }
                else
                {
                    TodoQuarters["NN"].AddItem(Title, DeadLine);
                }
            }
            else
            {
                if ((DeadLine - DateTime.Now).TotalHours <= 72)
                {
                    TodoQuarters["IU"].AddItem(Title, DeadLine);
                }
                else
                {
                    TodoQuarters["IN"].AddItem(Title, DeadLine);
                }

            }
        }


        public string FormattedMatrix()
        {
            StringBuilder EisenhowerMatrix = EmptyMatrix();
          
            int groupIndex;
            int startPointSubstring;

            foreach (var quarter in TodoQuarters)
            {
                string key = quarter.Key;
                TodoQuarter toDoQuarter = quarter.Value;
                
                switch (key)
                {
                    case "IU":
                        startPointSubstring = 153;
                        groupIndex = 1;

                        foreach (TodoItem task in toDoQuarter.GetItems())
                        {
                            FormatTaskString(task, startPointSubstring, groupIndex, EisenhowerMatrix);

                            startPointSubstring += 72;
                            groupIndex++;
                            
                            
                        }
                        break;
                    case "IN":
                        startPointSubstring = 185;
                        groupIndex = 1;

                        foreach (TodoItem task in toDoQuarter.GetItems())
                        {
                            FormatTaskString(task, startPointSubstring, groupIndex, EisenhowerMatrix);

                            startPointSubstring += 72;
                            groupIndex++;

                        }
                        break;
                    case "NU":
                        startPointSubstring = 1165 ;
                        groupIndex = 1;
                        foreach (TodoItem task in toDoQuarter.GetItems())
                        {

                            FormatTaskString(task, startPointSubstring, groupIndex, EisenhowerMatrix);

                            startPointSubstring += 72;
                            
                            groupIndex++;

                        }
                        break;
                    case "NN":
                        startPointSubstring = 1195;
                        groupIndex = 1;
                        foreach (TodoItem task in toDoQuarter.GetItems())
                        {
                            FormatTaskString(task, startPointSubstring, groupIndex, EisenhowerMatrix);

                            startPointSubstring += 72;

                            groupIndex++;

                        }
                        break;
                    default:
                        
                        break;
                }
                
            }


            return EisenhowerMatrix.ToString();
        }

        public void FormatTaskString(TodoItem task, int StartPoint, int index, StringBuilder EisenhowerMatrix)
        {
            string taskString = index.ToString() + ". " + task.ToString();

            string stringToRemove = new string(' ', taskString.ToString().Length);

            EisenhowerMatrix.Replace(stringToRemove, taskString, StartPoint, taskString.ToString().Length);


        }

        public StringBuilder EmptyMatrix()
        {
            StringBuilder EisenhowerMatrix = new StringBuilder();

            EisenhowerMatrix.AppendLine("    |            URGENT              |           NOT URGENT           |");
            EisenhowerMatrix.AppendLine("  --|--------------------------------|--------------------------------|--");
            EisenhowerMatrix.AppendLine("    |                                |                                | ");
            EisenhowerMatrix.AppendLine("    |                                |                                |");
            EisenhowerMatrix.AppendLine("  I |                                |                                |");
            EisenhowerMatrix.AppendLine("  M |                                |                                |");
            EisenhowerMatrix.AppendLine("  P |                                |                                |");
            EisenhowerMatrix.AppendLine("  O |                                |                                |");
            EisenhowerMatrix.AppendLine("  R |                                |                                |");
            EisenhowerMatrix.AppendLine("  T |                                |                                |");
            EisenhowerMatrix.AppendLine("  A |                                |                                |");
            EisenhowerMatrix.AppendLine("  N |                                |                                |");
            EisenhowerMatrix.AppendLine("  T |                                |                                |");
            EisenhowerMatrix.AppendLine("    |                                |                                |");
            EisenhowerMatrix.AppendLine("    |                                |                                |");
            EisenhowerMatrix.AppendLine("  --|--------------------------------|--------------------------------|--");
            EisenhowerMatrix.AppendLine("  N |                                |                                |");
            EisenhowerMatrix.AppendLine("  O |                                |                                |");
            EisenhowerMatrix.AppendLine("  T |                                |                                |");
            EisenhowerMatrix.AppendLine("    |                                |                                |");
            EisenhowerMatrix.AppendLine("  I |                                |                                |");
            EisenhowerMatrix.AppendLine("  M |                                |                                |");
            EisenhowerMatrix.AppendLine("  P |                                |                                |");
            EisenhowerMatrix.AppendLine("  O |                                |                                |");
            EisenhowerMatrix.AppendLine("  R |                                |                                |");
            EisenhowerMatrix.AppendLine("  T |                                |                                |");
            EisenhowerMatrix.AppendLine("  A |                                |                                |");
            EisenhowerMatrix.AppendLine("  N |                                |                                |");
            EisenhowerMatrix.AppendLine("  T |                                |                                |");
            EisenhowerMatrix.AppendLine("  --|--------------------------------|--------------------------------|--");


            return EisenhowerMatrix;

        }
    }
}