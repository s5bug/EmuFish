namespace EmuFish.Core

open Silk.NET

type Register = { width: uint8; name: string }

type VulkanRenderTarget = {
    api: Vulkan.Vk
    instance: Vulkan.Instance
    physicalDevice: Vulkan.PhysicalDevice
    device: Vulkan.Device
    image: Vulkan.Image
}

type ICore<'state, 'register when 'register: enum<uint8>> =
    interface

        abstract member Initialize : Vulkan.Instance -> 'state
        abstract member SupportsRom : string -> bool

        abstract member Load : string -> 'state -> 'state
        abstract member Resolution : 'state -> int * int
        abstract member Render : 'state -> 'state

        abstract member RegisterInfo : 'register -> Register


    end
