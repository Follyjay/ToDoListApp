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
            Assert.That(title, Is.EqualTo(tasks[0].GetTitle()));
            Assert.That(description, Is.EqualTo(tasks[0].GetDescription()));
            Assert.That(dueDate, Is.EqualTo(tasks[0].GetDueDate()));
            Assert.That(tasks[0].isCompleted, Is.False);
        }

        [Test]
        public void RemoveTask_Should_RemoveTaskFromList()
        {
            // Arrange
            TaskService taskService = new TaskService();

            var title = "Appointment";
            var description = "Remove this Appointment";
            var dueDate = DateTime.Now.AddDays(1);

            // Act

            taskService.AddTask(new MyTask(title, description, dueDate));
            var result = taskService.RemoveTask(0);
            // Asserts

            var tasks = taskService.GetTasks();

            Assert.That(result, Is.True);
            Assert.That(tasks.Count, Is.EqualTo(0));
        }

        [Test]
        public void TaskIsComplete_Should_ChangeTaskStatusToComplete()
        {
            // Arrange
            TaskService taskService = new TaskService();

            var title = "Appointment";
            var description = "Complete this Appointment";
            var dueDate = DateTime.Now.AddDays(1);

            // Act

            taskService.AddTask(new MyTask(title, description, dueDate));
            var result = taskService.TaskIsComplete(0);
            // Asserts

            var tasks = taskService.GetTasks();

            Assert.That(result, Is.True);
            Assert.That(tasks[0].isCompleted, Is.True);
        }
    }
}
