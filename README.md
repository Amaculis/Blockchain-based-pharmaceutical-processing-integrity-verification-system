# Blockchain-based-pharmaceutical-processing-integrity-verification-system

## How to run
You should have Docker installed.
1. Open such folder in terminal: `./src`
2. Run such command: `docker compose up`

## Description
This project provides a blockchain-based auditing system for verifying the integrity of pharmaceutical manufacturing conditions.  
It involves three main participants:
- **MAH** (Marketing Authorization Holder) — assigns roles and oversees audits  
- **CMO** (Contract Manufacturing Organization) — records hashed audit data  
- **Auditor** — verifies audit hashes against blockchain records  

1. https://docs.google.com/document/d/1PvVCXS0DJaQiNjFjo2QQV4XgmCvkCYxAY9jpZpa1Mqw/edit?usp=sharing
2. https://docs.google.com/document/d/1gtSQT29TO4_VxADrETaOF9dp0kyychnKQZrO4zZ8M7Q/edit?usp=sharing

```
The goal of the project is to create a system that guarantees the integrity, authenticity, and immutability of data related to the production, packaging, serialization, and quality control of medicinal products. The system should simplify and reduce the cost of audits, eliminate mistrust between MAHs and CMOs, and prevent the falsification of production records.

What we are going to do:
We are developing a blockchain-based verification system in which: 
    CMOs and MAHs send hash values of production data to a private blockchain. 
    All sensitive data is stored only in the companies' internal databases; only the hash and timestamp are stored on the blockchain. 
    The auditor receives the actual data from the MAH/CMO, hashes it again, and compares it with the blockchain record.
    If the hash matches, the data is confirmed, has not been altered, and is authentic.

System structure:
    UI for MAH, CMO, and auditors.
    API for sending data, generating hashes, and verifying authenticity.
    Private Blockchain Network, where immutable records (hash + timestamp) are stored.
    External Databases, where companies continue to store their real data.
```



Blockchain-based-pharmaceutical-processing-integrity-verification-system/

├── contracts/           # Solidity smart contracts

├── scripts/             # Hardhat scripts (deploy, addAudit)

├── backend/             # Node.js backend with PostgreSQL integration

├── docker-compose.yml   # PostgreSQL container config

├── .env.example         # Example environment variables

├── hardhat.config.js

└── README.md


## First load
 ```bash

npm install
# make .env
cp .env.example .env

# launch PostgreSql
docker-compose up -d
docker ps

# Start blockchain (local at the moment)
npx hardhat node

#There you will get 20 accounts with privete keys and 10000 eth for tests. 

# contract deploy
npx hardhat run src\backend\blockchain\scripts\deploy.js --network localhost
# After that you wll see output of contract address, save it or put into script

#lauch backend server
node backend/server.js

# Optional test audit
npx hardhat run src\backend\blockchain\scripts/addAudit.js --network localhost

#Stop docker
docker-compose down
```

    

## Useful thing for blockchain develop and testing
 ```bash

# To recompile contracts launch this
npx hardhat clean
npx hardhat compile

# To see list of compiled contracts type use
ls artifacts/contracts

# For local tests, it is possible to use test script testHash.js
# For tests launch:

npx hardhat run src\backend\blockchain\scripts\testHash.js  --network localhost

# Excepted output:

Testing with account: 0xf39Fd6e51aad88F6F4ce6aB8827279cffFb92266
Writing hash: 0x443613b999b49f9db991692ee29b05d0a1350f42ac21168f48113731058d9204
Timestamp: 1766759616
Read hash: 0x443613b999b49f9db991692ee29b05d0a1350f42ac21168f48113731058d9204
Integrity check: OK

#Otherwise in output will be error description

 ```

