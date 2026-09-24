using BenDewey.Web.Models;
using BenDewey.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenDewey.Web.Pages.Projects;

public sealed class FullModel(IProjectInventoryAccess access, IProjectCatalog catalog) : PageModel
{
    private const string AccessKey = "ProjectInventoryAccess";

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public bool HasAccess => HttpContext.Session.GetString(AccessKey) == "granted";
    public bool IsConfigured => access.IsConfigured;
    public IReadOnlyList<PortfolioProject> Projects => catalog.All;

    public IActionResult OnGet() => IsConfigured ? Page() : NotFound();

    public IActionResult OnPostUnlock()
    {
        if (!IsConfigured)
        {
            return NotFound();
        }

        if (!access.IsValidPassword(Password))
        {
            ModelState.AddModelError(string.Empty, "That password did not match. Please try again.");
            return Page();
        }

        HttpContext.Session.SetString(AccessKey, "granted");
        return RedirectToPage();
    }

    public IActionResult OnPostLock()
    {
        if (!IsConfigured)
        {
            return NotFound();
        }

        HttpContext.Session.Remove(AccessKey);
        return RedirectToPage();
    }
}
