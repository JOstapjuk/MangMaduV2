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

        public Sound() { }

        public void Play(string filePath)
        {
            Stop();
            // Looge määratud failiteega uus AudioFileReaderi eksemplar
            currentFile = new AudioFileReader(filePath);
            // Audiomängija initsialiseerimine helifailiga
            player.Init(currentFile);
            // Määra helimängija helitugevus (vahemik on tüüpiliselt 0,0 kuni 1,0)
            player.Volume = 0.3f;
            // Alustage helifaili mängimist
            player.Play();
        }

        // Tegi seda AI abiga
        public void PlayLoop(string filePath)
        {
            // Kontrollige, kas heli ei mängi praegu enne uue taasesituse alustamist
            if (player.PlaybackState != PlaybackState.Playing)
            {
                currentFile = new AudioFileReader(filePath);
                player.Init(currentFile);
                player.Volume = 0.3f;

                player.Play();
                // Tellige PlaybackStopped üritus, et heli loosida
                player.PlaybackStopped += (s, e) => // s - sender / e - EventArgs 
                {
                    // Kontrollige, kas praegune fail ei ole null enne selle positsiooni lähtestamist
                    if (currentFile != null)
                    {
                        // Loosimiseks lähtestage helifaili asend algusesse
                        currentFile.Position = 0;
                        // // Esita helifail uuesti
                        player.Play();
                    }
                };
            }
        }

        // // PlayLoop meetod menüümuusika failiteega
        public void PlayMenuSound()
        {
            PlayLoop(@"C:\Users\opilane\Source\Repos\MangMaduV2\Music\MenuMusic.mp3");
        }

        public void PlayEasyLevel()
        {
            PlayLoop(@"C:\Users\opilane\Source\Repos\MangMaduV2\Music\EasyLevelMusic.mp3");
        }

        public void PlayMediumLevel()
        {
            PlayLoop(@"C:\Users\opilane\Source\Repos\MangMaduV2\Music\MediumLevelMusic.mp3");
        }

        public void PlayHardLevel()
        {
            PlayLoop(@"C:\Users\opilane\Source\Repos\MangMaduV2\Music\HardLevelMusic.mp3");
        }      

        public void PlayWallTailHitSound()
        {
            Play(@"C:\Users\opilane\Source\Repos\MangMaduV2\Music\HitWallTailMusic.mp3");
        }

        public void PlayEatFoodSound()
        {
            Play(@"C:\Users\opilane\Source\Repos\MangMaduV2\Music\EatFoodMusic.mp3");
        }

        public void Stop()
        {
            // Kontrolli, kas muusika praegu mängib
            if (player.PlaybackState == PlaybackState.Playing)
            {
                // Lõpetage heli taasesitus
                player.Stop();
                // Käimasoleva helifaili visandamine ressursside vabastamiseks
                currentFile?.Dispose();
                // Määrake praegune fail nulliks, et näidata, et heli ei laeta
                currentFile = null;
            }
        }
    }
}
