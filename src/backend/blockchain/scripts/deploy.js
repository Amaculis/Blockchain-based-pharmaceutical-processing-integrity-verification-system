async function main() {
    const AuditRegistry = await ethers.getContractFactory("AuditRegistry");
    const auditRegistry = await AuditRegistry.deploy();
    await auditRegistry.deployed();
    console.log(" Contract deployed to:", auditRegistry.address);
  }
  
  main().catch((error) => {
    console.error(error);
    process.exitCode = 1;
  });
  