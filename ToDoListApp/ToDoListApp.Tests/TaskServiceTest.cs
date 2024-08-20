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

            var title = "test";
            var description = "Remove test";
            var dueDate = DateTime.Now.AddDays(1);

            // Act
            taskService.AddTask(new MyTask(title, description, dueDate));
            var result = taskService.RemoveTask(1);

            var tasks = taskService.GetTasks();

            // Asserts
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
            var result = taskService.TaskIsComplete(1);

            var tasks = taskService.GetTasks();

            // Asserts
            Assert.That(result, Is.True);
            Assert.That(tasks[0].isCompleted, Is.True);
        }

        [Test]
        public void GetTasks_Should_GetCorrectTasks_BasedOnFilter ()
        {
            // Arrange
            TaskService taskService = new();
           
            // Act
            taskService.AddTask(new MyTask("task 1", "Completed Task", DateTime.Now));
            taskService.AddTask(new MyTask("task 2", "Pending Task", DateTime.Now.AddDays(1)));
            taskService.TaskIsComplete(1);

            var allTasks = taskService.GetTasks();
            var completedTasks = taskService.GetTasks(showCompleted: true, showPending: false);
            var pendingTasks = taskService.GetTasks(showCompleted: false, showPending: true);

            // Asserts
            Assert.That(2, Is.EqualTo(allTasks.Count));
            Assert.That(1, Is.EqualTo(completedTasks.Count));
            Assert.That(1, Is.EqualTo(pendingTasks.Count));
            Assert.That(allTasks[0].isCompleted, Is.True);
            Assert.That(allTasks[1].isCompleted, Is.False);
        }

        [Test]
        public void SaveAndLoadTasks_Should_SaveAndLoadDataFromFile()
        {
            // Arrange
            TaskService taskService = new();
            string filePath = "test.json";

            // Act
            taskService.AddTask(new MyTask("task 1", "Completed Task", DateTime.Now));
            taskService.AddTask(new MyTask("task 2", "Pending Task", DateTime.Now.AddDays(1)));
            taskService.SaveTaskToFile(filePath);

            taskService.LoadTaskFromFile(filePath);
            var loadedTasks = taskService.GetTasks();

            // Asserts
            Assert.That(2, Is.EqualTo(loadedTasks.Count));
            Assert.That("task 1", Is.EqualTo(loadedTasks[0].GetTitle()));

            // Delete File
            File.Delete(filePath);
        }
    }
}
