using System;

namespace ToDoListApp.Model
{
    public class MyTask
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private DateTime DueDate { get; set; }

        public bool isCompleted {  get; set; } = false;

        public MyTask(string title, string description, DateTime dueDate) {
            
            Title = title;
            Description = description;
            DueDate = dueDate;

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
    }
}
