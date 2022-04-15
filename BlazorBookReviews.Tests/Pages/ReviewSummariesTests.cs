using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBookReviews.Models;
using BlazorBookReviews.Pages;
using BlazorBookReviews.Services;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace BlazorBookReviews.Tests.Pages
{
    public class ReviewSummariesTests : IDisposable
    {
        private readonly TestContext _testContext;
        private readonly Mock<ISummaryService> _mockSummaries;
        private readonly IRenderedComponent<ReviewSummaries> _page;

        public ReviewSummariesTests()
        {
            _testContext = new TestContext();
            _mockSummaries = new Mock<ISummaryService>();

            var summaries = new BookReview[]
            {
                new(){ Title = "Book 1", Rating = 1 },
                new(){ Title = "Book 2", Rating = 2 },
            };

            _mockSummaries.Setup(s => s.GetSummariesAsync()).ReturnsAsync(summaries);

            _testContext.Services.AddSingleton(_mockSummaries.Object);

            _page = _testContext.RenderComponent<ReviewSummaries>();
        }

        public void Dispose()
        {
            _page.Dispose();
            _testContext.Dispose();
        }

        [Fact]
        public void FetchSummaries()
        {
            var summaries = _page.Instance.Summaries;

            Assert.Collection(summaries,
                s =>
                {
                    Assert.Equal("Book 1", s.Title);
                    Assert.Equal(1, s.Rating);
                },
                s =>
                {
                    Assert.Equal("Book 2", s.Title);
                    Assert.Equal(2, s.Rating);
                }
            );
        }

        [Fact]
        public void DisplaySummaries()
        {
            var cells = _page.FindAll("table>tbody>tr>td");

            Assert.Collection(cells,
                c => Assert.Equal("Book 1", c.InnerHtml),
                c => Assert.Equal("1.00", c.InnerHtml),
                c => Assert.Equal("Book 2", c.InnerHtml),
                c => Assert.Equal("2.00", c.InnerHtml)
            );
        }
    }
}
