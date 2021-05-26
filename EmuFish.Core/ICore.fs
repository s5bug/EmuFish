namespace EmuFish.Core

type ICore<'state> =
    interface
    
    abstract member Initialize : unit -> unit
    abstract member SupportsRom : string -> bool
    
    abstract member Load : string -> 'state
    abstract member Resolution : 'state -> int * int
    
    end
