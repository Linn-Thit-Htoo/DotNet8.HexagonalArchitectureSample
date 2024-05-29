using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;

namespace DotNet8.HexagonalArchitectureSample.Ports.Blog
{
    public interface IBlogRepository
    {
        Task<BlogListResponseModel> GetBlogsListAsync();
        Task<BlogModel> GetBlogByIdAsync(long id);
        Task<int> CreateBlogAsync(BlogRequestModel requestModel);
        Task<int> PatchBlogAsync(BlogRequestModel requestModel, long id);
        Task<int> DeleteBlogAsync(long id);
    }
}
