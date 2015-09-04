namespace SageCS.Graphics
{
    public abstract class Camera
    {
        public abstract OpenTK.Matrix4 GetViewMatrix();
        public abstract OpenTK.Matrix4 GetProjectionMatrix();
    }
}