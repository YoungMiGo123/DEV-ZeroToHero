namespace ZeroToHero.Collections.Console.List
{
    public class TaskItem(string description, Priority priority)
    {
        public string Description { get; set; } = description;
        public Priority TaskPriority { get; set; } = priority;
    }
}
