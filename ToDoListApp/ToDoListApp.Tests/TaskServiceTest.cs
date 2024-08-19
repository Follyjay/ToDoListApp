using ToDoListApp.Model;
using ToDoListApp.Service;

using System;

namespace ToDoListApp.Tests
{
    [TestFixture]
    public class TaskServiceTest
    {

        [Test]
        public void AddTask_Should_AddTaskToList()
        {
            // Arrange
            TaskService taskService = new TaskService();

            var title = "GP Appointment";
            var description = "Doctors appointment for tomorrow";
            var dueDate = DateTime.Now.AddDays(1);

            // Act

            taskService.AddTask(new MyTask(title, description, dueDate));

            // Asserts

            var tasks = taskService.GetTasks();

            Assert.That(tasks.Count, Is.EqualTo(1));
            Assert.That(title, Is.EqualTo(tasks[0].Title));
            Assert.That(description, Is.EqualTo(tasks[0].Description));
            Assert.That(dueDate, Is.EqualTo(tasks[0].DueDate));
            Assert.That(tasks[0].isCompleted, Is.False);
        }
    }
}
