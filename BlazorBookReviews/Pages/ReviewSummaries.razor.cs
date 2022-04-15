using BlazorBookReviews.Models;
using BlazorBookReviews.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBookReviews.Pages
{
    public partial class ReviewSummaries
    {
        [Inject]
        private ISummaryService SummaryService { get; set; } = null!;

        public IEnumerable<BookReview> Summaries { get; set; } = Enumerable.Empty<BookReview>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Summaries = await SummaryService.GetSummariesAsync();
        }
    }
}
