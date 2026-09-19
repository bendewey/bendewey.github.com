namespace BenDewey.Web.Models;

public sealed record PortfolioProject(
    string Id,
    string Title,
    string Summary,
    string Detail,
    string Role,
    string Dates,
    string Status,
    IReadOnlyList<string> Tags,
    bool IsFeatured);
