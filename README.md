<div align="center">

<img src="https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/assets/logo.png" width="80" alt="Photon Logo" />

# ⚡ Photon Executor

**A fast, open-source Roblox script executor powered by the Xeno backend.**

[![License](https://img.shields.io/badge/license-MIT-yellow?style=flat-square)](LICENSE)
[![Platform](https://img.shields.io/badge/platform-Windows%2010%2F11-blue?style=flat-square)](https://microsoft.com)
[![Release](https://img.shields.io/github/v/release/FXSploit/PhotonExecutor?style=flat-square&color=yellow)](https://github.com/FXSploit/PhotonExecutor/releases)

[**Download**](#-installation) · [**Features**](#-features)

---

</div>

## 📖 Overview

Photon Executor is a lightweight, open-source script executor for Roblox built on top of the **Xeno DLL** backend. It pairs a full **Monaco code editor** (the same editor used in VS Code) with a clean, modern dark UI — making it one of the most developer-friendly free executors available.

Whether you're running quick one-liners or loading complex hub scripts, Photon gets out of your way and just works.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🖊 **Monaco Editor** | Full VS Code-grade editor with syntax highlighting, via WebView2 |
| 📑 **Script Tabs** | Multiple tabs — open, rename, and close scripts independently |
| 🌐 **Script Hub** | Live ScriptBlox integration — search, preview, and execute 60,000+ scripts |
| ⚙️ **Xeno Backend** | Native Xeno DLL injection with multi-client PID support |
| 🔄 **Auto-Attach** | Automatically re-attaches when Roblox opens — configurable interval |
| 🖥 **Console Log** | Timestamped live console for execution feedback and debug output |
| 💾 **File I/O** | Save and open `.lua` / `.txt` scripts directly from the toolbar |
| 🔝 **Always on Top** | Optional always-on-top mode for side-by-side use |
| 🎨 **Clean Dark UI** | Minimal dark + light-yellow theme with sidebar navigation |

---

## 📦 Requirements

- **OS:** Windows 10 or 11 (x64)
- **WebView2:** [Microsoft Edge WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)

---

## 🚀 Installation

1. Go to the [**Releases**](https://fxsploit.github.io/photon) page
2. Download `Photon-Bootstrapperx64.exe`
4. Run Bootstrapper and you're done!

> ⚠️ **Antivirus Warning:** Executor software interacts with process memory. Your antivirus may flag Photon as a false positive. Add an exclusion for the Photon folder if needed.

---

## 🛠 Usage

```
1. Open Roblox and join a game
2. Launch Photon.exe
3. Click ⚙ Attach  (or enable Auto-Attach in Settings)
4. Wait for the status dot to turn green — "Attached"
5. Write or paste a script in the editor
6. Click ▶ Execute
```

**Script Hub:** Click the 🌐 sidebar icon → search for any script → hit Execute or Load to Editor.

---

## 🏗 Building from Source

```bash
# Clone the repo
git clone https://github.com/FXSploit/PhotonExecutor.git
cd PhotonExecutor

# Restore NuGet packages
dotnet restore

# Build
dotnet build -c Release
```

**Dependencies:**
- `Microsoft.Web.WebView2`
- `Newtonsoft.Json`
- `Xeno.dll` *(place in project root — not included in repo)*

---

## ⚖️ Legal Disclaimer

Photon Executor is provided for **educational and research purposes only**. Using script executors in Roblox violates [Roblox's Terms of Service](https://en.help.roblox.com/hc/en-us/articles/115004647846). The authors of Photon take no responsibility for account bans, data loss, or any other consequences arising from its use.

---
