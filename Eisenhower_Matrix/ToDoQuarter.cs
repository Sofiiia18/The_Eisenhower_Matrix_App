using System;
namespace Eisenhower_Matrix
{
    public class ToDoQuarter
    {
        private List<ToDoItem> ToDoItems = new List<ToDoItem>();


        public ToDoQuarter()
        {
            List<string> ToDoQuarter = new List<string>();
        }

        public void AddItem(ToDoItem item)
        {
            ToDoItems.Add(item);
        }

        public void RemoveItem(int index)
        {
            ToDoItems.RemoveAt(index);
        }

        public void ArchiveItems()
        {
            foreach (ToDoItem item in ToDoItems)
            {
                if (item.IsDone)
                    ToDoItems.Remove(item);
            }
        }

        public ToDoItem GetItem(int index)
        {
            return ToDoItems[index];
        }

        public List<ToDoItem> GetItems()
        {
            return ToDoItems;
        }

        //public void ToString()
        //{
        //    foreach (ToDoItem item in ToDoItems)
        //    {
        //        item.ToString();
        //    }
        //}
    }
}

