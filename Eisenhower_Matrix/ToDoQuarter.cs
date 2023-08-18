using System;
using System.Collections.Generic;
namespace Eisenhower_Matrix
{
    public class ToDoQuarter
    {
        private List<ToDoItem> TodoItems { get; set; }
        //private List<ToDoItem> ToDoItems = new List<ToDoItem>();


        public ToDoQuarter()
        {
            TodoItems = new List<ToDoItem>();
            //List<string> ToDoQuarter = new List<string>();
        }

        public void AddItem(string Title, DateTime DeadLine) {
            TodoItems.Add(new ToDoItem(Title, DeadLine));
        }

        public void RemoveItem(int index)
        {
            TodoItems.RemoveAt(index);
        }

        public void ArchiveItems()
        {
            foreach (ToDoItem item in TodoItems)
            {
                if (item.IsDone)
                    TodoItems.Remove(item);
            }
        }

        public ToDoItem GetItem(int index)
        {
            return TodoItems[index];
        }

        public List<ToDoItem> GetItems()
        {
            return TodoItems;
        }

        public List<string> ToList() {
            List<string> ItemsToReturn = new List<string>();
            foreach(ToDoItem Item in TodoItems) {
                ItemsToReturn.Add(Item.ToString());
            }
            return ItemsToReturn;
        }
    }
}

