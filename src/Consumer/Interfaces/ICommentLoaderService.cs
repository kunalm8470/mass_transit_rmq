using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consumer.Interfaces
{
    public interface ICommentLoaderService
    {
        public Task<IEnumerable<Comment>> FetchCommentRangeAsync(int postId);
    }
}
