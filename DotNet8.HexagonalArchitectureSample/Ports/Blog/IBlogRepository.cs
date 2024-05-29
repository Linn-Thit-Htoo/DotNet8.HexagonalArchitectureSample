using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;

namespace DotNet8.HexagonalArchitectureSample.Ports.Blog
{
    public interface IBlogRepository
    {
        Task<BlogListResponseModel> GetBlogsListAsync();
    }
}
