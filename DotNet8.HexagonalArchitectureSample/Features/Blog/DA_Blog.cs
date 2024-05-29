using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;
using DotNet8.HexagonalArchitectureSample.Ports.Blog;

namespace DotNet8.HexagonalArchitectureSample.Features.Blog;

public class DA_Blog
{
    private readonly IBlogRepository _blogRepository;

    public DA_Blog(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogListResponseModel> GetBlogsAsync()
    {
        try
        {
            return await _blogRepository.GetBlogsListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<BlogModel> GetBlogByIdAsync(long id)
    {
        try
        {
            return await _blogRepository.GetBlogByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> CreateBlogAsync(BlogRequestModel requestModel)
    {
        try
        {
            return await _blogRepository.CreateBlogAsync(requestModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> PatchBlogAsync(BlogRequestModel requestModel, long id)
    {
        try
        {
            return await _blogRepository.PatchBlogAsync(requestModel, id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> DeleteBlogAsync(long id)
    {
        try
        {
            return await _blogRepository.DeleteBlogAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}