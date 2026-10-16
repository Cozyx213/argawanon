namespace MyBlazorApp.Data;

public record Review(string Name, int Rating, string Comment, bool IsSample = false);

public record Place(
    string Slug,
    string Name,
    string Category,
    string Location,
    string Summary,
    string Description,
    string Image,
    string ImageAlt,
    string PhotoCredit,
    bool IsDemo,
    Review[] SampleReviews);
