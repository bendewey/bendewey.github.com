using BenDewey.Web.Models;
using BenDewey.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenDewey.Web.Pages.Projects;

public sealed class IndexModel(IProjectCatalog catalog, IProjectInventoryAccess access) : PageModel
{
    public bool ShowProtectedInventory => access.IsConfigured;
    public IReadOnlyList<PortfolioProject> Projects => catalog.All
        .Where(project => project.IsFeatured)
        .OrderBy(project => project.Id switch
        {
            "PRJ-005" => 0,
            "PRJ-011" => 1,
            "PRJ-001" => 2,
            _ => 3
        })
        .ToList();
}
