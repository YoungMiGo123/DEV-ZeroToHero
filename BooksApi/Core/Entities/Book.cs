using System.Text.Json.Serialization;

namespace BooksApi.Core.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsLoanedOut { get; set; }
        public bool IsPopular { get; set; }
        public BookCondition BookCondition { get; set; } = BookCondition.Good;
    }
    public enum BookCondition
    {
        Good,
        Fair,
        Poor,
        Damaged
    }
}
