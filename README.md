# RevaloniaApp

## About

This repository contains a workflow and framework that you can adopt to develop
addin for Autodesk Revit using [Avalonia UI](https://avaloniaui.net).

This project is meant to be a successor of the
[Revalonia](https://github.com/dla-hubs/revalonia). Due to the singleton
behaviour of AvaloniaApp builder, I now have taken out the AppBuilder part of
the code and have it in the separate codebase so that you can build a separate
DLL that can get loaded into Revit as a separate addin.

## Get started

More detailed documentation to come. Meanwhile, you can clone the repository and
build the DLLs on your own (don’t forget to write the manifestos to load the
DLLs) . The codebase contains the minimum setting and a simple example to
demonstrate workflows interfacing with Avalonia & Revit API.

- **RevaloniaAddin** ⇒ Minimum template for creating RevaloniaApp addin
- **RevaloniaAppBuilder** ⇒ the AppBuilder (can pass theme etcs to the
  RevaloniaApps)
- **TwoPointHeightUi** ⇒ Avalonia app just so that you can develop UI/UX without
  launching the Revit in debug mode.
