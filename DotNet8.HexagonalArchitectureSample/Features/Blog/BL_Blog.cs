using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;

namespace DotNet8.HexagonalArchitectureSample.Features.Blog;

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

    public async Task<BlogModel> GetBlogByIdAsync(long id)
    {
        if (id <= 0)
            throw new Exception("Id is invalid.");

        return await _dA_Blog.GetBlogByIdAsync(id);
    }

    public async Task<int> CreateBlogAsync(BlogRequestModel requestModel)
    {
        #region Validation

        if (string.IsNullOrEmpty(requestModel.BlogTitle))
            throw new Exception("Blog Title cannot be empty.");

        if (string.IsNullOrEmpty(requestModel.BlogAuthor))
            throw new Exception("Blog Author cannot be empty.");

        if (string.IsNullOrEmpty(requestModel.BlogContent))
            throw new Exception("Blog Content cannot be empty.");

        #endregion

        return await _dA_Blog.CreateBlogAsync(requestModel);
    }

    public async Task<int> PatchBlogAsync(BlogRequestModel requestModel, long id)
    {
        if (id <= 0)
            throw new Exception("Id is invalid.");

        return await _dA_Blog.PatchBlogAsync(requestModel, id);
    }

    public async Task<int> DeleteBlogAsync(long id)
    {
        if (id <= 0)
            throw new Exception("Id is invalid.");

        return await _dA_Blog.DeleteBlogAsync(id);
    }
}