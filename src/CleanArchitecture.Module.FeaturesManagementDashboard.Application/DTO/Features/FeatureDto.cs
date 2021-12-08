namespace CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features
{
    public record FeatureDto
    {
        public string Id { get; init; }
        public string Name { get; init; } = null!;
        public bool Status { get; init; }
    }
}