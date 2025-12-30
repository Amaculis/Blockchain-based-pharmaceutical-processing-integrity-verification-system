using PharmaBlockchainBackend.Domain.Enums;

namespace PharmaBlockchainBackend.Api.Features.DataValidation.Validate
{
    public record Request
    {
        public required ProtocolType ProtocolType { get; init; }
        public required ICollection<Package> Packages { get; init; }
    }

    public record Package
    {
        public required Guid PackageCode { get; init; }
        public required ICollection<StepResponse> Steps { get; init; }
    }

    public record StepResponse
    {
        public required DateTime Timestamp { get; init; }
        public required int StepNumber { get; init; }
        public object? AdditionalData { get; init; }
    }
}
