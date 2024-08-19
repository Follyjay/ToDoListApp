using System;

namespace ToDoListApp.UI
{
    public class UserInput
    {
        public (string Title, string Description, DateTime DueDate) GetUserInput()
        {
            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Due-date (YYYY-mm-dd):");
            DateTime dueDate;

            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Wrong Date Format!!! Please enter correct format");
            }

            //DateTime dueDate = DateTime.Parse(Console.ReadLine());

            return (title, description, dueDate);
        }

        public int GetTaskIndex()
        {
            Console.WriteLine("Enter the Index of the Task to be Removed: ");
            int taskIndex;

            while (!int.TryParse(Console.ReadLine(), out taskIndex) || taskIndex < 0)
            {
                Console.WriteLine("Kindly Enter a Correct Task Index");
            }
            return taskIndex;
        }
    }
}
