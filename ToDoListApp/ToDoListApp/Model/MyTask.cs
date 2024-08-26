using System;
using System.Text.Json.Serialization;

namespace ToDoListApp.Model
{
    public class MyTask
    {
        [JsonInclude]
        private string Title { get; set; }
        [JsonInclude]
        private string Description { get; set; }
        [JsonInclude]
        private DateTime DueDate { get; set; }
        [JsonInclude]
        private bool IsCompleted { get; set; }

        [JsonConstructor]
        public MyTask(string title, string description, DateTime dueDate, bool isCompleted)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }

        public MyTask(string title, string description, DateTime dueDate) {
            
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
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
        public void setDueDate(DateTime newDueDate)
        {
            DueDate = newDueDate;
        }
        public bool GetIsCompleted() 
        { 
            return IsCompleted;
        }
        public void SetIsCompleted(bool status)
        {
            this.IsCompleted = status;
        }
    }
}
