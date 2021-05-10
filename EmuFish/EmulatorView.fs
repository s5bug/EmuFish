namespace EmuFish

open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.Types
open Avalonia.OpenGL
open Avalonia.OpenGL.Controls

type EmulatorView() =
    inherit OpenGlControlBase()
    
    override this.OnOpenGlRender(gl, fb) =
        gl.ClearColor.Invoke(0.0F, 0.0F, 0.0F, 1.0F)
        gl.Clear.Invoke(GlConsts.GL_COLOR_BUFFER_BIT)
    
    static member create (attrs: list<IAttr<EmulatorView>>): IView<EmulatorView> =
        ViewBuilder.Create<EmulatorView>(attrs)
