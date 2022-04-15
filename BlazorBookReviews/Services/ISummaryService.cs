using BlazorBookReviews.Models;

namespace BlazorBookReviews.Services
{
    public interface ISummaryService
    {
        Task<IEnumerable<BookReview>> GetSummariesAsync();
    }
}