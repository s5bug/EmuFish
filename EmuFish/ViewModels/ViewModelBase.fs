namespace EmuFish.ViewModels

open ReactiveUI

type ViewModelBase() =
    inherit ReactiveObject()
    
    let activator = new ViewModelActivator()
    
    interface IActivatableViewModel with
        member this.Activator = activator
