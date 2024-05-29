using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.HexagonalArchitectureSample.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
    private readonly BL_Blog _bL_Blog;

    public BlogController(BL_Blog bL_Blog)
    {
        _bL_Blog = bL_Blog;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        try
        {
            var lst = await _bL_Blog.GetBlogsAsync();
            return Content(lst);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(long id)
    {
        try
        {
            var item = await _bL_Blog.GetBlogByIdAsync(id);
            return Content(item);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
    {
        try
        {
            int result = await _bL_Blog.CreateBlogAsync(requestModel);
            return result > 0 ? StatusCode(201, "Blog Created.") : BadRequest("Creating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, long id)
    {
        try
        {
            int result = await _bL_Blog.PatchBlogAsync(requestModel, id);
            return result > 0 ? StatusCode(201, "Blog Updated.") : BadRequest("Updating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBLog(long id)
    {
        try
        {
            int result = await _bL_Blog.DeleteBlogAsync(id);
            return result > 0 ? StatusCode(201, "Blog Deleted.") : BadRequest("Deleting Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}