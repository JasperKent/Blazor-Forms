using BlazorBookReviews.Models;

namespace BlazorBookReviews.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IReviewRepository _repository;

        public SummaryService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookReview>> GetSummariesAsync()
        {
            var results = await _repository.GetReviewsAsync();

            return results.GroupBy(r => r.Title)
                          .Select(g => new BookReview { Title = g.Key, Rating = g.Average(r => r.Rating) });
        }
    }
}
