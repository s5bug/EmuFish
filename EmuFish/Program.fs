namespace EmuFish

open System
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.FuncUI.Components.Hosts
open Avalonia.Input
open Avalonia.FuncUI
open Avalonia.FuncUI.Elmish
open Avalonia.Shared.PlatformSupport

type MainWindow() as this =
    inherit HostWindow()
    
    let loader = AssetLoader()
    
    do
        this.Title <- "EmuFish"
        this.Width <- 800.0
        this.Height <- 600.0
        this.Icon <- WindowIcon(loader.Open(Uri("avares://EmuFish/Assets/emufish-logo.ico")))
        
        Elmish.Program.mkSimple (fun () -> EmuFish.init) EmuFish.update EmuFish.view
        |> Elmish.Program.withHost this
        |> Elmish.Program.withConsoleTrace
        |> Elmish.Program.run

type App() =
    inherit Application()

    override this.Initialize() =
        this.Styles.Load "avares://Avalonia.Themes.Fluent/FluentLight.xaml"

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow()
        | _ -> ()

module Program =

    [<EntryPoint>]
    let main(args: string[]) =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .With(Win32PlatformOptions(UseWgl = true))
            .StartWithClassicDesktopLifetime(args)
