# development currently paused

I am waiting for an Avalonia-independent way to pass a Vulkan or OpenGL context
around (most likely from Silk.NET) before I work on this project further.

[AvaloniaUI/Avalonia#7753](https://github.com/AvaloniaUI/Avalonia/pull/7753)
provides this functionality. I am waiting for that to be merged, or otherwise
usable.

# EmuFish

EmuFish aims to be a highly-scriptable emulator framework, like BizHawk, except
multiplatform (not Windows-only) and with better support and less input lag for
newer/less-retro systems (such as the Nintendo 64).

## build instructions

EmuFish is a standard dotnet solution. If you have `dotnet` installed already,
then
```
dotnet publish --self-contained false --configuration Release
```
should create a working build.

Otherwise, you may be able to grab builds from GitHub actions, however these
are built in `Debug` mode.

Modern Macs require all applications and libraries to be `codesign`ed. At the
present moment, this is not built-in to the GitHub Actions workflow, and if you
are a Mac user, you will have to `codesign` EmuFish along with its libraries
yourself.

To force an ad-hoc signing on Mac:
```
codesign --sign - --force --deep EmuFish.app
```

On a release, GitHub actions artifacts will be attached, built in `Release`
mode, but as of writing no releases exist. Release builds should, at some point,
come with signatures for both Windows and Mac. When that happens, these
instructions will be updated to include how to distinguish an official release
binary.

## progress

- [ ] Emulation
  - [ ] Basic display-synced emulation
  - [ ] Smart frame advance
  - [ ] JIT framework
    - [ ] Aggressive JIT during fast-forward
  - [ ] Scripting API
    - [ ] Reading memory
    - [ ] Writing memory safely
    - [ ] Virtual input
    - [ ] Drawing over main canvas
    - [ ] External windows
      - [ ] Avalonia.FuncUI bindings for NLua?
  - [ ] Segment-aware memory viewer/editor
- [ ] Input
  - [ ] Keyboard input
  - [ ] Generic HID input
  - [ ] Remapping
    - [ ] Thresholds for buttons controlled by an analog signal
    - [ ] Stick/axis calibration
- [ ] Base Targets
  - [ ] Early Nintendo Handhelds
    - [ ] GameBoy (EmuFish.SharkBoy)
    - [ ] GameBoy Advance (EmuFish.LavaGirl)
  - [ ] Early Nintendo Consoles
    - [ ] Nintendo Entertainment System
    - [ ] Super Nintendo Entertainment System
  - [ ] BizHawk-replacement stretch goals
    - [ ] Nintendo 64
- [ ] Additional Targets
  - [ ] Guide on how to develop cores
  - [ ] Example external core project
