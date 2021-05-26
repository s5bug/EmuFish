module EmuFish.Core.Script

open NLua

type Script(origin: string, state: Lua) =
    static member Open (path: string) : Script =
        let lua = new Lua()
        lua.DoFile path |> ignore
        Script(path, lua)
