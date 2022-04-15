using BlazorBookReviews.Models;
using System.Net.Http.Json;

namespace BlazorBookReviews.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly HttpClient _httpClient;
        private IEnumerable<BookReview>? _reviews = null;

        public ReviewRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookReview>> GetReviewsAsync()
        {
            if (_reviews == null)
                _reviews = await _httpClient.GetFromJsonAsync<BookReview[]>("BookReview");

            return _reviews!;
        }

        public async Task AddReviewAsync(BookReview review)
        {
            await _httpClient.PostAsJsonAsync("BookReview", review);

            _reviews = null;
        }
    }
}
