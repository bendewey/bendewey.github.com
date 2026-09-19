using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace BenDewey.Web.Services;

public sealed class ProjectInventoryOptions
{
    public const string SectionName = "ProjectInventory";
    public string Password { get; init; } = string.Empty;
}

public interface IProjectInventoryAccess
{
    bool IsConfigured { get; }
    bool IsValidPassword(string? password);
}

public sealed class ProjectInventoryAccess(IOptions<ProjectInventoryOptions> options) : IProjectInventoryAccess
{
    private readonly string _password = options.Value.Password;

    public bool IsConfigured => !string.IsNullOrWhiteSpace(_password);

    public bool IsValidPassword(string? password)
    {
        if (!IsConfigured || string.IsNullOrEmpty(password))
        {
            return false;
        }

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(_password),
            Encoding.UTF8.GetBytes(password));
    }
}
