namespace EmuFish.SharkBoy

open EmuFish.Core

type SharkBoy =
    interface ICore<bool> with
        member this.Initialize () = ()
        member this.SupportsRom name = name.EndsWith(".gb")
        member this.Load name = true
    
