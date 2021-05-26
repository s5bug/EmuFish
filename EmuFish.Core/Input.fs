module EmuFish.Core.Input

type Pad(inputChoices: array<InputChoice>) = class end
and InputChoice =
    | Digital of buttonName: string
    | Analog of axisName: string
    | Extension of choices: Map<string, Pad>
