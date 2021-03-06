﻿using System;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Windows.Media;

namespace evoQuiz.ViewModel
{
    class SoundsViewModel
    {
        static MediaPlayer soundPlayer = new MediaPlayer();
        static SoundPlayer menuSoundPlayer = new SoundPlayer();
        static string path = Environment.CurrentDirectory;

        //The balance between the left and right speaker volumes.
        //The ratio of volume across the left and right speakers in a range between -1
        //and 1. The default is 0.
        private static int balance = 0;

        //The media's volume represented on a linear scale between 0 and 1. The default is 0.5.
        private static int volume = 1;

        static SoundsViewModel()
        {
            path = new DirectoryInfo(path).FullName.ToString() + "\\Sounds\\";
        }

        public static void StartMenuMusic()
        {
            if (!global::evoQuiz.Properties.Settings.Default.MenuSoundPlayerActive)
            {
                menuSoundPlayer.SoundLocation = path + "MenuSong.wav";
                menuSoundPlayer.PlayLooping();
                global::evoQuiz.Properties.Settings.Default.MenuSoundPlayerActive = true;
            }
        }

        public static void StopMenuMusic()
        {
            menuSoundPlayer.Stop();
            global::evoQuiz.Properties.Settings.Default.MenuSoundPlayerActive = false;
        }

        public static void InGameMusic()
        {
            Play(path + "GameSong.wav");
            global::evoQuiz.Properties.Settings.Default.RunningGameSoundPlayerActive = true;
        }

        public static void StopGameMusic()
        {
            soundPlayer.Stop();
            global::evoQuiz.Properties.Settings.Default.RunningGameSoundPlayerActive = false;
        }

        static void Play(string audioPath)
        {
            soundPlayer.Open(new System.Uri(audioPath));
            soundPlayer.Balance = balance;
            soundPlayer.Volume = volume;
            soundPlayer.Play();
        }
    }
}
