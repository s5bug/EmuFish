namespace EmuFish.Views

open Avalonia.Controls
open Avalonia.Markup.Xaml
open Avalonia.ReactiveUI
open EmuFish.ViewModels

type MainWindow() as this =
    inherit ReactiveWindow<MainWindowViewModel>()
    do
        AvaloniaXamlLoader.Load this
