namespace MyBlazorApp.Models;

// A place listed on the site.
// Properties are get-only (set once in the constructor), so the shared place list can't be changed by visitors.
public class Place
{
    public string Slug { get; }
    public string Name { get; }
    public string Category { get; }
    public string Location { get; }
    public string Summary { get; }
    public string Description { get; }
    public string Image { get; }
    public string ImageAlt { get; }
    public string PhotoCredit { get; }
    public bool IsDemo { get; }
    public IReadOnlyList<Review> SampleReviews { get; }

    public Place(string slug, string name, string category, string location, string summary, string description,
                 string image, string imageAlt, string photoCredit, bool isDemo, IReadOnlyList<Review> sampleReviews)
    {
        Slug = slug;
        Name = name;
        Category = category;
        Location = location;
        Summary = summary;
        Description = description;
        Image = image;
        ImageAlt = imageAlt;
        PhotoCredit = photoCredit;
        IsDemo = isDemo;
        SampleReviews = sampleReviews;
    }
}
