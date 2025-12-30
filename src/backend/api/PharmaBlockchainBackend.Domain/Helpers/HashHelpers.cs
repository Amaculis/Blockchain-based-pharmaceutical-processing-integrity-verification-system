using PharmaBlockchainBackend.Domain.Enums;

namespace PharmaBlockchainBackend.Domain.Helpers
{
    public static class HashHelpers
    {
        public static byte[] CalculateHash(ProtocolType protocolType, int stepNumber, Guid packageCode, object? additionalData)
        {
            var additionalDataString = additionalData is null
                ? string.Empty
                : System.Text.Json.JsonSerializer.Serialize(additionalData);

            var rawData = $"{protocolType}|{stepNumber}|{additionalDataString}|{packageCode}";
            var bytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(rawData));

            return bytes;
        }
    }
}
