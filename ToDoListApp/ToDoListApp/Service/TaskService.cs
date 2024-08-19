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

        public void AddNewTask(string title, string description, DateTime dueDate) 
        {
            MyTask newTask = new MyTask(title, description, dueDate);
            tasks.Add(newTask);
        }

        public List<MyTask> GetTasks()
        {
            return tasks;
        }
    }
}
