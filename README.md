# BozoCord

<div align="center">

### A modern, customizable Discord-like communication platform built with .NET 5.0 and React

<br/>

[![DOWNLOAD LATEST FOR WINDOWS](https://img.shields.io/github/downloads/Nanaimo2013/BozoCord/latest/BozoCord.Installer.exe?style=for-the-badge&label=Download%20Latest%20for%20Windows&color=00aa00)](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.Installer.exe)

<br/>

[![Latest Release](https://img.shields.io/github/v/release/Nanaimo2013/BozoCord?style=for-the-badge&color=blue&label=Latest%20Release)](https://github.com/Nanaimo2013/BozoCord/releases)
[![Version](https://img.shields.io/github/v/tag/Nanaimo2013/BozoCord?label=%20Version&style=for-the-badge&color=orange)](https://github.com/Nanaimo2013/BozoCord/releases/latest)
[![GitHub license](https://img.shields.io/github/license/Nanaimo2013/BozoCord?style=for-the-badge&color=blue)](https://github.com/Nanaimo2013/BozoCord/blob/main/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/Nanaimo2013/BozoCord?style=for-the-badge&color=red)](https://github.com/Nanaimo2013/BozoCord/issues)
[![GitHub stars](https://img.shields.io/github/stars/Nanaimo2013/BozoCord?style=for-the-badge&color=yellow)](https://github.com/Nanaimo2013/BozoCord/stargazers)
[![Downloads](https://img.shields.io/github/downloads/Nanaimo2013/BozoCord/total?style=for-the-badge&color=blue)](https://github.com/Nanaimo2013/BozoCord/releases)
[![Contributors](https://img.shields.io/github/contributors/Nanaimo2013/BozoCord?style=for-the-badge&color=orange)](https://github.com/Nanaimo2013/BozoCord/graphs/contributors)
[![Code Size](https://img.shields.io/github/languages/code-size/Nanaimo2013/BozoCord?style=for-the-badge&color=blue)](https://github.com/Nanaimo2013/BozoCord)
[![Open Source](https://img.shields.io/badge/Open%20Source-No-red?style=for-the-badge&logo=github)](https://github.com/Nanaimo2013/BozoCord)
[![Maintained](https://img.shields.io/maintenance/yes/2024?style=for-the-badge&color=green)](https://github.com/Nanaimo2013/BozoCord)
[![Build Status](https://img.shields.io/github/actions/workflow/status/Nanaimo2013/BozoCord/ci.yml?style=for-the-badge&color=brightgreen)](https://github.com/Nanaimo2013/BozoCord/actions)
[![Forks](https://img.shields.io/github/forks/Nanaimo2013/BozoCord?style=for-the-badge&color=lightgray)](https://github.com/Nanaimo2013/BozoCord/network/members)

<br/>

[📖 Documentation](docs/README.md) •
[🚀 Getting Started](#-getting-started) •
[💡 Features](#-features)

</div>

<br/>

## ⚠️ Development Status

<div align="center">

> **Warning:** BozoCord is currently under active development. The project structure, features, and APIs may change significantly. We recommend:
> - Using the latest release version for production use
> - Following our [releases page](https://github.com/Nanaimo2013/BozoCord/releases) for stable versions
> - Checking the [changelog](CHANGELOG.md) for breaking changes

</div>

## ✨ Features

<table>
<tr>
<td>

### 💬 Communication
- Real-time messaging
- Direct messaging
- File sharing
- Message threading
- Voice channels
- Custom emojis

</td>
<td>

### 🛡️ Security
- End-to-end encryption
- Role-based permissions
- JWT Authentication
- BCrypt Password Hashing
- Secure WebSocket

</td>
</tr>
<tr>
<td>

### 🎮 Platform Support
- Web application
- Desktop client
- Mobile app
- Cross-platform
- Modern UI/UX

</td>
<td>

### 🛠️ Development
- User-driven features
- Custom integrations
- Bot API support
- Webhook system
- Developer tools

</td>
</tr>
</table>

## 🚀 Getting Started

<div align="center">

### Quick Download & Install

[![DOWNLOAD LATEST FOR WINDOWS](https://img.shields.io/github/downloads/Nanaimo2013/BozoCord/latest/BozoCord.Installer.exe?style=for-the-badge&label=Download%20Latest%20for%20Windows&color=00aa00)](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.Installer.exe)

</div>

### Prerequisites

<div align="center">

[![.NET 5.0](https://img.shields.io/badge/.NET-5.0-blue.svg?style=for-the-badge)](https://dotnet.microsoft.com/download/dotnet/5.0)
[![Node.js](https://img.shields.io/badge/Node.js-18+-green.svg?style=for-the-badge)](https://nodejs.org/)
[![SQLite](https://img.shields.io/badge/SQLite-Latest-orange.svg?style=for-the-badge)](https://www.sqlite.org/)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-blue.svg?style=for-the-badge)](https://code.visualstudio.com/)

</div>

### Installation Options

#### 1. Easy Install (Recommended)
1. Download and run the [BozoCord Installer](https://github.com/Nanaimo2013/BozoCord/releases/latest/download/BozoCord.Installer.exe)
2. Follow the installation wizard
3. Launch BozoCord from your desktop

#### 2. Manual Installation (For Developers)
```bash
# Clone the latest release
git clone -b v1.0.0 https://github.com/Nanaimo2013/BozoCord.git
cd BozoCord

# Restore packages
dotnet restore

# Install frontend dependencies
cd BozoCord.Web/Web.Frontend
npm install

# Run database migrations
cd ../..
dotnet ef database update --project BozoCord.Core

# Start the application
dotnet run --project BozoCord.Web
```

## 📦 Project Structure

```
BozoCord/
├── BozoCord.Core                  # Shared Core Library
│   ├── Models                     # Data models
│   │   ├── Chat                  # Chat-related models
│   │   │   ├── Message.cs        # Message model
│   │   │   ├── DirectMessage.cs  # Direct message model
│   │   │   └── Reaction.cs       # Message reactions
│   │   ├── Server                # Server-related models
│   │   │   ├── Server.cs         # Server model
│   │   │   ├── Channel.cs        # Channel model
│   │   │   └── Role.cs           # Role model
│   │   └── User                  # User-related models
│   │       └── User.cs           # User model
│   ├── Services                   # Business logic
│   │   ├── Auth                  # Authentication services
│   │   │   └── AuthService.cs    # Authentication logic
│   │   ├── Data                  # Data access services
│   │   │   └── BozoCordDbContext.cs  # Database context
│   │   └── WebSocket            # WebSocket services
│   │       ├── IWebSocketService.cs   # WebSocket interface
│   │       └── WebSocketClient.cs     # WebSocket client
│   ├── Logger                     # Logging utilities
│   │   └── Logger.cs             # Logging implementation
│   └── Utils                      # Helper utilities
└── BozoCord.Web                   # Web Application
    ├── Web.Core                   # Web-specific core logic
    ├── Web.UI                     # UI components
    ├── Web.Backend                # Backend integration
    ├── Web.Frontend               # React frontend
    └── Web.Services               # Web-specific services
```

## 📊 Development Roadmap

<div align="center">

### Phase 1: Core Infrastructure (Current)
- [x] Basic project structure
- [x] Database models and context
- [x] Authentication system
- [x] WebSocket implementation
- [ ] Basic UI components

### Phase 2: Essential Features
- [ ] User management
- [ ] Server creation and management
- [ ] Channel system
- [ ] Basic messaging
- [ ] File uploads

### Phase 3: Advanced Features
- [ ] Voice channels
- [ ] Rich media support
- [ ] Role system
- [ ] Moderation tools
- [ ] Bot API

### Phase 4: Polish & Optimization
- [ ] Performance optimization
- [ ] Security hardening
- [ ] UI/UX improvements
- [ ] Cross-platform testing
- [ ] Documentation

</div>

## 📚 Documentation

- [🏛️ Architecture Overview](docs/architecture.md)
- [🔨 Build System Guide](docs/building.md)
- [📝 Changelog](CHANGELOG.md)
- [🛣️ Project Roadmap](docs/roadmap.md)

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

<div align="center">

[![Apache License 2.0](https://img.shields.io/badge/LICENSE-Apache%202.0-blue.svg?style=for-the-badge)](LICENSE)

Copyright © 2025 NansStudios. All rights reserved.

</div>

## 🌐 Connect with Us

<div align="center">

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github)](https://github.com/Nanaimo2013)
[![Twitter](https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/Nanaimo_2013)

</div>

---

<div align="center">

**[Documentation](docs/README.md)** •
**[Report Bug](https://github.com/Nanaimo2013/BozoCord/issues)** •
**[Request Feature](https://github.com/Nanaimo2013/BozoCord/issues)**

Made with ❤️ by NansStudios
*BozoCord - Your voice, your community, your way.*

</div>
