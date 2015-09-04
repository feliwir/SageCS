using OpenTK;
using SageCS.Graphics;

namespace SageCS.Source.Graphics
{
    public class Camera2D : Camera
    {
        public Camera2D(float width,float height)
        {
            proMat = Matrix4.CreateOrthographic(width,height,0.1f,100f);
            viewMat = Matrix4.Identity;
        }

        public override Matrix4 GetProjectionMatrix()
        {
            return proMat;
        }

        public override Matrix4 GetViewMatrix()
        {
            return viewMat;
        }

        private Matrix4 viewMat;
        private Matrix4 proMat;
    }
}