using System;
using System.Threading.Tasks;
using ToDoListApp.Model;
using ToDoListApp.Service;
using static System.Collections.Specialized.BitVector32;

namespace ToDoListApp.UI
{
    public class UserInput
    {
        public (string Title, string Description, DateTime DueDate) GetUserInput()
        {
            Console.Write("\n");

            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("");

            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("");

            Console.Write("Due-date (YYYY-mm-dd): ");
            DateTime dueDate;

            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Wrong Date Format!!! Please enter correct format");
            }

            return (title, description, dueDate);
        }

        public int GetTaskIndex(string action)
        {
            Console.Write($"Enter Task Index/Position to be {action}: ");
            int taskIndex;

            while (!int.TryParse(Console.ReadLine(), out taskIndex) || taskIndex < 1)
            {
                Console.WriteLine("Kindly Enter a Correct Task Index (e.g 1,2,3...)");
            }
            return taskIndex;
        }

        public DateTime GetTaskNewDueDate()
        {
            Console.Write("\nEnter a New Due-Date (YYYY-mm-dd): ");
            DateTime newDueDate;

            while (!DateTime.TryParse(Console.ReadLine(), out newDueDate))
            {
                Console.WriteLine("Kindly Enter a Correct Date Format (YYYY-mm-dd)");
            }

            return newDueDate;
        }

        public int GetNumberOfDays()
        {
            Console.Write("\nEnter the number of days to check for upcoming due tasks: ");
            int days;

            while (!int.TryParse(Console.ReadLine(), out days) || days < 1)
            {
                Console.WriteLine("\nKindly Enter a specific Number of day(s) (e.g 1,2,3...)");
            }
            return days;
        }

    }
}
