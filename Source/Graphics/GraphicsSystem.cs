using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SageCS.Core;
using SageCS.Source.Graphics;

namespace SageCS.Graphics
{
    public static class GraphicsSystem
    {
        private static Camera screen = new Camera2D(1024,768);
        private static Shader spriteShader;

        private static void DebugCallback(DebugSource source, DebugType type, int id,
        DebugSeverity severity, int length, IntPtr message, IntPtr userParam)
        {
            string msg = Marshal.PtrToStringAnsi(message);
            Console.WriteLine("[GL] {0}; {1}; {2}; {3}; {4}",
                source, type, id, severity, msg);
        }

        public static void Init()
        {
            GL.DebugMessageCallback(DebugCallback,IntPtr.Zero); 
            spriteShader = new Shader();
            spriteShader.Load(Resource.GetShader("tex.vert"),Resource.GetShader("tex.frag"));
            spriteShader.Use();

        }

        public static Camera GetScreen()
        {
            return screen;
        }
    }
}