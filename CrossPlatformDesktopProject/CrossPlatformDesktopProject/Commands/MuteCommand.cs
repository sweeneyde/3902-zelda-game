using CrossPlatformDesktopProject.Sound;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class MuteCommand : ICommand
    {
        private Game1 myGame;

        public MuteCommand(Game1 g)
        {
            myGame = g;
        }
        public void Execute()
        {
            if (SoundEffect.MasterVolume == 0.0f)
                SoundEffect.MasterVolume = 1.0f;
            else
                SoundEffect.MasterVolume = 0.0f;
        }
    }
}
