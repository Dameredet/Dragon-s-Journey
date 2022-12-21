using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace Projekt_KCK
{
    class Muzyka
    {
        private void MusicPlay(string songtitle)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:\\DragonsJourney\\" + songtitle + ".wav";
            player.Play();
        }

        public void CoinMusic()
        {
            MusicPlay("coin");
            System.Threading.Thread.Sleep(200);
        }
        public void IntroMusic()
        {
            MusicPlay("try");
            
        }
        public void WinMusic()
        {
            MusicPlay("try");
            System.Threading.Thread.Sleep(3500);
        }
        public void LoseMusic()
        {
            MusicPlay("lost");
            System.Threading.Thread.Sleep(2000);
        }
        public void ClickMusic()
        {
            MusicPlay("click2");
            System.Threading.Thread.Sleep(20);
        }
        public void HitMusic()
        {
            MusicPlay("hitHurt");
            System.Threading.Thread.Sleep(200);
        }
        public void CrashMusic()
        {
            MusicPlay("explosion");
            System.Threading.Thread.Sleep(200);
        }
        public void FireMusic()
        {
            MusicPlay("fire");
            System.Threading.Thread.Sleep(400);
        }
        public void FlyMusic()
        {
            MusicPlay("fly");
            System.Threading.Thread.Sleep(400);
        }
        public void HeartMusic()
        {
            MusicPlay("coin");
            System.Threading.Thread.Sleep(300);
        }
        public void ErrorMusic()
        {
            MusicPlay("error");
            System.Threading.Thread.Sleep(200);
        }

    }
}
