using System.ComponentModel.DataAnnotations;

namespace BenDewey.Web.Models;

public sealed class ContactFormInput
{
    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(254)]
    public string Email { get; set; } = string.Empty;

    [StringLength(160)]
    public string? CompanyOrRole { get; set; }

    [Required, StringLength(4000, MinimumLength = 10)]
    public string Message { get; set; } = string.Empty;

    // Hidden from people; populated submissions are rejected as spam.
    public string? Website { get; set; }
}
