namespace BenDewey.Web.Models;

public sealed record SpeakingEngagement(DateOnly Date, string Title, string Venue, string? DateLabel = null);
