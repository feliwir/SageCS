using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SageCS.Graphics
{
    class Buffer
    {
        private int id = -1;

        public Buffer()
        {
            id = GL.GenBuffer();
        }

        public void Bind(BufferTarget target)
        {
            GL.BindBuffer(target,id);
        }

        public void BufferData(BufferTarget target,BufferUsageHint usage,Vector2[] vertices)
        {
            Bind(target);
            GL.BufferData<Vector2>(target, new IntPtr(vertices.Length * Vector2.SizeInBytes), vertices, usage);
        }

        public void BufferData(BufferTarget target, BufferUsageHint usage, Vector3[] vertices)
        {
            Bind(target);
            GL.BufferData<Vector3>(target, new IntPtr(vertices.Length * Vector3.SizeInBytes), vertices, usage);
        }

        ~Buffer()
        {
            GL.DeleteBuffer(id);
        }
    }
}
