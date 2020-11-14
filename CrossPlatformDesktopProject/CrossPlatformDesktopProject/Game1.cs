using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.WorldItem;
using CrossPlatformDesktopProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.GameStates;

namespace CrossPlatformDesktopProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public List<IController> controllerList;
        
        public CollisionDetector collisionController;
        private SpriteFont font;
        public Player player;
        private WindowManager windows;

        public IGameState currentState;
        public GamePlayState currentGamePlayState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;
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
            currentState = currentGamePlayState = new GamePlayState(this, Room.FromId(this, "001"));

            windows = new WindowManager(this);

            controllerList = new List<IController>()
            {
                new KeyboardController(this, player),
                new MouseController(this),
            };

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
            GameScreenTextureStorage.Instance.LoadAllResources(this);
            LinkTextureStorage.Instance.LoadAllResources(Content);
            ObstacleTextureStorage.Instance.LoadAllResources(Content);
            NpcTextureStorage.Instance.LoadAllResources(Content);
            ItemTextureStorage.Instance.LoadAllResources(Content);
            RoomTextureStorage.Instance.LoadAllResources(Content);
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
            currentState.Update();
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            windows.HUDStart(spriteBatch);
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.Black });
            spriteBatch.Draw(texture, new Rectangle(0, 0, 255, (175 / 2)), Color.Black);
            spriteBatch.End();
            
            windows.GameStart(spriteBatch);
            currentState.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void GoToRoom(Room room2)
        {
            GameScreenTextureStorage.Instance.SaveScreen(spriteBatch);
            Room room1 = currentGamePlayState.CurrentRoom;
            currentGamePlayState = new GamePlayState(this, room2);
            currentState = new RoomTransitionState(this, room1, room2);
        }

        public void quit()
        {
            Exit();
        }

        public void reset()
        {
            this.Initialize();
        }
    }
}
 