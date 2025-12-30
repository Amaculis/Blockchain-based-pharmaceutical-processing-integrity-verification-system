using PharmaBlockchainBackend.Domain.Helpers;

namespace PharmaBlockchainBackend.Api.Features.DataValidation.Validate
{
    public class Handler()
    {
        public async Task<Response> Handle(Request request, CancellationToken ct)
        {
            List<PackageValidationResult> invalidPackages = [];

            foreach (var package in request.Packages)
            {
                List<int> invalidSteps = [];
                foreach(var packageStep in package.Steps)
                {
                    var actualHash = HashHelpers.CalculateHash(request.ProtocolType, packageStep.StepNumber, package.PackageCode, packageStep.AdditionalData);

                    //TODO: Get hash and timestamp from blockchain
                    var expectedHash = actualHash;
                    var expectedTimestamp = packageStep.Timestamp;

                    if (packageStep.Timestamp != expectedTimestamp || !expectedHash.SequenceEqual(actualHash))
                        invalidSteps.Add(packageStep.StepNumber);
                }

                if (invalidSteps.Count > 0)
                    invalidPackages.Add(new()
                    {
                        PackageCode = package.PackageCode,
                        StepNumber = invalidSteps
                    });
            }

            return new Response
            {
                IsValid = invalidPackages.Count == 0,
                InvalidPackages = invalidPackages
            };
        }
    }
}
