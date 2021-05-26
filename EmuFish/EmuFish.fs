namespace EmuFish

open Avalonia.Controls.ApplicationLifetimes

module EmuFish =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout
    
    type State = { core: unit }
    let init = { core = () }
    
    type Msg = Exit
    
    let update (msg: Msg) (state: State): State =
        init
    
    let shutdown exitcode =
        match Avalonia.Application.Current.ApplicationLifetime with 
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime -> 
            desktopLifetime.Shutdown exitcode
        | _ -> ()
    
    let fileMenu (state: State) (dispatch) =
        MenuItem.create [
            MenuItem.header "_File"
            MenuItem.viewItems [
                MenuItem.create [
                    MenuItem.header "_Open..."
                ]
                Separator.create []
                MenuItem.create [
                    MenuItem.header "_Exit"
                    MenuItem.onClick (fun _ -> shutdown 0)
                ]
            ]
        ]
    
    let topMenu (state: State) (dispatch) =
        Menu.create [
            Menu.dock Dock.Top
            Menu.viewItems [
                fileMenu state dispatch
            ]
        ]
    
    let bottomStatus (state: State) (dispatch) =
        TextBlock.create [
            TextBlock.dock Dock.Bottom
            TextBlock.text "No Core Loaded"
        ]
    
    let emulatorView (state: State) (dispatch) =
        EmulatorView.create [
            // TODO: figure out why this margin is needed
            EmulatorView.margin (0.0, -16.0, 0.0, 16.0)
        ]
    
    let view (state: State) (dispatch) =
        DockPanel.create [
            DockPanel.children [
                topMenu state dispatch
                bottomStatus state dispatch
                emulatorView state dispatch
            ]
        ]
