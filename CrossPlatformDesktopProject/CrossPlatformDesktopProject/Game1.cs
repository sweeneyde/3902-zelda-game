using CrossPlatformDesktopProject.Commands;
using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.Obstacles;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace CrossPlatformDesktopProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public List<IController> controllerList; // could also be defined as List <IController>
        protected Texture2D img;
        private SpriteFont font;
        private Player player;
        private Block block;
        private Statue statue;
        private Bat bat;
        private Gel gel;
        private Goriya goriya;
        private Skeleton skeleton;
        private Boss boss;
        private OldMan oldman;
        private Heart heart;
        private Triforce triforce;
        private IObstacle obstacle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player();

            controllerList = new List<IController>();

            KeyboardController KC = new KeyboardController(this, player);
            controllerList.Add(KC);

            obstacle = new Block();

            bat = new Bat();
            boss = new Boss();
            gel = new Gel();
            goriya = new Goriya();
            oldman = new OldMan();
            skeleton = new Skeleton();

            heart = new Heart();
            triforce = new Triforce();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("NewFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkTextureStorage.Instance.LoadAllResources(Content);
            ObstacleTextureStorage.Instance.LoadAllResources(Content);
            NpcTextureStorage.Instance.LoadAllResources(Content);
            ItemTextureStorage.Instance.LoadAllResources(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();
            bat.Update();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            obstacle.Update();
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Vector2 center = new Vector2(graphics.PreferredBackBufferWidth/2,
graphics.PreferredBackBufferHeight/2);

            player.Draw(spriteBatch);

            obstacle.Draw(spriteBatch);

            bat.Draw(spriteBatch);

            heart.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void quit()
        {
            Exit();
        }
    }
}
 