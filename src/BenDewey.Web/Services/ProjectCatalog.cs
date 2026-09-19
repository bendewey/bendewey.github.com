using System.Text.Json;
using BenDewey.Web.Models;

namespace BenDewey.Web.Services;

public interface IProjectCatalog
{
    IReadOnlyList<PortfolioProject> All { get; }
}

public sealed class ProjectCatalog(IWebHostEnvironment environment) : IProjectCatalog
{
    public IReadOnlyList<PortfolioProject> All { get; } = Load(environment.ContentRootPath);

    private static IReadOnlyList<PortfolioProject> Load(string contentRootPath)
    {
        var path = Path.Combine(contentRootPath, "Content", "projects.json");
        using var stream = File.OpenRead(path);
        return JsonSerializer.Deserialize<List<PortfolioProject>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidOperationException("Project catalog is empty.");
    }
}
