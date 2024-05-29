using DotNet8.HexagonalArchitectureSample.DbService.Entities;

namespace DotNet8.HexagonalArchitectureSample.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _appDbContext;

        public DA_Blog(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
