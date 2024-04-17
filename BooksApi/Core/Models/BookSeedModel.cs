using Newtonsoft.Json;

namespace BooksApi.Core.Models
{
    public class BookSeedModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [JsonProperty("publication_year")]
        public string PublicationYear { get; set; }
        [JsonProperty("genre")]
        public List<string> Genre { get; set; }
        public string Description { get; set; }
        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }
    }
}
