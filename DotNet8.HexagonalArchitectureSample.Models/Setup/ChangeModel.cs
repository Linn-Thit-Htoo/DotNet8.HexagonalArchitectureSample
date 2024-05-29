using DotNet8.HexagonalArchitectureSample.DbService.Entities;
using DotNet8.HexagonalArchitectureSample.Models.Setup.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.HexagonalArchitectureSample.Models.Setup
{
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
    }
}
