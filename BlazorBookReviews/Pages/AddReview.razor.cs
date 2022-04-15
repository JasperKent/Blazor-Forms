using BlazorBookReviews.Models;
using BlazorBookReviews.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBookReviews.Pages
{
    public partial class AddReview
    {
        [Inject]
        private IReviewRepository Repository { get; set; } = null!;

        public BookReview Review { get; set; } = new BookReview { Rating = 5 };

        [Parameter]
        public EventCallback Added { get; set; }

        public async Task SubmitAsync()
        {
            await Repository.AddReviewAsync(Review);
            await Added.InvokeAsync();
        }
    }
}
