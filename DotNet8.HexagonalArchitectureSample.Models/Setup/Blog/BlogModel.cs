namespace DotNet8.HexagonalArchitectureSample.Models.Setup.Blog
{
    public class BlogModel
    {
        public long BlogId { get; set; }

        public string BlogTitle { get; set; } = null!;

        public string BlogAuthor { get; set; } = null!;

        public string BlogContent { get; set; } = null!;
    }
}