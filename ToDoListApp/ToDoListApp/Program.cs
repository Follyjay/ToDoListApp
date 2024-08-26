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
                    "\n3: Update Task Due-Date \n4: Mark Task as Completed" +
                    "\n5: View Task List \n6: Sort Tasks By Due-Date" +
                    "\n7: View Overdue Tasks \n8: View Tasks Due Soon" +
                    "\n9: Exit\n\n");
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
                        int indexOfTaskToBeUpdated = myInput.GetTaskIndex("Updated");
                        DateTime newDueDate = myInput.GetTaskNewDueDate();

                        if (taskService.UpdateDueDate(indexOfTaskToBeUpdated, newDueDate))
                        {
                            Console.WriteLine("\nTask due date updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to Update Task Deu-Date !!!");
                        }

                        break;

                    case "4":
                        int taskIndexToBeCompleted = myInput.GetTaskIndex("Completed");

                        if (taskService.TaskIsComplete(taskIndexToBeCompleted))
                        {
                            Console.WriteLine("Task Completed Successfully\n");
                        }
                        else
                        {
                            Console.WriteLine("Task not Found\n");
                        }

                        break;

                    case "5":
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

                    case "6":
                        var sortedList = taskService.SortTasksByDueDate();
                        taskService.DisplayTaskSortedByDUeDate(sortedList);
                        break;

                    case "7":
                        var overdueTasks = taskService.OverDueTasks();
                        Console.WriteLine("\nOverdue Tasks:");
                        Console.WriteLine("----------------------\n");

                        if (overdueTasks.Count < 1)
                        {
                            Console.WriteLine("No Overdue Tasks");
                        }
                        else
                        {
                            taskService.DisplayTasks(overdueTasks);
                        }

                        break;

                    case "8":
                        int days = myInput.GetNumberOfDays();
                        var tasksDueSoon = taskService.TasksDueSoon(days);

                        Console.WriteLine($"Tasks due within the next {days} days:\n");

                        if (tasksDueSoon.Count < 1)
                        {
                            Console.WriteLine("No tasks are due within the specified time frame.");
                        }
                        else
                        {
                            taskService.DisplayTasks(tasksDueSoon);
                        }

                        break;

                    case "9":
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

