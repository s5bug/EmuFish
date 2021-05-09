﻿namespace EmuFish

open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Templates
open Avalonia.Markup.Xaml
open EmuFish.ViewModels
open System

type App() as this =
    inherit Application()
    
    override this.Initialize() =
        AvaloniaXamlLoader.Load(this)

type IViewModelContainer =
    abstract Target: obj

type ViewLocator() =
    interface IDataTemplate with
        member this.Build(data: obj): IControl = 
            match data with
            | :? IViewModelContainer as container -> (this :> IDataTemplate).Build(container.Target)
            | _ ->
            let _name = data.GetType().FullName.Replace("ViewModel", "");
            let _type = Type.GetType(_name);
            if _type <> null 
            then Activator.CreateInstance(_type) :?> IControl;
            else TextBlock( Text = "Not Found: " + _name ) :> IControl
        member this.Match(data: obj): bool = 
            data :? ViewModelBase || data :? IViewModelContainer
