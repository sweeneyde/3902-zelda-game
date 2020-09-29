using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Link
{
    class ObstacleTextureStorage : ISpriteFactory
    {
        private static ObstacleTextureStorage instance = null;
        
        public static ObstacleTextureStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObstacleTextureStorage();
                }
                return instance;
            }
        }


        private static Texture2D obstacleTexture = null;

        private ObstacleTextureStorage()
        {
        }

        public void LoadAllResources(ContentManager content)
        {
            obstacleTexture = content.Load<Texture2D>("Dungeon Tileset");
        }


        public Texture2D getObstacleSpriteSheet()
        {
            return obstacleTexture;
        }

        public static Rectangle OBSTACLE_BLOCK = new Rectangle(1001, 11, 16, 16);
        public static Rectangle OBSTACLE_STATUE = new Rectangle(1018, 11, 16, 16);

    }
}
