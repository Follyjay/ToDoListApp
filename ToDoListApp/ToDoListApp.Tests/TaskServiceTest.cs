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

            taskService.AddTask(new MyTask(title, description, dueDate, "Low", "None"));

            // Asserts

            var tasks = taskService.GetTasks();

            Assert.That(tasks.Count, Is.EqualTo(1));
            Assert.That(title, Is.EqualTo(tasks[0].GetTitle()));
            Assert.That(description, Is.EqualTo(tasks[0].GetDescription()));
            Assert.That(dueDate, Is.EqualTo(tasks[0].GetDueDate()));
            Assert.That(tasks[0].GetIsCompleted(), Is.False);
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
            taskService.AddTask(new MyTask(title, description, dueDate, "Low", "None"));
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
            taskService.AddTask(new MyTask(title, description, dueDate, "Low", "None"));
            var result = taskService.TaskIsComplete(1);

            var tasks = taskService.GetTasks();

            // Asserts
            Assert.That(result, Is.True);
            Assert.That(tasks[0].GetIsCompleted(), Is.True);
        }

        [Test]
        public void GetTasks_Should_GetCorrectTasks_BasedOnFilter ()
        {
            // Arrange
            TaskService taskService = new();
           
            // Act
            taskService.AddTask(new MyTask("task 1", "Completed Task", DateTime.Now, "Low", "None"));
            taskService.AddTask(new MyTask("task 2", "Pending Task", DateTime.Now.AddDays(1), "Low", "None"));
            taskService.TaskIsComplete(1);

            var allTasks = taskService.GetTasks();
            var completedTasks = taskService.GetTasks(showCompleted: true, showPending: false);
            var pendingTasks = taskService.GetTasks(showCompleted: false, showPending: true);

            // Asserts
            Assert.That(2, Is.EqualTo(allTasks.Count));
            Assert.That(1, Is.EqualTo(completedTasks.Count));
            Assert.That(1, Is.EqualTo(pendingTasks.Count));
            Assert.That(allTasks[0].GetIsCompleted(), Is.True);
            Assert.That(allTasks[1].GetIsCompleted(), Is.False);
        }

        [Test]
        public void SaveAndLoadTasks_Should_SaveAndLoadDataFromFile()
        {
            // Arrange
            TaskService taskService = new();
            string filePath = "test.json";

            // Act
            taskService.AddTask(new MyTask("task 1", "Completed Task", DateTime.Now, "Low", "None"));
            taskService.AddTask(new MyTask("task 2", "Pending Task", DateTime.Now.AddDays(1), "Low", "None"));
            taskService.SaveTaskToFile(filePath);

            taskService.LoadTaskFromFile(filePath);
            var loadedTasks = taskService.GetTasks();

            // Asserts
            Assert.That(2, Is.EqualTo(loadedTasks.Count));
            Assert.That("task 1", Is.EqualTo(loadedTasks[0].GetTitle()));

            // Delete File
            File.Delete(filePath);
        }
      
        [Test]
        public void SortTaskByDueDate_Should_ReturnListOfTaskOderedByDueDate()
        {
            // Arrange
            TaskService taskService = new();

            // Act
            taskService.AddTask(new MyTask("task 1", "description 1", DateTime.Now.AddDays(2), "Low", "None"));
            taskService.AddTask(new MyTask("task 2", "description 2", DateTime.Now.AddDays(1), "Low", "None"));
            taskService.AddTask(new MyTask("task 3", "description 3", DateTime.Now, "Low", "None"));

            taskService.GetTasks();
            var sortedTasks = taskService.SortTasksByDueDate();

            // Assert
            Assert.That("task 3", Is.EqualTo(sortedTasks[0].GetTitle()));
            Assert.That("task 2", Is.EqualTo(sortedTasks[1].GetTitle()));
            Assert.That("task 1", Is.EqualTo(sortedTasks[2].GetTitle()));
        }

        [Test]
        public void OverDueTasks_Should_ReturnListOfTasks_ThatAreOverDue()
        {
            // Arrange
            TaskService taskService = new();

            // Act
            taskService.AddTask(new MyTask("Task 1", "This is a test", DateTime.Now.AddDays(-3), "Low", "None"));
            taskService.AddTask(new MyTask("Task 2", "This is another test", DateTime.Now.AddDays(1), "Low", "None"));

            var tasks = taskService.OverDueTasks();

            // Assert
            Assert.That(1, Is.EqualTo(tasks.Count));
            Assert.That("Task 1", Is.EqualTo(tasks[0].GetTitle()));
        }

        [Test]
        public void TasksDueSoon_Should_ReturnTasksThatWillBeDue_OnSetThreshold()
        {
            // Arrange
            TaskService taskService = new();

            // Act
            taskService.AddTask(new MyTask("Task 1", "This is a test", DateTime.Now.AddDays(3), "Low", "None"));
            taskService.AddTask(new MyTask("Task 2", "This is another test", DateTime.Now.AddDays(1), "Low", "None"));

            var tasks = taskService.TasksDueSoon(3);

            // Assert
            Assert.That(2,Is.EqualTo(tasks.Count));
            Assert.That("Task 1", Is.EqualTo(tasks[0].GetTitle()));
        }
      
    }
}
