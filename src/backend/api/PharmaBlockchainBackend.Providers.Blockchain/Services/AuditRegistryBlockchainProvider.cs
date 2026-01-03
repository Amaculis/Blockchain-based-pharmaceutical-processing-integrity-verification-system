using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Util;

public class AuditRegistryClient
{
    private readonly Web3 _web3;
    private readonly string _contractAddress;

    // Минимальный ABI (только нужные функции)
    private const string Abi = @"[
      {
        ""inputs"": [{""internalType"": ""bytes32"", ""name"": ""hash"", ""type"": ""bytes32""}],
        ""name"": ""recordHash"",
        ""outputs"": [],
        ""stateMutability"": ""nonpayable"",
        ""type"": ""function""
      },
      {
        ""inputs"": [{""internalType"": ""uint256"", ""name"": ""timestamp"", ""type"": ""uint256""}],
        ""name"": ""getHashByTimestamp"",
        ""outputs"": [{""internalType"": ""bytes32"", ""name"": """", ""type"": ""bytes32""}],
        ""stateMutability"": ""view"",
        ""type"": ""function""
      }
    ]";

    public AuditRegistryClient(
        string rpcUrl,
        string privateKey,
        string contractAddress)
    {
        var account = new Account(privateKey);
        _web3 = new Web3(account, rpcUrl);
        _contractAddress = contractAddress;
    }

    /// <summary>
    /// Writes hash to blockchain and returns block.timestamp
    /// </summary>
    public async Task<long> RecordHashAsync(string hash)
    {
        var contract = _web3.Eth.GetContract(Abi, _contractAddress);
        var function = contract.GetFunction("recordHash");

        var receipt = await function.SendTransactionAndWaitForReceiptAsync(
            from: _web3.TransactionManager.Account.Address,
            gas: null,
            value: null,
            functionInput: hash
        );

        // Получаем timestamp блока, в который попала транзакция
        var block = await _web3.Eth.Blocks
            .GetBlockWithTransactionsByNumber
            .SendRequestAsync(receipt.BlockNumber);

        return (long)block.Timestamp.Value;
    }

    /// <summary>
    /// Reads hash from blockchain by timestamp
    /// </summary>
    public async Task<string> GetHashByTimestampAsync(long timestamp)
    {
        var contract = _web3.Eth.GetContract(Abi, _contractAddress);
        var function = contract.GetFunction("getHashByTimestamp");

        return await function.CallAsync<string>(timestamp);
    }

    /// <summary>
    /// Optional helper: keccak256 like ethers.js
    /// </summary>
    public static string Keccak256(string value)
    {
        return Sha3Keccack.Current.CalculateHash(value);
    }
}
