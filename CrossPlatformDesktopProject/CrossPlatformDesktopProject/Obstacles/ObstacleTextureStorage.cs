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
        public static Rectangle OBSTACLE_STATUE2 = new Rectangle(1035, 11, 16, 16);
        public static Rectangle OBSTACLE_BASIC = new Rectangle(984, 11, 16, 16);
        public static Rectangle OBSTACLE_SAND = new Rectangle(1001, 28, 16, 16);
        public static Rectangle OBSTACLE_STAIRS = new Rectangle(1035, 28, 16, 16);
        public static Rectangle OBSTACLE_TRANSPARENT = new Rectangle(1054, 28, 16, 16);

    }
}
