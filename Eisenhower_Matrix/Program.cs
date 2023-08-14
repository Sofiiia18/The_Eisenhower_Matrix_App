namespace Eisenhower_Matrix;

class Program
{
    
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Eisenhower!");
            Console.WriteLine("Add your task");
            string title = Console.ReadLine();
            while (title == null)
            {
                Console.WriteLine("Your task must containe a name.Add your task");
                title = Console.ReadLine();
            }
            Console.WriteLine("Add deadline day");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add deadline month");
            int month = Convert.ToInt32(Console.ReadLine());
            ToDoItem task = new ToDoItem(title, new DateTime(2023, month, day));
            Console.WriteLine(task.ToString());
        }
}


