# Milil
简单小工具，用于将收藏的音乐转换为 Foundry VTT 的播放列表 MOD。

[English README](README.md) | [中文说明](README_CN.md)

## 安装
Milil 自身不需要安装，双击即可运行。

然而，你需要 `.NET 5.0` 库来运行。如果没有，你需要下载替代的自封装的 Milil。*Milil 体积小于 1M，但自封装版本会大于 50M。*

[.NET Desktop Runtime 5.0.0](https://dotnet.microsoft.com/download/dotnet/5.0)

## 使用
1. 确保文件夹结构如下。
    ```
    📦My_Music
    ┣ 📂第一个播放列表
    ┃ ┣ 🎵Daredevil (Extended).ogg
    ┃ ┗ 🎵The Unsung War.ogg
    ┣ 📂第二个播放列表
    ┃ ┣ 🎵Aksis_Theme.ogg
    ┃ ┗ 🎵Journey.ogg
    ┗ 🤖Milil.exe
    ```
2. 双击运行 `Milil.exe`，将会生成 `module.json` 和 `playlists.db`。
3. 修改生成的文件并删除 `Milil.exe`。
3. 移动整个目录到 Foundry VTT 配置的 `Data/modules/` 下。

## 限制
- 目前 Milil 会忽略所有二级和更深目录里的音乐。
- 根目录名称必须是 Foundry VTT MOD 可用的名称（比如 `My_Music`）。
- 有效的文件名不一定是 URL 友好的，如果没有被 Milil 和 Foundry VTT 正确处理。这样的文件将无法播放。