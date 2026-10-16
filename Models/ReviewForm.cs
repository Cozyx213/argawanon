using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Models;

// What the review form fills in. Unlike Place and Review it has setters, because Blazor updates it as the visitor types.
// [Required] also rejects text that is only spaces.
public class ReviewForm
{
    [Required(ErrorMessage = "Please enter a display name.")]
    [StringLength(40, ErrorMessage = "Display name can be at most 40 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please choose a rating from 1 to 5.")]
    [Range(1, 5, ErrorMessage = "Rating must be a whole number from 1 to 5.")]
    public int? Rating { get; set; }

    [Required(ErrorMessage = "Please write a comment.")]
    [StringLength(500, ErrorMessage = "Comment can be at most 500 characters.")]
    public string? Comment { get; set; }
}
