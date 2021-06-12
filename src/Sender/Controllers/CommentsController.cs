using Core.Contracts;
using Core.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IRequestClient<CommentRequest> _client;

        public CommentsController(IRequestClient<CommentRequest> client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> FetchCommentsByPostAsnyc([FromQuery] int postId)
        {
            using var request = _client.Create(new CommentRequest { PostId = postId });
            var response = await request.GetResponse<CommentResponse>();
            IEnumerable<Comment> comments = response.Message.Comments;
            return Ok(comments);
        }
    }
}
