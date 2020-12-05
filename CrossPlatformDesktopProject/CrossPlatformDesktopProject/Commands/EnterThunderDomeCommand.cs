using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Commands
{
    class EnterThunderDome : ICommand
    { 
        private Game1 myGame;
        public EnterThunderDome(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            SoundStorage.music_instance.Stop();
            SoundStorage.music_instance = SoundStorage.Instance.getThunderSound().CreateInstance();
            SoundStorage.music_instance.IsLooped = true;
            SoundStorage.music_instance.Play();
            myGame.currentGamePlayState = new GamePlayState(myGame, Room.FromId(myGame, "018"));
            myGame.currentState = new ThunderDomeState(myGame, Room.FromId(myGame, "018"));
        }
    }
}
