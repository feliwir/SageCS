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
            vertices[0] = pos;
            vertices[1] = new Vector2(pos.X+size.X, pos.Y);
            vertices[2] = new Vector2(pos.X, pos.Y+ size.Y);
            vertices[3] = new Vector2(pos.X + size.X, pos.Y);
            vertices[4] = new Vector2(pos.X, pos.Y+size.Y);
            vertices[5] = pos + size;

            vertBuf.BufferData(BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw, vertices);
            modelMat = Matrix4.Identity;
            tex = t;
        }

        public override void Draw(Camera cam)
        {
            GL.EnableVertexAttribArray(0);
            vertBuf.Bind(BufferTarget.ArrayBuffer); 
            //tex.Bind();
            Matrix4 mvp = cam.GetProjectionMatrix()*cam.GetViewMatrix()*modelMat;
            GL.UniformMatrix4(0,false,ref mvp);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.DrawArrays(PrimitiveType.Triangles,0,6);
            GL.DisableVertexAttribArray(0);
        }
    }
}