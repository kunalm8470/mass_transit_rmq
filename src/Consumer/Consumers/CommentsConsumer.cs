using Consumer.Interfaces;
using Core.Contracts;
using Core.Models;
using MassTransit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    public class CommentsConsumer : IConsumer<CommentRequest>
    {
        private readonly ICommentLoaderService _commentLoaderService;
        public CommentsConsumer(ICommentLoaderService commentLoaderService)
        {
            _commentLoaderService = commentLoaderService;
        }

        public async Task Consume(ConsumeContext<CommentRequest> context)
        {
            IEnumerable<Comment> comments = await _commentLoaderService.FetchCommentRangeAsync(context.Message.PostId);
            CommentResponse response = new CommentResponse
            {
                Comments = comments
            };
            await context.RespondAsync(response);
        }
    }
}
