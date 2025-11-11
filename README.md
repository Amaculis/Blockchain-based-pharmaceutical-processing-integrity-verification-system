# Blockchain-based-pharmaceutical-processing-integrity-verification-system

This project provides a blockchain-based auditing system for verifying the integrity of pharmaceutical manufacturing conditions.  
It involves three main participants:
- **MAH** (Marketing Authorization Holder) — assigns roles and oversees audits  
- **CMO** (Contract Manufacturing Organization) — records hashed audit data  
- **Auditor** — verifies audit hashes against blockchain records  

https://docs.google.com/document/d/1PvVCXS0DJaQiNjFjo2QQV4XgmCvkCYxAY9jpZpa1Mqw/edit?usp=sharing

Blockchain-based-pharmaceutical-processing-integrity-verification-system/
├── contracts/           # Solidity smart contracts
├── scripts/             # Hardhat scripts (deploy, addAudit)
├── backend/             # Node.js backend with PostgreSQL integration
├── docker-compose.yml   # PostgreSQL container config
├── .env.example         # Example environment variables
├── hardhat.config.js
└── README.md

# first load
 ```bash

npm install
# make .env
cp .env.example .env

# launch PostgreSql
docker-compose up -d
docker ps

# Start blockchain (local at the moment)
npx hardhat node

# contract deploy
npx hardhat run scripts/deploy.js --network localhost

#lauch backend server
node backend/server.js

# Optional test audit
npx hardhat run scripts/addAudit.js --network localhost

#Stop database
docker-compose down



