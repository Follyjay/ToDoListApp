using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
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
            else if (showCompleted && !showPending)
            {
                // Return only completed tasks when only showCompleted is true.
                return tasks.Where(t => t.GetIsCompleted()).ToList(); 
            }
            else if (!showCompleted && showPending)
            {
                // Return only pending tasks when only showPending is true.
                return tasks.Where(t => !t.GetIsCompleted()).ToList();  
            }
            else
            {
                // Return an empty list when both parameters are false.
                return new List<MyTask>();
            }
        }

        public void DisplayTasks(List<MyTask> tasks)
        {
            Console.WriteLine("");

            if (tasks.Count > 0)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    string status = tasks[i].GetIsCompleted() ? "Completed" : "Pending";

                    Console.WriteLine($"{i + 1}:  {tasks[i].GetTitle().ToUpper()}-: " +
                                        $"{tasks[i].GetDueDate()} {tasks[i].Priority} " + 
                                        $"{tasks[i].RecurrenceInterval} {status}");
                }
                Console.WriteLine("------------------------------------------------------\n");

            }
            else
            {
                Console.WriteLine("Empty List! Kindly Add new Tasks");
                Console.WriteLine("-------------------------------------\n");
            }

        }

        public void DisplayTaskSortedByDUeDate(List<MyTask> tasks)
        {
            Console.Write("");
            Console.WriteLine("List of Tasks Odered By Due-Date\n");

            DisplayTasks(tasks);
        }

        public bool TaskIsComplete(int index)
        {
            var getIndex = index - 1;

            if (tasks.Count >= 1 && getIndex < tasks.Count)
            {
                //bool status = true;

                tasks[getIndex].SetIsCompleted(true);
                //veTaskToFile(filePath);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveTaskToFile(string filePath)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true});
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save task: {ex.Message}");
            }
        }

        public void LoadTaskFromFile(string filePath) 
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);

                    Console.WriteLine("File Content:");
                    Console.WriteLine(jsonData);

                    var options = new JsonSerializerOptions
                    {
                        IncludeFields = true,
                        PropertyNameCaseInsensitive = true,
                    };
                    var loadData = JsonSerializer.Deserialize<List<MyTask>>(jsonData, options) ?? new List<MyTask>();

                    tasks.Clear();
                    tasks.AddRange(loadData);
                    DisplayTasks(tasks);
                }
                else
                {
                    Console.WriteLine("File Does Not Exist !!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Failed to Load File {ex.Message}");
            }
        }

        public List<MyTask> SortTasksByDueDate()
        {
            return tasks.OrderBy(t =>  t.GetDueDate()).ToList();
        }

        public bool UpdateDueDate(int index,  DateTime newDueDate)
        {
            int getIndex = index - 1;

            if (tasks.Count >= 1 && getIndex < tasks.Count)
            {
                tasks[getIndex].setDueDate(newDueDate);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MyTask> OverDueTasks()
        {
            return tasks.Where(t => t.GetDueDate() < DateTime.Now && t.GetIsCompleted().Equals(false)).ToList();
        }

        public List<MyTask> TasksDueSoon(int days)
        {
            DateTime dateThreshold = DateTime.Now.AddDays(days);
            return tasks.Where(t => t.GetDueDate() >= DateTime.Now && t.GetDueDate() <= dateThreshold).ToList();
        }

        public void UpdateRecurrentTasks()
        {
            var taskList = tasks.Where(t => t.GetIsCompleted().Equals(true) && t.RecurrenceInterval != "None").ToList();
            
            foreach (var task in taskList)
            {
                if (task.RecurrenceInterval.Equals("Daily"))
                {
                    task.setDueDate(task.GetDueDate().AddDays(1));
                }
                else if (task.RecurrenceInterval.Equals("Weekly"))
                {
                    task.setDueDate(task.GetDueDate().AddDays(7));
                }
                else if (task.RecurrenceInterval.Equals("Monthly"))
                {
                    task.setDueDate(task.GetDueDate().AddMonths(1));
                }
            }

        }

        public List<MyTask> SortTaskByPriority()
        {
            return tasks.OrderByDescending(t => t.Priority).ToList();
        }

        public List<MyTask> SortTaskByRecurrence()
        {
            return tasks.OrderByDescending(t => t.RecurrenceInterval).ToList();
        }
    }
}
