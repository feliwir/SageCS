using OpenTK;
using OpenTK.Input;
using SageCS.Core.Graphics;
using System;
using System.IO;

using SageCS.Audio;
using SageCS.Core.Loaders;
using System.Diagnostics;
using SageCS.Graphics;
using SageCS.INI;
using SageCS.Source.Graphics;

namespace SageCS.Core
{
    class Engine : GameWindow
    {
        ~Engine()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.WindowBorder = WindowBorder.Hidden;
            base.OnLoad(e);
            GraphicsSystem.Init();

            Title = "SageCS - BFME II";
       
            try
            {
                Texture t = new Texture();
                t.Load(File.Open("GermanSplash.jpg", FileMode.Open)); 
                Sprite sp = new Sprite(Vector2.Zero, new Vector2(800,600),t );
                sp.Draw(GraphicsSystem.GetScreen());

            }
            catch
            {
                Texture t = new Texture();
                t.Load(File.Open("EnglishSplash.jpg", FileMode.Open));
            }
            
            base.SwapBuffers();

            FileSystem.Init();
            AudioSystem.Init();

            Stopwatch stopwatch = Stopwatch.StartNew();

            Texture tex = new Texture();
            var texS = FileSystem.Open("art\\compiledtextures\\al\\all_faction_banners.dds");
            tex.Load(texS);
            //W3DLoader.Load(FileSystem.Open("art\\w3d\\gu\\gumaarms_skn.w3d"));
            //W3DLoader.Load(FileSystem.Open("art\\w3d\\gu\\gumaarms_runa.w3d"));
            //W3DLoader.Load(FileSystem.Open("art\\w3d\\gu\\gumaarms_skl.w3d"));

            INIManager.ParseINIs();
            var buffer = WavLoader.Load(FileSystem.Open("data\\audio\\speech\\ucheer.wav"));
            Sound testSound = new Sound(buffer);
            testSound.Play();
            stopwatch.Stop();
            Console.WriteLine("total loading time: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            base.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (Keyboard[Key.Escape])
            {
                Exit();
            }

        }
    }
}
