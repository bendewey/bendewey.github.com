using BenDewey.Web.Models;
using BenDewey.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenDewey.Web.Pages.Projects;

public sealed class IndexModel(IProjectCatalog catalog) : PageModel
{
    public IReadOnlyList<PortfolioProject> Projects => catalog.All;
}
