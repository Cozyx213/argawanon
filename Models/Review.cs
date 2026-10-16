namespace MyBlazorApp.Models;

// A posted review. Get-only properties, so it can't be edited after it is created.
public class Review
{
    public string Name { get; }
    public int Rating { get; }
    public string Comment { get; }
    public bool IsSample { get; }

    public Review(string name, int rating, string comment, bool isSample = false)
    {
        Name = name;
        Rating = rating;
        Comment = comment;
        IsSample = isSample;
    }
}
