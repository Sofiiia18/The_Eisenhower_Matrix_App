using System;
using System.Collections.Generic;

namespace EisenhowerCore { 
    public class TodoQuarter {
        private List<TodoItem> TodoItems { get; set; }

        public TodoQuarter() {
            TodoItems = new List<TodoItem>();
        }
        public void AddItem(string Title, DateTime DeadLine) {
            TodoItems.Add(new TodoItem(Title, DeadLine));
        }
        public void RemoveItem(int Index) {
            if(Index >= 0 && Index < TodoItems.Count) {
                TodoItems.RemoveAt(Index);
            } 
            else {
                throw new IndexOutOfRangeException("Invalid index. Cannot remove item.Add");
            }
        }
        public void ArchiveItems() {
            foreach(TodoItem Item in TodoItems) {
                if(Item.IsDone == true) {
                    TodoItems.Remove(Item);
                }
            }
        }
        public TodoItem GetItem(int Index) {
            return TodoItems[Index];
        }
        public List<TodoItem> GetItems() {
            return TodoItems;
        }
        public List<string> ToList() {
            List<string> ItemsToReturn = new List<string>();
            foreach(TodoItem Item in TodoItems) {
                ItemsToReturn.Add(Item.ToString());
            }
            return ItemsToReturn;
        }
    }
}