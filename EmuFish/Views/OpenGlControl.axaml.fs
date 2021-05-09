namespace EmuFish.Views

open Avalonia.OpenGL.Controls
open type Avalonia.OpenGL.GlConsts

type OpenGlControl() =
    inherit OpenGlControlBase()
    
    override this.OnOpenGlRender(gl, fb) =
        // TODO: Call to the loaded core
        gl.ClearColor.Invoke(0.0F, 0.0F, 0.0F, 1.0F)
        gl.Clear.Invoke(GL_COLOR_BUFFER_BIT)
        gl.Viewport.Invoke(0, 0, int this.Bounds.Width, int this.Bounds.Height)
