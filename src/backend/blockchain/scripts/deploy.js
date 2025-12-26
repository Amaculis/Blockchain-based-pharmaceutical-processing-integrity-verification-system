import pkg from "hardhat";
const { ethers } = pkg;

async function main() {
  const ContractName = "AuditRegistry";
  const Contract = await ethers.getContractFactory(ContractName);
  const contract = await Contract.deploy();
  await contract.waitForDeployment();

  console.log(ContractName & " deployed to:", await contract.getAddress());
}

main().catch(console.error);
