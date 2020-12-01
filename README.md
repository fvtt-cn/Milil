# Milil
A simple tool to turn your music collections into Foundry VTT Module with playlists.

[English README](README.md) | [中文说明](README_CN.md)

## Installation
Milil itself does not need installation, it's a Click-to-Run program.

[Download Link](https://github.com/fvtt-cn/Milil/releases)

However, you need `.NET 5.0` Runtime to run it or download a self-contained Milil instead. *Milil size <1M, but self-contained Milil size >30M.*

[.NET Desktop Runtime 5.0.0](https://dotnet.microsoft.com/download/dotnet/5.0)

## Usage
1. Ensure your music collection directory structure to be organized as below.
    ```
    📦My_Music
    ┣ 📂1st Playlist
    ┃ ┣ 🎵Daredevil (Extended).ogg
    ┃ ┗ 🎵The Unsung War.ogg
    ┣ 📂2nd Playlist
    ┃ ┣ 🎵Aksis_Theme.ogg
    ┃ ┗ 🎵Journey (feat. Kronos Quartet).ogg
    ┗ 🤖Milil.exe
    ```
2. Run `Milil.exe` and it will generate `module.json` and `playlists.db`. 
3. Modify the generated files and delete `Milil.exe`.
3. Move the whole root directory under `Data/modules/` that Foundry VTT configured.

## Limitation
- Currently, Milil will ignore all 2nd level and deeper directories and their files/musics.
- The root directory name must be a valid Foundry VTT module name (e.g. `My_Music`, but can't be `My Music?!`).
- A valid filename might be URL unsafe and not handled by Milil and Foundry VTT itself. If so, it'd be unplayable.
  - Currently, Milil escapes `#`.
- Only detects files with `.ogg|.mp3|.flac|.wav|.webm` extension (From Foundry VTT officially supported sound formats list).