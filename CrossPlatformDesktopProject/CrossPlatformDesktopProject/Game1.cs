using CrossPlatformDesktopProject.Commands;
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
        public INpc sprite;
        protected Texture2D img;
        private SpriteFont font;

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
            controllerList = new List<IController>();

            ///This could be moved to some kind of mapping function
            KeyboardController KC = new KeyboardController(this);
            KC.addCommand(Keys.D0, new Quit(this));
            KC.addCommand(Keys.D1, new SetStanding(this));
            KC.addCommand(Keys.D2, new SetMoving(this));
            KC.addCommand(Keys.D3, new SetStandingAnimated(this));
            KC.addCommand(Keys.D4, new SetMovingAnimated(this));
            
            controllerList.Add(KC);
            this.IsMouseVisible = true;

            MouseController MC = new MouseController(this);
            MC.addRightCommand(new Rectangle(0,0, graphics.PreferredBackBufferWidth,
graphics.PreferredBackBufferHeight), new Quit(this));
            MC.addLeftCommand(new Rectangle(0, 0, graphics.PreferredBackBufferWidth/2,
graphics.PreferredBackBufferHeight/2), new SetStanding(this));
            MC.addLeftCommand(new Rectangle(graphics.PreferredBackBufferWidth/2, 0, graphics.PreferredBackBufferWidth,
graphics.PreferredBackBufferHeight/2), new SetMoving(this));
            MC.addLeftCommand(new Rectangle(0, graphics.PreferredBackBufferHeight / 2, graphics.PreferredBackBufferWidth/2,
graphics.PreferredBackBufferHeight), new SetStandingAnimated(this));
            MC.addLeftCommand(new Rectangle(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2, graphics.PreferredBackBufferWidth,
graphics.PreferredBackBufferHeight), new SetMovingAnimated(this));

            controllerList.Add(MC);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            img = Content.Load<Texture2D>("yoshi");
            sprite = new StandingSprite();
            font = Content.Load<SpriteFont>("NewFont");
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

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            sprite.Update();

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

            spriteBatch.DrawString(this.font, "Credits\n Program Made By : James Cross \n Sprites From :https://www.mariouniverse.com/wp-content/img/sprites/snes/yi/yoshi.gif", new Vector2(graphics.PreferredBackBufferWidth / 4, 3 * graphics.PreferredBackBufferHeight / 4), Color.Black);
            sprite.Draw(img, spriteBatch, center);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void quit()
        {
            Exit();
        }
    }
}
 