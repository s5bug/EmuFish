namespace EmuFish.Core

open Silk.NET.OpenGL

type Register = { width: uint8; name: string }

type ICore<'state, 'register when 'register: enum<uint8>> =
    interface

        abstract member Initialize : unit -> unit
        abstract member SupportsRom : string -> bool

        abstract member Load : string -> 'state
        abstract member Resolution : 'state -> int * int
        abstract member Render : GL -> unit

        abstract member RegisterInfo : 'register -> Register


    end
