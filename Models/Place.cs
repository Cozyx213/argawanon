namespace MyBlazorApp.Models;

// A place listed on the site. A record is read-only, so the shared place list can't be changed by visitors.
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
