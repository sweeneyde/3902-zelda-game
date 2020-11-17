using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Link;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionHandler
{

    public class CollisionManager
    {
        private CollisionDetector detector;
        private Game1 myGame;
        public CollisionManager(Game1 game){
            myGame = game;
        }

        public void Update()
        {
            detector.Update();
        }

        public void createDetector(Room room, Player player)
        {
            detector = new CollisionDetector(room, player, myGame);
        }
        public void removeCollider(ICollider collider)
        {
            detector.RemoveColliders(collider);
        }
    }
}
