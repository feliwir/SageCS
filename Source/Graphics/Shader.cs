using System;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace SageCS.Graphics
{
    class Shader
    {
        private int program = -1;
        private int vertShader = -1;
        private int fragShader = -1;

        private void PrintShaderLog(int shader)
        {
            String log = GL.GetShaderInfoLog(shader);
            if(log.Length>0)
                Console.WriteLine(log);
        }

        private void PrintProgramLog()
        {
            String log = GL.GetProgramInfoLog(program);
            if (log.Length > 0)
                Console.WriteLine(log);
        }

        public Shader()
        {
            program = GL.CreateProgram();
            vertShader = GL.CreateShader(ShaderType.VertexShader);
            fragShader = GL.CreateShader(ShaderType.FragmentShader);
        }

        public void Load(Stream vert, Stream frag)
        {
            StreamReader sr = new StreamReader(vert);
            String src = sr.ReadToEnd();
            GL.ShaderSource(vertShader,src);
            GL.CompileShader(vertShader);
            PrintShaderLog(vertShader);

            sr = new StreamReader(frag);
            src = sr.ReadToEnd();
            GL.ShaderSource(fragShader,src);
            GL.CompileShader(fragShader);
            PrintShaderLog(fragShader);

            GL.AttachShader(program, vertShader);
            GL.AttachShader(program, fragShader);

            GL.LinkProgram(program);
            PrintProgramLog();
        }

        public void Use()
        {
            GL.UseProgram(program);
        }
    }
}
