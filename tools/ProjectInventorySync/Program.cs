using System.Text.Json;
using System.Text.RegularExpressions;

var arguments = ParseArguments(args);
var source = Require(arguments, "source");
var overridesPath = Require(arguments, "overrides");
var output = Require(arguments, "output");

var overrides = JsonSerializer.Deserialize<Dictionary<string, PresentationOverride>>(
    File.ReadAllText(overridesPath),
    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
    ?? throw new InvalidOperationException("Presentation overrides could not be read.");

var projects = Directory.EnumerateFiles(Path.Combine(source, "projects"), "prj-*.md")
    .Select(path => ReadProject(path, overrides))
    .OrderBy(project => project.Id, StringComparer.Ordinal)
    .ToList();

Directory.CreateDirectory(Path.GetDirectoryName(output)!);
File.WriteAllText(output, JsonSerializer.Serialize(projects, new JsonSerializerOptions
{
    WriteIndented = true
}) + Environment.NewLine);

Console.WriteLine($"Generated {projects.Count} anonymous portfolio records at {output}.");

static GeneratedProject ReadProject(string path, IReadOnlyDictionary<string, PresentationOverride> overrides)
{
    var idMatch = Regex.Match(Path.GetFileName(path), "^(PRJ-\\d+)", RegexOptions.IgnoreCase);
    if (!idMatch.Success)
    {
        throw new InvalidOperationException($"Could not identify project ID from {path}.");
    }

    var id = idMatch.Groups[1].Value.ToUpperInvariant();
    if (!overrides.TryGetValue(id, out var presentation))
    {
        throw new InvalidOperationException($"Missing anonymous presentation metadata for {id}.");
    }

    var text = File.ReadAllText(path);
    var status = ReadField(text, "Status");

    return new GeneratedProject(id, presentation.Title, presentation.Summary, presentation.Detail,
        "Unknown", "Unknown", status, [], presentation.IsFeatured);
}

static string ReadField(string text, string field)
{
    var match = Regex.Match(text, $"^- {Regex.Escape(field)}: *(.*)$", RegexOptions.Multiline);
    return match.Success ? match.Groups[1].Value.Trim() : "Unknown";
}

static Dictionary<string, string> ParseArguments(string[] args)
{
    var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    for (var index = 0; index < args.Length; index += 2)
    {
        if (index + 1 >= args.Length || !args[index].StartsWith("--", StringComparison.Ordinal))
        {
            throw new ArgumentException("Usage: --source <project-history-directory> --overrides <json-file> --output <json-file>");
        }

        values[args[index][2..]] = args[index + 1];
    }

    return values;
}

static string Require(IReadOnlyDictionary<string, string> arguments, string name) =>
    arguments.TryGetValue(name, out var value) ? value : throw new ArgumentException($"Missing --{name}.");

internal sealed record PresentationOverride(string Title, string Summary, string Detail, bool IsFeatured);
internal sealed record GeneratedProject(string Id, string Title, string Summary, string Detail, string Role, string Dates, string Status, string[] Tags, bool IsFeatured);
