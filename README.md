Often times in games like _World of Warcraft_ there would be so much happening on my screen that I would lose where my cursor is. _Heroes of the Storm_ has an accessibility option that helps with this issue by drawing lines in cardinal directions from your cursor, which helps you locate where it is.

_Whiskers_ aims to bring this feature to any game, or really anything, in the form of a small, simple desktop application.

## Features

- Easily toggleable from its tray icon
- Customize lines including color, opacity, and thickness
- Can watch for specific running processes, like those of games, to automatically enable the lines

## Process Watcher Usage

To use the process watcher simply enter the names of the processes on the settings page, one per line, without its extension.

Currently, you must provide the **exact** name of the processes. For example, the process for _World of Warcraft_ is `Wow.exe`, so you would enter `Wow`.

## Installation

Whiskers isn't fully released yet, but you can still download and use it via the automatic dev builds. These are compiled and uploaded whenever any change is pushed to the project. Because of this there can be bugs, so you have been warned!

There are two flavors of Whiskers you can download:

- _Framework Dependent_ which is the application compiled without including the runtime within it. This results in a very small executable size (less than 1MB at the time of writing) __but__ requires the [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to run.
- _Self-Contained_ which is the application compiled with the .NET 8 Desktop Runtime included. This allows the application to run on the system without needing to install the runtime by massively increases the compiled file size.

Both of these flavors are provided in dev builds as `fd` for Framework Dependent and `sc` for Self-Contained.

You can view the latest dev build release [here.](https://github.com/depthbomb/Whiskers/releases)
