# **To-Do List Console Application**

## **Project Overview**

The To-Do List Console Application is a simple yet powerful tool that allows users to manage tasks efficiently from the command line. It includes features for adding tasks with due dates, marking tasks as complete, prioritizing tasks, handling recurring tasks, and more. This application is built using C# and follows best practices in software development, including unit testing and Agile methodology.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-Started)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Testing](#test)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgements](#acknowledgements)
- 
- 

## **Features**

- **Add Tasks**: Users can add tasks with descriptions, due dates, priorities (High, Medium, Low), and recurrence intervals (None, Daily, Weekly, Monthly).
- **Remove Tasks**: Users can remove tasks from their to-do list.
- **Mark Tasks as Complete**: Users can mark tasks as complete, and recurring tasks will automatically update their due dates.
- **View Tasks**: Users can list all tasks, view overdue tasks, and see tasks due soon.
- **Task Prioritization**: Tasks can be prioritized, and the list can be sorted by priority.
- **Recurring Tasks**: Supports recurring tasks, automatically updating their due dates upon completion.
- **File Persistence**: Tasks are saved to a JSON file to persist data across sessions.

## **Getting Started**

### **Prerequisites**

- .NET SDK (version 5.0 or later)
- A command-line interface (CLI) or terminal
- Git (for version control)

### **Installation**

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/todo-console-app.git
   cd todo-console-app
   ```
2. **Build the Project**
   
   ```bash
   dotnet build`
   ```
3. **Run the Application**

   ```bash
   dotnet run`
   ```

### **Usage**
Once the application is running, you will be presented with a menu of options:

1. Add Task: Add a new task with a description, due date, priority, and recurrence interval.
2. Remove Task: Remove a task by selecting its number.
3. Mark Task as Complete: Mark a task as complete, and update recurring tasks as needed.
4. List Tasks: View all tasks, their statuses, and due dates.
5. Sort Tasks:
   - Sort by Duedate.
   - Sort by Priority.
   - Sort by Recurrence Interval
     
6. Update Task Due Date: Change the due date for a specific task.
7. View Overdue Tasks: Display tasks that are past their due dates.
8. View Tasks Due Soon: View tasks that are due within the next few days.
9. Sort Tasks by Priority: Display tasks sorted by their priority.
10. Manage Recurring Tasks: Automatically update recurring tasks based on their intervals.
11. Exit: Save all tasks and exit the application.

## **Project Structure**

```plaintext
ToDoList/
│
├── ToDoListApp.Tests/
|   ├── TaskServiceTest.cs
│   └── ToDOListApp.Test.csproj
│
|── ToDoList/
|   |── Model/
|   |   └── MyTask.cs
|   |── Service/
|   |   └── TaskService.cs
|   |── UI/
|   |   └── UserInput.cs
|   |── Program.cs
|   └── ToDoListApp.csproj
|
└── ToDoListApp.sln
```

   - `Program.cs`: The entry point of the application. Handles the main menu and user interactions.
   - `MyTask.cs`: Represents a task with properties such as description, due date, priority, and recurrence interval.
   - `TaskService.cs`: Contains business logic for managing tasks, including adding, removing, sorting, and handling recurring tasks.
   - `UserInput.cs`: Manages user interface components, such as displaying menus and task lists.
   - `TaskServiceTests.cs`: Contains unit tests for TaskService, ensuring that task management functions correctly.

## **Testing**
Unit tests have been written using NUnit. To run the tests, use the following command:

```bash
dotnet test
```
Ensure all tests pass to confirm that the application behaves as expected.

## **Contributing**
If you would like to contribute to this project, please follow these steps:

- Fork the Repository: Click on the "Fork" button at the top right of this page.

- Clone the Forked Repository: Use the git clone command to clone your forked repository to your local machine.

- Create a New Branch: Create a branch for your feature or bug fix.

  ```bash
  git checkout -b feature/your-feature-name
  ```
- Make Your Changes: Implement your changes and commit them with clear and descriptive messages.

- Push to Your Fork: Push your changes to your forked repository.

  ```bash
  git push origin feature/your-feature-name
  ```
- Submit a Pull Request: Open a pull request on the original repository, describing your changes.

## **License**
This project is licensed under the MIT License. See the LICENSE file for details.

## **Acknowledgments**
Special thanks to the C# and .NET community for their valuable resources and support.
   
