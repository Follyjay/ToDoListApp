using System;
using ToDoListApp.Model;
using ToDoListApp.Service;
using ToDoListApp.UI;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prints the welcome message on screen
            Console.WriteLine("You are welcome to your to-do-list");

            //Creates a UserInput object to get the users' input
            UserInput myInput = new UserInput();
            var result = myInput.GetUserInput();

            //Assisgning each field of the user data to a variable
            string title = result.Title;
            string description = result.Description;
            DateTime dueDate = result.DueDate;

            //Creates an new To-do-list event
            MyTask newTask = new MyTask(title, description, dueDate);

            //Adds a new event to the collection
            TaskService taskService = new TaskService();
            taskService.AddTask(newTask);

            //Print message upon successful addition of a new event
            Console.WriteLine("Task added successfully!");
        }

    }
}

