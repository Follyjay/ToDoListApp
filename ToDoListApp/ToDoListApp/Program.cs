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
            // Instance of TaskService and UserInput Object
            TaskService taskService = new TaskService();
            UserInput myInput = new UserInput();

            bool exit = false;

            while (!exit)
            {

                //Prints the welcome message on screen
                Console.WriteLine("WELCOME TO TASK MANAGER");

                // Menu/Option Outline
                Console.Write("\n1: Create Task \n2: Remove Task " +
                    "\n3: View Task List \n4: Mark Task as Completed" +
                    "\n5: Exit\n\n");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        // UserInput object to get the users' input
                        var addNew = myInput.GetUserInput();

                        //Creates an new To-do-list event
                        MyTask newTask = new MyTask(addNew.Title, addNew.Description, addNew.DueDate);

                        //Adds a new event to the collection
                        taskService.AddTask(newTask);

                        //Print message upon successful addition of a new event
                        Console.WriteLine("Task added successfully!\n\n");
                        break;

                    case "2":
                        var getIndex = myInput.GetTaskIndex();

                        if (taskService.RemoveTask(getIndex))
                        {
                            //Print message upon successful addition of a new event
                            Console.WriteLine("Task Removed successfully!\n\n");
                        }
                        else
                        {
                            Console.WriteLine("Task Not Found\n\n");
                        }

                        break;

                    case "3":
                        var taskList = taskService.GetTasks();
                        if (taskList.Count > 0)
                        {
                            for (int i = 0; i < taskList.Count; i++)
                            {
                                var task = taskList[i];

                                Console.WriteLine($"{i + 1}: {task.GetTitle().ToUpper() }" + 
                                    $"{ task.GetDueDate() } { task.isCompleted }");
                            }

                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Empty List !!!\n Kindly Add new Tasks\n\n");
                        }

                        break;

                    case "4":
                        var taskIndex = myInput.GetTaskIndex();

                        if (taskService.TaskIsComplete(taskIndex))
                        {
                            Console.WriteLine("Task Completed Successfully\n\n");
                        }
                        else
                        {
                            Console.WriteLine("Task not Found\n\n");
                        }

                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input! Please Try Again...\n\n");
                        break;
                }

            }
            
        }

    }
}

