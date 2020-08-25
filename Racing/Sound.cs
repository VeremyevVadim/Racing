using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Racing
{
    static class Sound
    {
        static SoundPlayer sound_menu_button = new SoundPlayer(Properties.Resources.sound_menu_button);
        static SoundPlayer sound_menu_move = new SoundPlayer(Properties.Resources.sound_menu_move);
        static SoundPlayer sound_game_crash = new SoundPlayer(Properties.Resources.sound_game_crash);
        static SoundPlayer sound_game_move = new SoundPlayer(Properties.Resources.sound_game_move);
        static SoundPlayer sound_game_count = new SoundPlayer(Properties.Resources.sound_game_count);
        static SoundPlayer sound_game_start = new SoundPlayer(Properties.Resources.sound_game_start);
        static bool sound_enabled = true;

        public static void sound_on()
        {
            sound_enabled = true;
        }

        public static void sound_off()
        {
            sound_enabled = false;
        }


        public static void play_menu_button()
        {
            if(sound_enabled)
                sound_menu_button.Play();       
        }

        public static void play_menu_move()
        {
            if (sound_enabled)
                sound_menu_move.Play();
        }

        public static void play_game_crash()
        {
            if (sound_enabled)
                sound_game_crash.Play();
        }

        public static void play_game_move()
        {
            if (sound_enabled)
                sound_game_move.Play();
        }

        public static void play_game_count()
        {
            if (sound_enabled)
                sound_game_count.Play();
        }

        public static void play_game_start()
        {
            if (sound_enabled)
                sound_game_start.Play();
        }
    }
}
