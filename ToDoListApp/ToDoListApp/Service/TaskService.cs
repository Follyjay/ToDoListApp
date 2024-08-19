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
            if (tasks.Count >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                return true;
            }
            return false;
        }

        public List<MyTask> GetTasks()
        {
            return tasks;
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
