namespace ZeroToHero.Collections.TodoApp
{
    public class ToDoAppDriver
    {
        public static void Run()
        {
            Logger.Log("Welcome to the To-Do List Manager!");
            var taskManager = new TaskManager();

            while (true)
            {
                taskManager.DisplayMenu();
                string choice = InputReader.ReadUserInput();


                switch (choice)
                {
                    case "1":
                        taskManager.AddTask();
                        break;
                    case "2":
                        taskManager.MarkTaskAsCompleted();
                        break;
                    case "3":
                        taskManager.ViewTasks();
                        break;
                    case "4":
                        taskManager.Exit();
                        return;
                    default:
                        Logger.LogError("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
