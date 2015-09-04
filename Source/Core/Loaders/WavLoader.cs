using System;
using System.IO;
using SageCS.Audio;

namespace SageCS.Core.Loaders
{
    static class WavLoader
    {
        public static SoundBuffer Load(Stream s)
        {
            BinaryReader br = new BinaryReader(s);
            var magic = new String(br.ReadChars(4));
            if (magic != "RIFF")
                throw new FormatException("Invalid WAV file");

            UInt32 size = br.ReadUInt32();
            var id = new String(br.ReadChars(4));
            if (id != "WAVE")
                throw new FormatException("Invalid WAV file");

            var fmtSig = new String(br.ReadChars(4));
            if (fmtSig != "fmt ")
                throw new FormatException("Format Chunk in WAV file not found");

            var fmtChunckSize = br.ReadInt32();
            var audioFormat = br.ReadInt16();
            var channels = br.ReadInt16();
            var sampleRate = br.ReadInt32();
            var byteRate = br.ReadInt32();
            var blockAlign = br.ReadInt16();
            var bitsPerSample = br.ReadInt16(); ;

            var dataSig = new String(br.ReadChars(4));
            if (dataSig != "data")
            {
                throw new FormatException("Data chunk in WAV file not found");
            }
            
            var dataChunckSize = br.ReadInt32();

            var data = br.ReadBytes(dataChunckSize);
            OpenTK.Audio.OpenAL.ALFormat format;

            if (channels == 1 && bitsPerSample == 8)
                format = OpenTK.Audio.OpenAL.ALFormat.Mono8;
            else if (channels == 1 && bitsPerSample == 16)
                format = OpenTK.Audio.OpenAL.ALFormat.Mono16;
            else if (channels == 2 && bitsPerSample == 8)
                format = OpenTK.Audio.OpenAL.ALFormat.Stereo8;
            else if (channels == 2 && bitsPerSample == 16)
                format = OpenTK.Audio.OpenAL.ALFormat.Stereo16;
            else
                throw new Exception("Unsupported audio format");


            SoundBuffer sb = new SoundBuffer();
            sb.BufferData(data, format, sampleRate);
            return sb;
        }
    }
}
