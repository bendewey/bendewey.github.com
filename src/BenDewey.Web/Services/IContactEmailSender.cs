using BenDewey.Web.Models;

namespace BenDewey.Web.Services;

public interface IContactEmailSender
{
    Task SendAsync(ContactFormInput message, CancellationToken cancellationToken);
}
