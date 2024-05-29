using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Models.Setup;
using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;
using DotNet8.HexagonalArchitectureSample.Ports.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.HexagonalArchitectureSample.Adapters.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BlogListResponseModel> GetBlogsListAsync()
        {
            var lst = await _appDbContext.TblBlogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();

            var blogs = lst.Select(x => x.Change()).ToList();

            return new BlogListResponseModel
            {
                DataLst = blogs
            };
        }
    }
}
