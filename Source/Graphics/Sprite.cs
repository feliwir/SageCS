using OpenTK;
using OpenTK.Graphics.OpenGL;
using SageCS.Core.Graphics;
using SageCS.Graphics;

namespace SageCS.Source.Graphics
{
    public class Sprite : IDrawable
    {
        private Buffer vertBuf;
        private Texture tex;
        private Matrix4 modelMat;

        public Sprite(OpenTK.Vector2 pos, OpenTK.Vector2 size,Texture t)
        {
            vertBuf = new Buffer();
            Vector2[] vertices = new Vector2[6];
            vertices[0] = new Vector2(0f, 0f);
            vertices[1] = new Vector2(pos.X, 0f);
            vertices[2] = new Vector2(0f,pos.Y);
            vertices[3] = new Vector2(pos.X, 0f);
            vertices[4] = new Vector2(0f, pos.Y);
            vertices[5] = pos;

            vertBuf.BufferData(BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw, vertices); 
            tex = t;
        }

        public override void Draw(Camera cam)
        {
            GL.EnableVertexAttribArray(0);
            vertBuf.Bind(BufferTarget.ArrayBuffer); 
            //tex.Bind();
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.DrawArrays(PrimitiveType.Triangles,0,6);
            GL.DisableVertexAttribArray(0);
        }
    }
}