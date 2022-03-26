namespace EmuFish.SharkBoy

open System
open EmuFish.Core
open EmuFish.SharkBoy
open Silk.NET

type SharkBoyState = { vk: Vulkan.Instance }

type SharkBoy =
    interface ICore<SharkBoyState, GameBoyRegisters> with
        member this.Initialize vk = { vk = vk }
        member this.SupportsRom name = name.EndsWith(".gb")
        member this.Load name state = state
        member this.Resolution state = 160, 144

        member this.Render state =
            state

        member this.RegisterInfo r =
            match r with
            | GameBoyRegisters.B -> { width = 8uy; name = "B" }
            | GameBoyRegisters.C -> { width = 8uy; name = "C" }
            | GameBoyRegisters.D -> { width = 8uy; name = "D" }
            | GameBoyRegisters.E -> { width = 8uy; name = "E" }
            | GameBoyRegisters.H -> { width = 8uy; name = "H" }
            | GameBoyRegisters.L -> { width = 8uy; name = "L" }
            | GameBoyRegisters.A -> { width = 8uy; name = "A" }
            | GameBoyRegisters.F -> { width = 8uy; name = "F" }
            | GameBoyRegisters.SP -> { width = 16uy; name = "SP" }
            | GameBoyRegisters.PC -> { width = 16uy; name = "PC" }
            // TODO: figure out the proper sizing of M and T
            | GameBoyRegisters.M -> { width = 16uy; name = "M" }
            | GameBoyRegisters.T -> { width = 16uy; name = "T" }
            | invalid -> ArgumentOutOfRangeException("r", invalid, "Invalid member of type GameBoyRegisters") |> raise
