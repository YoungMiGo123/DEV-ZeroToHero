namespace ZeroToHero.Collections.TodoApp
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"\nId:\t {Id}\nDescription:\t {Description}\nPriority:\t {Priority}\nCompleted:\t {IsCompleted}\n";
        }
    }

    public enum Priority
    {
        High = 1,
        Medium = 2,
        Low = 3,
    }
}
