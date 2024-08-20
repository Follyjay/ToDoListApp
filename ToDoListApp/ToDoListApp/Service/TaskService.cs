using System;
using System.Collections.Generic;
using ToDoListApp.Model;

namespace ToDoListApp.Service
{
    public class TaskService
    {
        private readonly List<MyTask> tasks;

        public TaskService()
        {
            tasks = new List<MyTask>();
        }

        public void AddTask(MyTask task)
        { 
            tasks.Add(task);
        }

        public bool RemoveTask(int index)
        {
            var getIndex = index - 1; // Convert to 0-based index

            // Validate the index before attempting to remove the task
            if (tasks.Count >= 1 && getIndex < tasks.Count)
            {
                // Remove task at the specified index
                tasks.RemoveAt(getIndex);
                // Indicate that the removal was successful
                return true;
            }
            return false;
        }

        public List<MyTask> GetTasks(bool showCompleted = true, bool showPending = true)
        {
            if (showCompleted && showPending)
            {
                // Return all tasks when both parameters are true.
                return tasks;  
            }
            else if (showCompleted)
            {
                // Return only completed tasks when only showCompleted is true.
                return tasks.Where(t => t.isCompleted).ToList(); 
            }
            else if (showPending)
            {
                // Return only pending tasks when only showPending is true.
                return tasks.Where(t => !t.isCompleted).ToList();  
            }
            else
            {
                // Return an empty list when both parameters are false.
                return new List<MyTask>();
            }
        }

        public void DisplayTasks(List<MyTask> tasks)
        {
            string status;

            Console.WriteLine("");

            if (tasks.Count > 0)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    var task = tasks[i];
                    status = task.isCompleted ? "Completed" : "Pending";

                    Console.WriteLine($"{i + 1}.  {task.GetTitle().ToUpper()}: " +
                                        $"{task.GetDueDate()} {status}");
                    Console.WriteLine("-----------------------------------------------\n");
                }

            }
            else
            {
                Console.WriteLine("Empty List! Kindly Add new Tasks");
                Console.WriteLine("-----------------------------------------------\n");
            }

        }

        public bool TaskIsComplete(int index)
        {
            if (tasks.Count >= 0 && index < tasks.Count)
            {
                tasks[index].isCompleted = true;
                return true;
            }
            return false;
        }
    }
}
