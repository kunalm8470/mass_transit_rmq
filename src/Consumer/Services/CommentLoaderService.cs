using Consumer.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consumer.Services
{
    public class CommentLoaderService : ICommentLoaderService
    {
        private readonly HttpClient _httpClient;
        public CommentLoaderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Comment>> FetchCommentsForPostAsync(int postId)
        {
            string url = $"/posts/{postId}/comments";
            string response = await _httpClient.GetStringAsync(url);
            return JsonSerializer.Deserialize<IEnumerable<Comment>>(response);
        }
    }
}
