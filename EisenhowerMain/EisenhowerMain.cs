using System;
using System.Collections.Generic;
namespace EisenhowerCore {
    public class EisenhowerMain {  
        // gówna funkcja s
        static public void Main(string[] args) {
            bool IsRunning = true;
            TodoMatrix TasksBoard = new TodoMatrix();
            while(IsRunning) {
                Console.WriteLine("Witajcie w matrycy Eisehowera...");
                Console.Write("1.Dodaj zadanie. \n2.Wyswietl wszystkie zadania. \n3.Oznacz zadanie jako wykonane/nie wykonane. \n4.Wyście. \nWybierz numer odpowiadający temu, co chcesz zrobić: ");
                string option = Console.ReadLine();
                switch(option) {
                    case "1":
                        string Title;
                        string InputDeadLine;
                        bool IsImportant = false;

                        Console.Write("Podaj nazwę zadania: ");
                        Title = Console.ReadLine();

                        bool ValidDeadLine = false;
                        DateTime DeadLine = DateTime.MinValue;
                        Console.WriteLine();
                        while(!ValidDeadLine) {
                            Console.Write("Podaj termin ważności (mm-dd):");
                            InputDeadLine = Console.ReadLine();
                            if(DateTime.TryParse(InputDeadLine, out DeadLine)) {
                                ValidDeadLine = true;
                            } else {
                                Console.WriteLine("Niepoprawny format daty!");
                            }
                        }

                        bool ValidIsImportant = false;
                        while(!ValidIsImportant) {
                            Console.Write("Czy to zadanie ma mieć status ważnego (tak/nie): ");
                            string InputIsImportant = Console.ReadLine();
                            
                            if(InputIsImportant == "tak" || InputIsImportant == "nie") {
                                IsImportant = true ? InputIsImportant == "tak" : false;
                                ValidIsImportant = true;
                            } else {
                                Console.WriteLine("Niepoprawne dane!");
                            }
                        }
                        
                        TasksBoard.AddItem(Title, DeadLine, IsImportant);
                        Console.WriteLine("Pomyślnie dodano zadanie do listy!");
                        break;

                        case "2":
                            Console.Clear();

                            Console.WriteLine(TasksBoard.FormattedMatrix());
                        
                        break;
                    case "3":
                        Console.Write("Podaj ćwiartkę w której chcesz odznaczyć/zaznaczyć zadanie (IU | IN | NU  | NN): ");
                        string QuarterInput = Console.ReadLine().ToUpper();
                        if(TasksBoard.GetQuarters().ContainsKey(QuarterInput)) {
                            TodoQuarter SelectedQuarter = TasksBoard.GetQuarter(QuarterInput);
                            List<string> QuarterTasks = SelectedQuarter.ToList();
                            Console.WriteLine("Wszytskie zadania w podanej ćwiartce: ");
                            for(int ItemNumber = 0; ItemNumber < QuarterTasks.Count; ItemNumber++) {
                                Console.WriteLine($"{ItemNumber +1}. {QuarterTasks[ItemNumber]}");
                            }
                            Console.Write("Podaj numer zadania które chcesz odznaczyć/zaznaczyć: ");
                            int ItemIndex = Convert.ToInt32(Console.ReadLine());
                            if(ItemIndex -1 >= 0 && ItemIndex -1 <= QuarterTasks.Count) {
                                TodoItem SelectedItem = SelectedQuarter.GetItem(ItemIndex -1);
                                if(SelectedItem.IsDone == true) {
                                    SelectedItem.Unmark();
                                    Console.WriteLine("Pomyślnie oznaczono zadanie jako nie wykonane!");
                                } else {
                                    SelectedItem.Mark();
                                    Console.WriteLine("Pomyślnie zaznaczono zadanie jako wykonane!");
                                }
                            } else {
                                Console.WriteLine("Nie ma takiego zadania!");
                            }
                        } else {
                            Console.WriteLine("Nie ma tekiej ćwiartki!");
                        }
                        break;
                    case "4":
                        IsRunning = false;
                        break;
                }
            }
        }
    }
}
