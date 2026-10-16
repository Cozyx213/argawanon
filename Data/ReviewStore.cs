namespace MyBlazorApp.Data;

// Registered as Scoped: Blazor Server creates one instance per visitor connection (circuit).
// Reviews stay while the visitor moves between pages, are never shared with other visitors,
// and disappear on a full page refresh (which starts a new circuit).
public class ReviewStore
{
    private readonly Dictionary<string, List<Review>> added = [];

    public void Add(Place place, Review review)
    {
        if (!added.TryGetValue(place.Slug, out var list))
            added[place.Slug] = list = [];
        list.Insert(0, review); // newest first
    }

    public IEnumerable<Review> ReviewsFor(Place place) =>
        added.GetValueOrDefault(place.Slug, []).Concat(place.SampleReviews);

    public double AverageRating(Place place) => ReviewsFor(place).Average(r => r.Rating);
}
