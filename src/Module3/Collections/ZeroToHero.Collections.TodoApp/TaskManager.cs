namespace ZeroToHero.Collections.TodoApp
{
    public class TaskManager
    {
        private SortedList<Priority, TaskItem> _tasks { get; set; } = [];
        public void AddTask()
        {
            TaskItem task;
            // Add the task to the list
        }

        public void MarkTaskAsCompleted()
        {
            TaskItem task;
            // Mark the task as completed
        }

        public void ViewTasks()
        {
            // View the tasks

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
            Logger.Log("\nExiting To-Do List Manager. Goodbye!\n");
        }
    }
}
