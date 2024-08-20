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
            Console.WriteLine("WELCOME TO TASK MANAGER");

            // Instance of TaskService and UserInput Object
            TaskService taskService = new();
            UserInput myInput = new();

            string path = "myFile.json"; // file path declaration 
            taskService.LoadTaskFromFile(path); // Load list of task from File

            bool exit = false;

            while (!exit)
            {
                // Menu/Option Outline
                Console.Write("\n1: Create Task \n2: Remove Task " +
                    "\n3: Mark Task as Completed \n4: View Task List" +
                    "\n5: Exit\n\n");
                Console.Write("Choose an option: ");
                Console.Write("");

                switch (Console.ReadLine())
                {
                    case "1":
                        // UserInput object to get the users' input
                        var (Title, Description, DueDate) = myInput.GetUserInput();

                        //Creates an new To-do-list event
                        MyTask newTask = new(Title, Description, DueDate);

                        //Adds a new event to the collection
                        taskService.AddTask(newTask);

                        //Print message upon successful addition of a new event
                        Console.WriteLine("Task added successfully!\n");
                        break;

                    case "2":
                        var getIndex = myInput.GetTaskIndex("Removed");

                        if (taskService.RemoveTask(getIndex))
                        {
                            //Print message upon successful addition of a new event
                            Console.WriteLine("Task Removed successfully!\n");
                        }
                        else
                        {
                            Console.WriteLine("Task Not Found\n");
                        }

                        break;

                    case "3":
                        var taskIndex = myInput.GetTaskIndex("Completed");

                        if (taskService.TaskIsComplete(taskIndex))
                        {
                            Console.WriteLine("Task Completed Successfully\n");
                        }
                        else
                        {
                            Console.WriteLine("Task not Found\n");
                        }

                        break;

                    case "4":
                        bool viewList = false;
                        List<MyTask> taskList = [];

                        bool complete = true;
                        bool pending = true;

                        Console.WriteLine("");
                        Console.Write("List Of All Added Task");

                        while (!viewList)
                        {
                            Console.WriteLine("\n");

                            Console.Write("1: View All Tasks \n2: View Completed Tasks" +
                                "\n3: View Pending Tasks \n4: Cancel\n\n");
                            Console.Write("Choose an Option: ");
                            Console.Write("");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    taskList = taskService.GetTasks();
                                    viewList = true;
                                    break;

                                case "2":
                                    taskList = taskService.GetTasks(complete, !pending);
                                    viewList = true;
                                    break;

                                case "3":
                                    taskList = taskService.GetTasks(!complete, pending);
                                    viewList = true;
                                    break;

                                case "4":
                                    viewList = true;
                                    break;

                                default:
                                    Console.WriteLine("Invalid Option! Try Again!!!");
                                    viewList = true;
                                    break;

                            }

                            taskService.DisplayTasks(taskList);

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
            
            taskService.SaveTaskToFile(path); // Save list of task into File

        }

    }
}

