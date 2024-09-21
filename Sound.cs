using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MangMadu
{
    class Sound
    {
        private IWavePlayer player = new WaveOutEvent();
        private AudioFileReader currentFile;
        private string pathToMedia;

        // Constructor that takes the path to the music folder
        public Sound(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        // Method to play sounds
        public void Play(string filePath)
        {
            Stop(); // Stop any currently playing sound
            currentFile = new AudioFileReader(filePath);
            player.Init(currentFile);
            player.Volume = 0.3f; // Adjust volume as needed
            player.Play();
        }

        public void PlayMenuSound()
        {
            Play(@"Music\MenuMusic.mp3");
        }

        public void PlayEasyLevel()
        {
            Play(@"Music\EasyLevelMusic.mp3");
        }

        public void PlayMediumLevel()
        {
            Play(@"Music\MediumLevelMusic.mp3");
        }

        public void PlayHardLevelMusic()
        {
            Play(@"Music\HardLevelMusic.mp3");
        }      

        public void PlayWallTailHitSound()
        {
            Play(@"Music\HitWallTailMusic.mp3");
        }

        public void PlayEatFoodSound()
        {
            Play(@"Music\EatFood.mp3");
        }

        public void Stop()
        {
            if (player.PlaybackState == PlaybackState.Playing)
            {
                player.Stop();
                currentFile?.Dispose();
                currentFile = null;
            }
        }
    }
}
