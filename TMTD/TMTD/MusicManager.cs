using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using System.IO;

namespace TMTD
{
    class MusicManager
    {
        private readonly string defaultMusic = "Sound" + Path.DirectorySeparatorChar + "Argus no Senshi Cavern MIX.flac";
        private readonly string introMusic = "Sound" + Path.DirectorySeparatorChar + "mixkit-woodfire-by-the-lake-128.wav";
        private static MusicManager instance;
        public static MusicManager GetInstance() 
        {
            if (instance == null)
            {
                instance = new MusicManager();
            }
            return instance;
        }
        private List<Music> music;
        private int CurrentSong;
        private MusicManager() 
        {
            music = new List<Music>();
            CurrentSong = 0;
            Music DM = new Music(defaultMusic);
            DM.Loop = true;
            Music IM = new Music(introMusic);
            IM.Loop = true;
            music.Add(DM);
            music.Add(IM);
            SetVolume(10);
        }
        private void SetVolume(int newVolume) 
        {
            for (int i = 0; i < music.Count; i++)
            {
                music[i].Volume = newVolume;
            }
        }
        public void Stop()
        {
            music[CurrentSong].Stop();
        }
        public void Pause() 
        {
            music[CurrentSong].Pause();
        }
        public void Play()
        {
            music[CurrentSong].Play();
        }
        public void Skip() 
        {
            music[CurrentSong].Stop();
            CurrentSong++;
            if (CurrentSong > music.Count-1)
            {
                CurrentSong = 0;
            }
            music[CurrentSong].Play();
        }
    }
}
