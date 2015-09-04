﻿using OpenTK.Audio.OpenAL;

namespace SageCS.Audio
{
    class SoundBuffer 
    {
        private int id;
        
        public SoundBuffer()
        {
            id = AL.GenBuffer();
        }   

        public void BufferData(byte[] data,ALFormat format,int freq)
        {
            AL.BufferData(id, format, data, data.Length, freq);
        }

        public int GetID()
        {
            return id;
        }

        ~SoundBuffer()
        {
            AL.DeleteBuffer(id);
        }
    }
}
