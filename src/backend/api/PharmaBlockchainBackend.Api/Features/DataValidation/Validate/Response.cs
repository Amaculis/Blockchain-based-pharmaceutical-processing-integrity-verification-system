namespace PharmaBlockchainBackend.Api.Features.DataValidation.Validate
{
    public record Response
    {
        public required bool IsValid { get; init; }
        public ICollection<PackageValidationResult> InvalidPackages { get; init; } = [];
    }

    public record PackageValidationResult
    {
        public required Guid PackageCode { get; init; }
        public required ICollection<int> StepNumber { get; init; }
    }
}
