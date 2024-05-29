using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;
using DotNet8.HexagonalArchitectureSample.Ports.Blog;

namespace DotNet8.HexagonalArchitectureSample.Features.Blog
{
    public class DA_Blog
    {
        private readonly IBlogRepository _blogRepository;

        public DA_Blog(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogListResponseModel> GetBlogsAsync()
        {
            return await _blogRepository.GetBlogsListAsync();
        }
    }
}
