using System;

namespace ToDoListApp.Model
{
    public class MyTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public bool isCompleted {  get; set; } = false;

        public MyTask(string title, string description, DateTime dueDate) {
            
            Title = title;
            Description = description;
            DueDate = dueDate;

        }
    }
}
