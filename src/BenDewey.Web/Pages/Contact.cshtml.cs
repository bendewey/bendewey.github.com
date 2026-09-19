using BenDewey.Web.Models;
using BenDewey.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BenDewey.Web.Pages;

public sealed class ContactModel(IContactEmailSender emailSender, ILogger<ContactModel> logger) : PageModel
{
    [BindProperty]
    public ContactFormInput Input { get; set; } = new();

    public bool Sent { get; private set; }

    public void OnGet(bool sent = false) => Sent = sent;

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(Input.Website))
        {
            return RedirectToPage(new { sent = true });
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await emailSender.SendAsync(Input, cancellationToken);
            return RedirectToPage(new { sent = true });
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unable to deliver website contact message.");
            ModelState.AddModelError(string.Empty, "Your message could not be sent right now. Please try again shortly.");
            return Page();
        }
    }
}
