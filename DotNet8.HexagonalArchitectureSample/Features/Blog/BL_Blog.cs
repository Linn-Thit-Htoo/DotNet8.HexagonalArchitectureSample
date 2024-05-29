using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;

namespace DotNet8.HexagonalArchitectureSample.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dA_Blog;

        public BL_Blog(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }

        public async Task<BlogListResponseModel> GetBlogsAsync()
        {
            return await _dA_Blog.GetBlogsAsync();
        }
    }
}
