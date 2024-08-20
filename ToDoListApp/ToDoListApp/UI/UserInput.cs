using System;

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
            Console.WriteLine("Enter Task Position to be Removed: ");
            int taskIndex;

            while (!int.TryParse(Console.ReadLine(), out taskIndex) || taskIndex < 1)
            {
                Console.WriteLine("Kindly Enter a Correct Task Index (e.g 1,2,3...)");
            }
            return taskIndex;
        }

    }
}
