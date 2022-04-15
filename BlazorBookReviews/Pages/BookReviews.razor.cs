using BlazorBookReviews.Models;
using BlazorBookReviews.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBookReviews.Pages
{
    public partial class BookReviews
    {
        [Inject]
        private IReviewRepository Repository { get; set; } = null!;

        public IEnumerable<BookReview> Reviews { get; private set; } = Enumerable.Empty<BookReview>();

        public bool ShowAdd { get; set; }

        public async Task ReviewAdded()
        {
            ShowAdd = false;

            Reviews = await Repository.GetReviewsAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Reviews = await Repository.GetReviewsAsync();
        }
    }
}
