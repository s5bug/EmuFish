namespace EmuFish

open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.Types
open Avalonia.Vulkan
open Avalonia.Vulkan.Controls

type EmulatorView() =
    inherit VulkanControlBase()
    
    override this.OnVulkanRender(platformInterface: VulkanPlatformInterface, info: VulkanImageInfo): unit =
        ()
    
    static member create (attrs: list<IAttr<EmulatorView>>): IView<EmulatorView> =
        ViewBuilder.Create<EmulatorView>(attrs)
