using System;
using System.Text.Json.Serialization;

namespace ToDoListApp.Model
{
    public class MyTask
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool isCompleted { get; private set; }

        public MyTask(string title, string description, DateTime dueDate) {
            
            Title = title;
            Description = description;
            DueDate = dueDate;
            isCompleted = false;
        }

        // Return methods for each property
        public string GetTitle()
        {
            return Title;   
        }
        public string GetDescription()
        { 
            return Description; 
        }
        public DateTime GetDueDate()
        {
            return DueDate;
        }
        public bool GetIsCompleted() 
        { 
            return isCompleted;
        }

        public void SetIsCompleted(bool status)
        {
            isCompleted = status;
        }
    }
}
