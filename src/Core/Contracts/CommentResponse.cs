using Core.Models;
using System.Collections.Generic;

namespace Core.Contracts
{
    public class CommentResponse
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
