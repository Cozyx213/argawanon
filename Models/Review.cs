namespace MyBlazorApp.Models;

// A posted review. Read-only once created.
public record Review(string Name, int Rating, string Comment, bool IsSample = false);
