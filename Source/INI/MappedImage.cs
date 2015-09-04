namespace SageCS.INI
{
    class MappedImage
    {
        public struct Coords
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public string Texture;
        public int TextureWidth;
        public int TextureHeight;
        public Coords coords;
        public string Status;
    }
}
