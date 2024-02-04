using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ZeroToHero.Collections.TodoApp
{
    public class TaskManager
    {
        private List<TaskItem> _tasks { get; set; } = [];
        public TaskManager()
        {
            Initialize();
        }

        public void AddTask()
        {
            //Read user input 
            // Create a new task
            // Add the task to the list
            Logger.Log("Welcome to the To-Do List Manager! You are about to create a new task");
            Logger.Log("Enter the task description: ");
            var description = InputReader.ReadUserInput();

            Logger.Log("Enter the task priority (1 - High, 2 - Medium, 3 - Low): ");
            var priority = InputReader.ReadUserInput();

            List<string> validInputs = ["1", "2", "3"];

            if(!validInputs.Contains(priority))
            {
                Logger.LogError("Invalid priority. Please try again.");
                return;
            }
            var lastTask = _tasks.LastOrDefault();

            var task = new TaskItem()
            {
                Id = lastTask is not null ? lastTask.Id + 1 : 1,
                Description = description,
                Priority = (Priority)Enum.Parse(typeof(Priority), priority),
                IsCompleted = false
            };

            _tasks.Add(task);
            Save();
        }

        public void MarkTaskAsCompleted()
        {
            Logger.Log("Enter the task id to mark as completed: ");
            var taskId = Convert.ToInt32(InputReader.ReadUserInput(), CultureInfo.InvariantCulture);
            if(!_tasks.Any(t => t.Id == taskId))
            {
                Logger.LogError("Invalid task id. Please try again.");
                return;
            }
            _tasks[taskId].IsCompleted = true;
            Save();
        }

        public void ViewTasks()
        {
            // View the tasks
            if(_tasks.Count == 0)
            {
                Logger.Log("No tasks to display");
                return;
            }

            Logger.Log("Task List:");
            foreach (var task in _tasks)
            {
                Logger.Log(task.ToString());
            }
        }

        public void DisplayMenu()
        {
            // Display the options to the user.
            Logger.Log("\nMenu:\n");
            Logger.Log("1. Add Task");
            Logger.Log("2. Mark Task as Completed");
            Logger.Log("3. View Tasks");
            Logger.Log("4. Exit");
            Logger.Log("\nEnter your choice: \n");
        }

        public void Exit()
        {
            // Exit the application
            // Clear the data and dispose of resources
            Save();
            Logger.Log("\nExiting To-Do List Manager. Goodbye!\n");
        }

        private void Save()
        {
            // Save the tasks to a file
            var tasks = JsonConvert.SerializeObject(_tasks);
            File.WriteAllText("saved_tasks.json", tasks);
        }

        private void Initialize()
        {
            // Load the tasks from the file
            if (File.Exists("saved_tasks.json"))
            {
                var tasks = File.ReadAllText("saved_tasks.json");
                _tasks = JsonConvert.DeserializeObject<List<TaskItem>>(tasks);
            }
        }
    }
}
