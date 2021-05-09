namespace EmuFish

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.ReactiveUI
open EmuFish.ViewModels
open EmuFish.Views

module Program =
    
    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp() =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI()
    
    let startMainWindow app opts =
        let app = app()
        // model.Start opts
        
        let mainWinVM = MainWindowViewModel()
        let mainWin = MainWindow(DataContext = mainWinVM)
        
        app <| mainWin
        
        0
    
    [<EntryPoint>]
    [<CompiledName "Main">]
    let main (args: array<string>) : int =
        let builder = lazy buildAvaloniaApp()
        let lifetime = lazy new ClassicDesktopStyleApplicationLifetime()
        let app () = 
            // Avalonia initialization
            let lifetime = lifetime.Value
            if not builder.IsValueCreated then
                let _ = builder.Value.SetupWithLifetime(lifetime)
                ()
            // Avalonia is initialized. SynchronizationContext-reliant code should be working by now;
            (fun (win: Avalonia.Controls.Window) ->
                lifetime.ShutdownMode <- Controls.ShutdownMode.OnMainWindowClose
                lifetime.MainWindow <- win
                lifetime.Start(args) |> ignore)
        
        startMainWindow app ()
