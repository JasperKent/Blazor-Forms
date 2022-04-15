using System.ComponentModel.DataAnnotations;

namespace BlazorBookReviews.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = "";

        [Required] 
        [Range(1,5)]
        public double Rating { get; set; }
    }
}
