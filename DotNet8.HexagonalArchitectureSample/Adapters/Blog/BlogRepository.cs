using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Models.Setup;
using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;
using DotNet8.HexagonalArchitectureSample.Ports.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.HexagonalArchitectureSample.Adapters.Blog;

public class BlogRepository : IBlogRepository
{
    private readonly AppDbContext _appDbContext;

    public BlogRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region Get Blogs List Async

    public async Task<BlogListResponseModel> GetBlogsListAsync()
    {
        try
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Get Blog By Id Async

    public async Task<BlogModel> GetBlogByIdAsync(long id)
    {
        try
        {
            var item = await _appDbContext.TblBlogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);

            return item is null ? throw new Exception("No data found.") : item!.Change();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Create Blog Async

    public async Task<int> CreateBlogAsync(BlogRequestModel requestModel)
    {
        try
        {
            await _appDbContext.TblBlogs.AddAsync(requestModel.Change());
            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Patch Blog Async

    public async Task<int> PatchBlogAsync(BlogRequestModel requestModel, long id)
    {
        try
        {
            var item = await _appDbContext.TblBlogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id) ?? throw new Exception("No data found.");

            #region Patch Method Validation

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }

            #endregion

            _appDbContext.Entry(item).State = EntityState.Modified;

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Delete Blog Async

    public async Task<int> DeleteBlogAsync(long id)
    {
        try
        {
            var item = await _appDbContext.TblBlogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id) ?? throw new Exception("No data found.");

            _appDbContext.TblBlogs.Remove(item);

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion
}