using CrossPlatformDesktopProject.Link;
using CrossPlatformDesktopProject.NPC;
using CrossPlatformDesktopProject.WorldItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CrossPlatformDesktopProject.CollisionHandler;
using CrossPlatformDesktopProject.GameStates;
using CrossPlatformDesktopProject.Levels;
using CrossPlatformDesktopProject.Sound;
using Microsoft.Xna.Framework.Audio;

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
        
        private SpriteFont font;
        public Player player;
        private WindowManager windows;
        public int pauseCooldown;

        public IGameState currentState;
        public GamePlayState currentGamePlayState;
        public HUDWindow currentHUD;
        public CollisionManager collisionManager;

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
            collisionManager = new CollisionManager(this);
            currentHUD = new HUDWindow(player, this);
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
            InventoryTextureStorage.Instance.LoadAllResources(Content);
            HUDTextureStorage.Instance.LoadAllResources(Content);
            SoundStorage.Instance.LoadAllResources(Content);

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

            if (player.link_health == 0)
            {
                Die();
                player.link_health = -1;
            }
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            windows.GameStart(spriteBatch);
            currentState.Draw(spriteBatch);
            spriteBatch.End();

            windows.HUDStart(spriteBatch);
            currentHUD.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void GoToRoom(Room room2, CollisionSides side)
        {
            GameScreenTextureStorage.Instance.SaveScreen(spriteBatch);
            Room room1 = currentGamePlayState.CurrentRoom;
            currentGamePlayState = new GamePlayState(this, room2);
            currentState = new RoomTransitionState(this, room1, room2, side);
        }

        public void quit()
        {
            Exit();
        }

        public void Die()
        {
            player.currentState = new Death(player, this, font);
            SoundStorage.music_instance.Stop();
        }


        public void Pause()
        {
            if (pauseCooldown == 0)
            {
                pauseCooldown = 10;
                this.currentState = new PauseState(this, font);
            }


        }

        public void reset()
        {
            this.Initialize();
        }

        public void mute()
        {
            if (SoundEffect.MasterVolume == 0.0f)
                SoundEffect.MasterVolume = 1.0f;
            else
                SoundEffect.MasterVolume = 0.0f;
        }
    }
}
 