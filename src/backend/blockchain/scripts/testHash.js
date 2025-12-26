
import hre from "hardhat";


async function main() {
  const { ethers } = hre;
  // get deployer account
  const [deployer] = await ethers.getSigners();
  console.log("Testing with account:", deployer.address);

  // Put here contract address 
  const CONTRACT_ADDRESS = "0x9fE46736679d2D9a65F0992F2272dE9f3c7fa6e0";

  const Contract = await ethers.getContractAt(
    "AuditRegistry",
    CONTRACT_ADDRESS,
    deployer
  );

  // create test hash
  const hash = ethers.keccak256(
    ethers.toUtf8Bytes("BATCH_123_PHARMA")
  );

  console.log("Writing hash:", hash);

  // save hash
  const tx = await Contract.recordHash(hash);
  const receipt = await tx.wait();

  const blockNumber = receipt.blockNumber;
  const block = await ethers.provider.getBlock(blockNumber);
  const timestamp = block.timestamp;

  console.log("Timestamp:", timestamp);

  // Try to get hash by timestamp
  const storedHash = await Contract.getHashByTimestamp(timestamp);
  console.log("Read hash:", storedHash);

  //Fast integrity check
  console.log(
    "Integrity check:",
    storedHash === hash ? "OK" : "FAILED"
  );
}

main().catch((error) => {
    console.error(error);
    process.exit(1);
  });
