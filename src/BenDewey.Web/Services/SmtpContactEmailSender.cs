using System.Net;
using System.Net.Mail;
using BenDewey.Web.Models;
using Microsoft.Extensions.Options;

namespace BenDewey.Web.Services;

public sealed class ContactEmailOptions
{
    public const string SectionName = "ContactEmail";
    public string Host { get; init; } = string.Empty;
    public int Port { get; init; } = 587;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string FromAddress { get; init; } = string.Empty;
    public string RecipientAddress { get; init; } = string.Empty;
}

public sealed class SmtpContactEmailSender(IOptions<ContactEmailOptions> options, ILogger<SmtpContactEmailSender> logger) : IContactEmailSender
{
    private readonly ContactEmailOptions _options = options.Value;

    public async Task SendAsync(ContactFormInput message, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_options.Host) || string.IsNullOrWhiteSpace(_options.FromAddress) || string.IsNullOrWhiteSpace(_options.RecipientAddress))
        {
            throw new InvalidOperationException("Contact email has not been configured.");
        }

        using var mail = new MailMessage(_options.FromAddress, _options.RecipientAddress)
        {
            Subject = $"Website contact from {message.Name}",
            Body = $"Name: {message.Name}\nEmail: {message.Email}\nCompany or role: {message.CompanyOrRole}\n\n{message.Message}",
            ReplyToList = { new MailAddress(message.Email, message.Name) }
        };

        using var client = new SmtpClient(_options.Host, _options.Port)
        {
            EnableSsl = true,
            Credentials = string.IsNullOrWhiteSpace(_options.Username) ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(_options.Username, _options.Password)
        };

        logger.LogInformation("Sending contact message from {SenderEmail}", message.Email);
        await client.SendMailAsync(mail, cancellationToken);
    }
}
