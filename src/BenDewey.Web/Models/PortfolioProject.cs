namespace BenDewey.Web.Models;

public sealed record PortfolioProject(
    string Id,
    string Title,
    string Summary,
    string Detail,
    string Role,
    bool IsFeatured);
