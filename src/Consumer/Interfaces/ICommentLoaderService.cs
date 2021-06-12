using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consumer.Interfaces
{
    public interface ICommentLoaderService
    {
        public Task<IEnumerable<Comment>> FetchCommentsForPostAsync(int postId);
    }
}
