<div align="center">

<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" width="80" alt="C#"/>

# ♟️ ChessEngine — C#

**A fully-featured Chess Engine built with C# · Minimax · Alpha-Beta Pruning · WPF UI**

[![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Framework](https://img.shields.io/badge/Framework-.NET%20WPF-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
[![Algorithm](https://img.shields.io/badge/Algorithm-Minimax%20%2B%20Alpha--Beta-red?style=for-the-badge&logo=databricks&logoColor=white)]()
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)
[![Stars](https://img.shields.io/github/stars/khafifithebork/ChessEngineCSHARP?style=for-the-badge&logo=github)](https://github.com/khafifithebork/ChessEngineCSHARP/stargazers)


</div>

---

## 📖 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Architecture](#-architecture)
- [Algorithm Deep Dive](#-algorithm-deep-dive)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [How It Works](#-how-it-works)
- [Roadmap](#-roadmap)
- [Contributing](#-contributing)
- [Author](#-author)
- [License](#-license)

---

## 🧩 Overview

**ChessEngineCSHARP** is a complete chess application written in **C#**, featuring a fully functional AI opponent powered by the **Minimax algorithm with Alpha-Beta Pruning**. The project is cleanly split into two layers: a reusable **ChessLogic** library containing all game rules and AI logic, and a **ChessUI** WPF desktop application providing a smooth interactive interface.

This project was built as an exploration of classical game AI, tree-search algorithms, and object-oriented design in the .NET ecosystem.

---

## ✨ Features

| Feature | Status |
|---|---|
| ♟️ Full chess rule enforcement (legal move generation) | ✅ |
| 👑 All special moves — castling, en passant, pawn promotion | ✅ |
| 🤖 AI opponent via Minimax + Alpha-Beta Pruning | ✅ |
| 🖥️ WPF graphical user interface | ✅ |
| 🔄 Turn-based game flow with state management | ✅ |
| ♜ Check & Checkmate detection | ✅ |
| 🤝 Stalemate & draw detection | ✅ |
| 🔁 Move highlighting & piece selection feedback | ✅ |

---

## 🏗️ Architecture

The project follows a clean **two-project separation** between game logic and presentation:

```
ChessEngineCSHARP/
├── ChessLogic/          # Core library — rules, pieces, AI engine
│   ├── Board.cs         # Board state representation
│   ├── Piece.cs         # Base piece class & subclasses
│   ├── Move.cs          # Move representation
│   ├── GameState.cs     # Turn management & game flow
│   └── AI/              # Minimax + Alpha-Beta search
│
├── ChessUI/             # WPF Application — visual layer
│   ├── MainWindow.xaml  # Game board UI
│   ├── Images/          # Piece & board assets
│   └── *.xaml.cs        # UI event handlers
│
└── ChessEngine.sln      # Visual Studio solution
```

**Design principle:** `ChessUI` depends on `ChessLogic`, but `ChessLogic` has **zero dependency** on `ChessUI`. This means the engine can be reused with any other front-end (console, web API, etc.).

---

## 🧠 Algorithm Deep Dive

### Minimax

The AI uses the **Minimax algorithm**, which models chess as a two-player zero-sum game. It recursively builds a game tree and evaluates leaf nodes using a static evaluation function.

```
Maximizing player (AI)  →  picks move with highest score
Minimizing player (Human) →  picks move with lowest score
```

### Alpha-Beta Pruning

Alpha-Beta Pruning is layered on top of Minimax to drastically **reduce the number of nodes evaluated** in the game tree — without affecting the result. It tracks two bounds:

- **α (alpha)** — the best score the maximizer is guaranteed so far
- **β (beta)** — the best score the minimizer is guaranteed so far

When `α ≥ β`, the remaining subtree is **pruned** (skipped), as it cannot influence the final decision.

```
Without Alpha-Beta:  O(b^d)    nodes explored
With Alpha-Beta:     O(b^(d/2)) nodes explored (best case)
```

This effectively **doubles the searchable depth** for the same computational budget.

### Evaluation Function

Board positions are evaluated based on:
- **Material count** — weighted sum of remaining pieces
- **Piece-square tables** — positional bonuses/penalties per piece type
- **Game phase** — distinguishing opening, middlegame, and endgame heuristics

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 6+](https://dotnet.microsoft.com/en-us/download) or [Visual Studio 2022](https://visualstudio.microsoft.com/)
- Windows OS (required for WPF)

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/khafifithebork/ChessEngineCSHARP.git

# 2. Open in Visual Studio
# Double-click ChessEngine.sln
# or

# 3. Build via CLI
cd ChessEngineCSHARP
dotnet build ChessEngine.sln

# 4. Run the UI project
dotnet run --project ChessUI
```

---

## 📂 Project Structure

```
ChessEngineCSHARP/
│
├── 📁 ChessLogic/                  ← Reusable game engine library
│   ├── 📄 Board.cs                 ← 8×8 board state, piece positions
│   ├── 📄 Piece.cs                 ← Abstract Piece + King, Queen, Rook, Bishop, Knight, Pawn
│   ├── 📄 Move.cs                  ← Move object: from, to, flags (castle, en passant…)
│   ├── 📄 GameState.cs             ← Turn management, check/checkmate/stalemate logic
│   ├── 📄 MoveGenerator.cs         ← Legal move generation per piece
│   └── 📄 AIEngine.cs              ← Minimax + Alpha-Beta search + evaluation
│
├── 📁 ChessUI/                     ← WPF desktop application
│   ├── 📄 MainWindow.xaml          ← Main board layout
│   ├── 📄 MainWindow.xaml.cs       ← Click handlers, UI ↔ engine bridge
│   └── 📁 Images/                  ← SVG/PNG piece & board assets
│
└── 📄 ChessEngine.sln              ← Visual Studio solution file
```

---

## ⚙️ How It Works

```
User clicks a piece
        │
        ▼
ChessUI captures click → asks ChessLogic for legal moves
        │
        ▼
Highlights available squares on the board
        │
        ▼
User selects destination → ChessUI sends Move to GameState
        │
        ▼
GameState applies move, checks for check/checkmate/stalemate
        │
        ▼
If AI turn → AIEngine.GetBestMove() runs Minimax + Alpha-Beta
        │
        ▼
Best move returned → board updated → UI re-renders
```

---

## 🗺️ Roadmap

- [ ] 🔢 Configurable AI search depth (difficulty levels)
- [ ] 📚 Opening book integration
- [ ] 🔁 Move history & undo support
- [ ] 💾 PGN export / import
- [ ] ⏱️ Chess clock & time controls
- [ ] 🌐 UCI protocol support (play against other engines)
- [ ] 🧪 Unit tests for move generation and AI correctness

---

## 👤 Author

<div align="center">

**Ayman Khafifi**

[![GitHub](https://img.shields.io/badge/GitHub-khafifithebork-181717?style=for-the-badge&logo=github)](https://github.com/khafifithebork)

*Engineering Student · INPT Rabat*

</div>

---

## 📄 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

</div>
