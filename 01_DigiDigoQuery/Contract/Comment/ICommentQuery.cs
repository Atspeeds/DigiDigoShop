using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;

namespace _01_DigiDigoQuery.Contract.Comment
{
    public interface ICommentQuery
    {
        List<CommentQueryModel> GetAll(long productid);
        string Add(AddCommentQueryModel command);
    }
}
