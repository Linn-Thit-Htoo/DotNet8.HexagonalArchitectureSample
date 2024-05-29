using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;

namespace DotNet8.HexagonalArchitectureSample.Models.Setup;

public static class ChangeModel
{
    public static BlogModel Change(this TblBlog dataModel)
    {
        return new BlogModel
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }

    public static TblBlog Change(this BlogRequestModel requestModel)
    {
        return new TblBlog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
    }
}