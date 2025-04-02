# BozoCord

<div align="center">

[![BozoCord Banner](https://raw.githubusercontent.com/Nanaimo2013/BozoCord/main/.github/assets/banner.png)](https://github.com/Nanaimo2013/BozoCord)

### 🚀 A Modern, Real-Time Communication Platform

*Built with .NET 8.0, Next.js 14, and SignalR*

<div align="center">

[![DOWNLOAD LATEST FOR WINDOWS](https://img.shields.io/github/downloads/Nanaimo2013/BozoCord/latest/BozoCord.Installer.exe?style=for-the-badge&label=Download%20Latest%20for%20Windows&color=00aa00)](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.Installer.exe)

</div>

<p align="center">
  <a href="#-features">Features</a> •
  <a href="#-quick-start">Quick Start</a> •
  <a href="#-documentation">Docs</a> •
  <a href="#-contributing">Contributing</a> •
  <a href="#-support">Support</a>
</p>

### Project Status

[![Latest Release](https://img.shields.io/github/v/release/Nanaimo2013/BozoCord?style=for-the-badge&color=blue&label=Latest%20Release)](https://github.com/Nanaimo2013/BozoCord/releases)
[![Version](https://img.shields.io/github/v/tag/Nanaimo2013/BozoCord?label=%20Version&style=for-the-badge&color=orange)](https://github.com/Nanaimo2013/BozoCord/releases/latest)
[![Build Status](https://img.shields.io/github/actions/workflow/status/Nanaimo2013/BozoCord/ci.yml?style=for-the-badge&color=brightgreen)](https://github.com/Nanaimo2013/BozoCord/actions)
[![Maintained](https://img.shields.io/maintenance/yes/2024?style=for-the-badge&color=green)](https://github.com/Nanaimo2013/BozoCord)

### Stats & Info

[![GitHub stars](https://img.shields.io/github/stars/Nanaimo2013/BozoCord?style=for-the-badge&color=yellow)](https://github.com/Nanaimo2013/BozoCord/stargazers)
[![Downloads](https://img.shields.io/github/downloads/Nanaimo2013/BozoCord/total?style=for-the-badge&color=blue)](https://github.com/Nanaimo2013/BozoCord/releases)
[![Contributors](https://img.shields.io/github/contributors/Nanaimo2013/BozoCord?style=for-the-badge&color=orange)](https://github.com/Nanaimo2013/BozoCord/graphs/contributors)
[![Forks](https://img.shields.io/github/forks/Nanaimo2013/BozoCord?style=for-the-badge&color=lightgray)](https://github.com/Nanaimo2013/BozoCord/network/members)

### Development

[![GitHub issues](https://img.shields.io/github/issues/Nanaimo2013/BozoCord?style=for-the-badge&color=red)](https://github.com/Nanaimo2013/BozoCord/issues)
[![Code Size](https://img.shields.io/github/languages/code-size/Nanaimo2013/BozoCord?style=for-the-badge&color=blue)](https://github.com/Nanaimo2013/BozoCord)
[![Open Source](https://img.shields.io/badge/Open%20Source-No-red?style=for-the-badge&logo=github)](https://github.com/Nanaimo2013/BozoCord)
[![GitHub License](https://img.shields.io/github/license/Nanaimo2013/BozoCord?style=for-the-badge&color=blue)](LICENSE.md)

</div>

## 🌟 Highlights

<table>
<tr>
<td width="50%">

### 🔥 Key Features

- **Real-time Communication**
  - Instant messaging with SignalR
  - Voice & video calls (WebRTC)
  - File sharing & media preview
- **Modern Architecture**
  - .NET 8.0 backend
  - Next.js 14 frontend
  - PostgreSQL & Redis
- **Enterprise Security**
  - End-to-end encryption
  - JWT authentication
  - Role-based access control

</td>
<td width="50%">

### 🛠️ Tech Stack

- **Backend**
  - .NET 8.0
  - Entity Framework Core
  - SignalR
- **Frontend**
  - Next.js 14
  - TypeScript
  - TailwindCSS
- **Infrastructure**
  - PostgreSQL
  - Redis
  - Docker
  - Kubernetes

</td>
</tr>
</table>

## 📦 Quick Start

<details>
<summary>🔽 Download & Install</summary>

### Windows Installer (Recommended)

<div align="center">

[![DOWNLOAD FOR WINDOWS](https://img.shields.io/github/downloads/Nanaimo2013/BozoCord/latest/BozoCord.Installer.exe?style=for-the-badge&label=Download%20Installer&color=00aa00)](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.Installer.exe)

</div>

1. Download the installer
2. Run `BozoCord.Installer.exe`
3. Follow the installation wizard
4. Launch BozoCord from your desktop

### Manual Installation

If the installer doesn't work, you can manually install BozoCord:

1. Download the latest release:
   ```bash
   # Choose one:
   ✅ [Download Portable ZIP](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.zip)
   ✅ [Download Standalone EXE](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.exe)
   ```

2. Installation Options:
   <details>
   <summary>📦 Portable ZIP</summary>
   
   ```bash
   1. Extract BozoCord.zip to your desired location
   2. Run BozoCord.exe from the extracted folder
   3. Optional: Create desktop shortcut
   ```
   </details>

   <details>
   <summary>⚡ Standalone EXE</summary>
   
   ```bash
   1. Move BozoCord.exe to your desired location
   2. Run BozoCord.exe
   3. Optional: Create desktop shortcut
   ```
   </details>

### Troubleshooting

<details>
<summary>🔧 Common Issues</summary>

- **Installer Not Running**
  1. Try running as administrator
  2. Check Windows SmartScreen settings
  3. Verify your antivirus isn't blocking
  4. Use manual installation method

- **Missing Dependencies**
  1. Install [.NET 8.0 Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)
  2. Install [WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)

- **Need Help?**
  - [📖 Installation Guide](docs/installation.md)
  - [💬 Discord Support](https://discord.gg/bozocord)
  - [📝 GitHub Issues](https://github.com/Nanaimo2013/BozoCord/issues)
</details>

</details>

<details>
<summary>🛠️ Development Setup</summary>

### Prerequisites

<div align="center">

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Node.js](https://img.shields.io/badge/Node.js-18+-339933?style=for-the-badge&logo=node.js)](https://nodejs.org/)
[![Docker](https://img.shields.io/badge/Docker-Latest-2496ED?style=for-the-badge&logo=docker)](https://www.docker.com/)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-007ACC?style=for-the-badge&logo=visual-studio-code)](https://code.visualstudio.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Latest-336791?style=for-the-badge&logo=postgresql)](https://www.postgresql.org/)
[![Redis](https://img.shields.io/badge/Redis-Latest-DC382D?style=for-the-badge&logo=redis)](https://redis.io/)

</div>

### Option 1: Docker Compose (Recommended)

```bash
# Clone the repository
git clone https://github.com/Nanaimo2013/BozoCord.git
cd BozoCord

# Start all services
docker-compose up -d

# Access the application
Frontend ➜ http://localhost:3000
API ➜ http://localhost:5000
Swagger ➜ http://localhost:5000/swagger
```

### Option 2: Manual Setup

<details>
<summary>Step-by-Step Instructions</summary>

1. **Clone & Setup**
   ```bash
   git clone https://github.com/Nanaimo2013/BozoCord.git
   cd BozoCord
   ```

2. **Database Setup**
   ```bash
   # Start PostgreSQL
   docker run -d --name bozocord-db -p 5432:5432 -e POSTGRES_PASSWORD=dev postgres

   # Start Redis
   docker run -d --name bozocord-redis -p 6379:6379 redis
   ```

3. **Backend Setup**
   ```bash
   cd src/BozoCord.API
   dotnet restore
   dotnet build
   dotnet run
   ```

4. **Frontend Setup**
   ```bash
   cd src/BozoCord.Web
   npm install
   npm run dev
   ```

5. **Access Points**
   ```
   Frontend ➜ http://localhost:3000
   API ➜ http://localhost:5000
   Swagger ➜ http://localhost:5000/swagger
   ```
</details>

### Option 3: All-in-One Script

```bash
# Windows (PowerShell)
./scripts/setup.ps1

# Linux/macOS
./scripts/setup.sh
```

This script will:
1. Check prerequisites
2. Install dependencies
3. Configure environment
4. Start all services
5. Open the application

### Development Tools

<details>
<summary>Recommended Extensions</summary>

- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Docker](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker)
- [ESLint](https://marketplace.visualstudio.com/items?itemName=dbaeumer.vscode-eslint)
- [Prettier](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)
</details>

</details>

## 🏗️ Architecture

<details>
<summary>View Project Structure</summary>

```mermaid
graph TD
    A[BozoCord] --> B[src]
    B --> C[BozoCord.API]
    B --> D[BozoCord.Core]
    B --> E[BozoCord.Infrastructure]
    B --> F[BozoCord.Web]
    
    C --> G[Controllers]
    C --> H[Middleware]
    
    D --> I[Domain]
    D --> J[Services]
    
    E --> K[Persistence]
    E --> L[Identity]
    
    F --> M[app]
    F --> N[components]

    click C "https://github.com/Nanaimo2013/BozoCord/tree/main/src/BozoCord.API" "Browse API Code"
    click D "https://github.com/Nanaimo2013/BozoCord/tree/main/src/BozoCord.Core" "Browse Core Code"
    click E "https://github.com/Nanaimo2013/BozoCord/tree/main/src/BozoCord.Infrastructure" "Browse Infrastructure Code"
    click F "https://github.com/Nanaimo2013/BozoCord/tree/main/src/BozoCord.Web" "Browse Web Code"
```

### Key Components

| Component | Description | Documentation |
|-----------|-------------|---------------|
| [`BozoCord.API`](src/BozoCord.API) | REST API endpoints & real-time communication | [API Docs](docs/api/README.md) |
| [`BozoCord.Core`](src/BozoCord.Core) | Business logic & domain models | [Core Docs](docs/core/README.md) |
| [`BozoCord.Infrastructure`](src/BozoCord.Infrastructure) | Data access & external services | [Infrastructure Docs](docs/infrastructure/README.md) |
| [`BozoCord.Web`](src/BozoCord.Web) | Next.js frontend application | [Web Docs](docs/web/README.md) |

</details>

## 🌿 Development

<details>
<summary>Branching Strategy</summary>

```mermaid
graph TD
    M[main] --> D[dev]
    D --> F1[feature/auth]
    D --> F2[feature/messaging]
    D --> F3[feature/ui]
    
    style M fill:#2da44e
    style D fill:#1a7f37
    style F1 fill:#0969da
    style F2 fill:#0969da
    style F3 fill:#0969da
```

### Branch Rules
- `main`: Production code only. Requires PR review and passing tests
- `dev`: Development branch. All features merge here first
- `feature/*`: New features, bug fixes, etc.

### Development Workflow
1. Create feature branch from `dev`:
   ```bash
   git checkout dev
   git pull
   git checkout -b feature/your-feature
   ```

2. Make changes and commit:
   ```bash
   git add .
   git commit -m "feat: add your feature"
   ```

3. Push feature branch:
   ```bash
   git push -u origin feature/your-feature
   ```

4. Create Pull Request to `dev` branch

5. After review and approval, merge to `dev`

6. Periodically, `dev` is merged into `main` for releases

</details>

<details>
<summary>Versioning</summary>

We use [SemVer](https://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/Nanaimo2013/BozoCord/tags).

### Version Format
`MAJOR.MINOR.PATCH`
- MAJOR version for incompatible API changes
- MINOR version for added functionality in a backward compatible manner
- PATCH version for backward compatible bug fixes

### Release Tags
- `v1.0.0` - Stable releases
- `v1.0.0-beta.1` - Beta releases
- `v1.0.0-alpha.1` - Alpha releases
- `v1.0.0-rc.1` - Release candidates

### Creating a New Release
1. Update version in project files
2. Update CHANGELOG.md
3. Create and push tag:
   ```bash
   git checkout main
   git pull
   git tag -a v1.0.0 -m "Release version 1.0.0"
   git push origin v1.0.0
   ```

</details>

## 🛣️ Roadmap

<details>
<summary>View Development Timeline & Progress</summary>

### Current Status Overview

| Phase | Progress | Status | Key Achievements |
|-------|----------|--------|-----------------|
| Initial Setup | ![](https://geps.dev/progress/100) | ✅ Complete | - Repository Structure<br>- Documentation Framework<br>- CI/CD Pipeline |
| Foundation | ![](https://geps.dev/progress/75) | 🟨 In Progress | - Architecture Design<br>- Database Schema<br>- Cloud Integration |
| Authentication | ![](https://geps.dev/progress/15) | 🟦 Starting | - Basic Auth Flow<br>- JWT Implementation |
| Core Features | ![](https://geps.dev/progress/5) | 📅 Planned | - Initial Planning<br>- Architecture Review |
| Advanced | ![](https://geps.dev/progress/0) | 🔮 Future | - Research Phase |

### Detailed Timeline

```mermaid
gantt
    title BozoCord Development Timeline (2024-2027)
    dateFormat YYYY-MM-DD
    section Initial Setup
    Initial Commit              :done, 2024-08-09, 1d
    Files/Folders Structure    :done, 2024-08-10, 30d
    Documentation Setup        :done, 2024-08-10, 45d
    Project Planning          :done, 2024-09-15, 60d
    Cloud Infrastructure      :active, 2024-11-01, 90d
    
    section Foundation (v1.0.0)
    Initial Stable Release    :milestone, 2024-08-09, 0d
    Architecture Planning     :done, 2024-08-15, 75d
    Database Design          :done, 2024-10-01, 60d
    Core Implementation      :done, 2024-12-01, 90d
    
    section Major Overhaul (v2.0.0)
    Project Restructuring    :active, 2025-04-01, 60d
    Backend Service Dev      :2025-04-02, 90d
    Web Client Implementation :2025-05-15, 75d
    Authentication & WebSocket :2025-07-01, 60d
    
    section Core Features
    Real-time Messaging      :2025-09-01, 90d
    File Sharing System      :2025-11-01, 75d
    Voice & Video           :2026-01-15, 120d
    RC Release (v2.1.0-rc)   :milestone, 2026-04-01, 0d
    
    section Advanced Features
    Screen Share            :2026-04-15, 90d
    Bot Platform           :2026-07-01, 120d
    V2.2 Release           :milestone, 2026-10-01, 0d
    
    section Enterprise
    Security & Analytics    :2026-10-15, 120d
    Enterprise Features    :2027-02-01, 150d
    V3.0 Release           :milestone, 2027-06-01, 0d
```

### Component Progress (As of April 2, 2025)

| Component | Status | Progress | Features Complete | In Progress | Next Steps |
|-----------|--------|----------|------------------|-------------|------------|
| **API** | 🟨 Active | ![](https://geps.dev/progress/45) | - Basic Endpoints<br>- Error Handling | - WebSocket Setup<br>- Rate Limiting | - Auth Integration<br>- API Documentation |
| **Core** | 🟨 Active | ![](https://geps.dev/progress/60) | - Domain Models<br>- Basic Services | - Event System<br>- Validation | - Message Service<br>- User Service |
| **Infrastructure** | 🟦 Starting | ![](https://geps.dev/progress/25) | - Database Schema<br>- Basic Config | - AWS Setup<br>- Docker Config | - Redis Cache<br>- Monitoring |
| **Web** | 📅 Planned | ![](https://geps.dev/progress/10) | - Project Setup<br>- Basic UI | - Component Library<br>- Routing | - State Management<br>- Real-time Features |

### Infrastructure Status

| Service | Status | Region | Last Updated | Health |
|---------|--------|--------|--------------|--------|
| API Gateway | 🟢 Online | US-East | 2025-04-02 | ![](https://geps.dev/progress/98) |
| Database | 🟢 Online | US-East | 2025-04-02 | ![](https://geps.dev/progress/100) |
| Redis Cache | 🟡 Partial | US-East | 2025-04-02 | ![](https://geps.dev/progress/85) |
| Storage | 🟢 Online | Global | 2025-04-02 | ![](https://geps.dev/progress/99) |
| CDN | 🟢 Online | Global | 2025-04-02 | ![](https://geps.dev/progress/100) |

### Development Checkpoints

| Checkpoint | Target Date | Dependencies | Progress | Key Deliverables |
|------------|-------------|--------------|----------|------------------|
| CP1 | Apr 15, 2025 | None | ![](https://geps.dev/progress/80) | Backend Infrastructure |
| CP2 | May 15, 2025 | CP1 | ![](https://geps.dev/progress/40) | Frontend Foundation |
| CP3 | July 1, 2025 | CP1, CP2 | ![](https://geps.dev/progress/20) | Core Features |
| CP4 | Oct 1, 2025 | CP3 | ![](https://geps.dev/progress/5) | Platform Stability |
| CP5 | Jan 1, 2026 | CP4 | ![](https://geps.dev/progress/0) | Advanced Features |
| CP6 | Apr 1, 2026 | CP5 | ![](https://geps.dev/progress/0) | Enterprise Ready |

### Version Release Schedule

| Version | Target Date | Priority | Status | Features |
|---------|-------------|----------|---------|-----------|
| v2.0.1 | Apr 15, 2025 | 🔴 High | 🟨 Active | - Backend Service<br>- Docker Setup<br>- CI/CD Pipeline |
| v2.0.2 | May 1, 2025 | 🔴 High | 📅 Planned | - Web Client<br>- API Endpoints<br>- Database Schema |
| v2.0.3 | May 15, 2025 | 🟡 Medium | 📅 Planned | - WebSocket<br>- Security Setup<br>- Monitoring |
| v2.1.0-alpha | June 1, 2025 | 🟡 Medium | 🔮 Future | - Authentication<br>- User Profiles |
| v2.1.0-beta | July 1, 2025 | 🟢 Low | 🔮 Future | - Messaging<br>- File Sharing |

### Next Steps (Priority Tasks)

| Task | Priority | Dependencies | Target Date | Status |
|------|----------|--------------|-------------|---------|
| Backend Service Setup | 🔴 High | None | Apr 15, 2025 | 🟨 In Progress |
| API Implementation | 🔴 High | Backend | May 1, 2025 | 🟦 Starting |
| Database Migration | 🟡 Medium | Backend | May 15, 2025 | 📅 Planned |
| WebSocket Integration | 🟡 Medium | API | June 1, 2025 | 📅 Planned |
| Frontend Development | 🟢 Low | API | June 15, 2025 | 📅 Planned |

</details>

## 🤝 Contributing

<details>
<summary>How to Contribute</summary>

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for details.

### Development Workflow

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

</details>

## 📚 Documentation

<details>
<summary>Available Resources</summary>

- [📖 API Documentation](docs/api/README.md)
- [🏗️ Architecture Guide](docs/architecture.md)
- [🔧 Development Setup](docs/development.md)
- [📱 Mobile Apps](docs/mobile/README.md)
- [🔒 Security](SECURITY.md)
- [📜 Terms of Service](TERMS_OF_SERVICE.md)

</details>

## 📄 License

<details>
<summary>License Information</summary>

This project is protected under a custom license that carefully balances open-source principles with commercial interests. See the [LICENSE.md](LICENSE.md) file for the complete terms.

### Quick Overview

✅ Allowed:
- Personal use
- Educational use
- Development and testing
- Contributing via pull requests
- Private instances

⚠️ Requires Permission:
- Commercial use
- Public deployments
- Derivative works
- Redistributions

❌ Not Allowed:
- Unauthorized commercial use
- Removing attribution
- Using BozoCord branding
- Training AI/ML models
- Creating competing products

### License Badges

<div align="center">

[![License](https://img.shields.io/badge/License-Custom%20BozoCord-blue.svg?style=for-the-badge)](LICENSE.md)
[![Protection](https://img.shields.io/badge/Protection-Strong-red.svg?style=for-the-badge)](LICENSE.md)
[![Commercial Use](https://img.shields.io/badge/Commercial%20Use-Restricted-orange.svg?style=for-the-badge)](LICENSE.md)
[![Terms](https://img.shields.io/badge/Terms-Required-yellow.svg?style=for-the-badge)](https://coming.soon/terms)
[![Security](https://img.shields.io/badge/Security-Enhanced-green.svg?style=for-the-badge)](https://coming.soon/security-policy)

</div>

```
Copyright © 2024-2025 NansStudios. All rights reserved.
```

For licensing inquiries: coming.soon@nansstudios.com

</details>

## 💬 Community & Support

<div align="center">

[![Discord](https://img.shields.io/discord/1234567890?style=for-the-badge&logo=discord)](https://discord.gg/bozocord)
[![Twitter](https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/Nanaimo_2013)
[![GitHub Discussions](https://img.shields.io/github/discussions/Nanaimo2013/BozoCord?style=for-the-badge&logo=github)](https://github.com/Nanaimo2013/BozoCord/discussions)

</div>

---

<div align="center">

Made with ❤️ by [NansStudios](https://github.com/Nanaimo2013)

</div>

<div align="center">

### *BozoCord*

*Where Communities Thrive, Connections Come Alive*

<sub>Your Voice • Your Community • Your Future</sub>

</div>

