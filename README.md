# XboxOverlayEngine

**XboxOverlayEngine** is a modular achievement overlay system designed for immersive gaming experiences. It integrates with Game Bar, Steam, Discord, and custom hooks to display real-time achievement notifications, log events, and simulate unlocks for testing and demos.

## 🎮 Features

- Real-time achievement overlays across multiple platforms
- Dispatcher logic for unified event handling
- SQLite-backed logging and replay capture
- OAuth integration with Xbox Live (via Entra ID)
- Self-healing modules for Game Bar and Xbox service monitoring
- Mock trigger simulation for testing and Partner Center review

## 🧪 Demo Mode

To simulate achievement unlocks and token parsing:

```bash
git checkout demo-overlay
dotnet run
