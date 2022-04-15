using BlazorBookReviews.Models;
using BlazorBookReviews.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlazorBookReviews.Tests.Services
{
    public class SummaryServiceTests
    {
        [Fact]
        public async Task SummarizesReviews()
        {
            var mockRepository = new Mock<IReviewRepository>();

            var reviews = new BookReview[]
            {
                new() { Title = "Book 1", Rating = 1},
                new() { Title = "Book 1", Rating = 5},
                new() { Title = "Book 2", Rating = 2}
            };

            mockRepository.Setup(r => r.GetReviewsAsync()).ReturnsAsync(reviews);

            var service = new SummaryService(mockRepository.Object);

            var summaries = await service.GetSummariesAsync();

            Assert.Collection(summaries,
                s =>
                {
                    Assert.Equal("Book 1", s.Title);
                    Assert.Equal(3, s.Rating);
                },
                s =>
                {
                    Assert.Equal("Book 2", s.Title);
                    Assert.Equal(2, s.Rating);
                }
            );
        }
    }
}
