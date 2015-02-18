#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace monopong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private static int ScreenWidth;
        private static int ScreenHeight;

        const int PADDLE_OFFSET = 70;
        const float BALL_START_SPEED = 4f;
        const float KEYBOARD_PADDLE_SPEED = 5f;
        const float SPIN = 2.5f;

        Player player1;
        Player player2;
        Ball ball;

        SpriteFont retroFont;
        Texture2D middleTexture;

        public Game1()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            player1 = new Player();
            player2 = new Player();

            ball = new Ball();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player1.Texture = Content.Load<Texture2D>("Paddle");
            player2.Texture = Content.Load<Texture2D>("Paddle");

            player1.Position = new Vector2(PADDLE_OFFSET, ScreenHeight / 2 - player1.Texture.Height / 2);
            player2.Position = new Vector2(ScreenWidth - player2.Texture.Width - PADDLE_OFFSET, ScreenHeight / 2 - player2.Texture.Height / 2);

            ball.Texture = Content.Load<Texture2D>("Ball");
            ball.Launch(BALL_START_SPEED);

            retroFont = Content.Load<SpriteFont>("RetroFont");

            middleTexture = Content.Load<Texture2D>("Middle");

            SoundManager.LoadSounds(Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            ball.Move(ball.Velocity);

            Vector2 player1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One) * KEYBOARD_PADDLE_SPEED;
            Vector2 player2Velocity = Input.GetKeyboardInputDirection(PlayerIndex.Two) * KEYBOARD_PADDLE_SPEED;

            player1.Move(player1Velocity);
            player2.Move(player2Velocity);

            Vector2 player1TouchVelocity, player2TouchVelocity;
            Input.ProcessTouchInput(out player1TouchVelocity, out player2TouchVelocity);
            player1.Move(player1TouchVelocity);
            player2.Move(player2TouchVelocity);

            if (player1TouchVelocity.Y > 0f) player1Velocity = player1TouchVelocity;
            if (player2TouchVelocity.Y > 0f) player2Velocity = player2TouchVelocity;

            if (player1Velocity.Y != 0) player1Velocity.Normalize();
            if (player2Velocity.Y != 0) player2Velocity.Normalize();

            if (GameObject.CheckPaddleBallCollision(player1, ball))
            {
                ball.Velocity.X = Math.Abs(ball.Velocity.X);
                ball.Velocity += player1Velocity * SPIN;
                SoundEffect soundeffect = SoundManager.GetSoundEffectPB();
                SoundManager.PlaySoundEffect(soundeffect);
            }
            if (GameObject.CheckPaddleBallCollision(player2, ball))
            {
                ball.Velocity.X = -Math.Abs(ball.Velocity.X);
                ball.Velocity += player2Velocity * SPIN;
                SoundEffect soundeffect = SoundManager.GetSoundEffectPB();
                SoundManager.PlaySoundEffect(soundeffect);
            }

            if (ball.Position.X + ball.Texture.Width < 0)
            {
                ball.Launch(BALL_START_SPEED);
                player2.AddScore();
            }

            if (ball.Position.X > ScreenWidth)
            {
                ball.Launch(BALL_START_SPEED);
                player1.AddScore();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(middleTexture, new Rectangle(ScreenWidth / 2 - middleTexture.Width / 2, 0, middleTexture.Width, ScreenHeight), null, Color.White);

            int player1score = player1.GetScore();
            int player2score = player2.GetScore();

            _spriteBatch.DrawString(retroFont, player1score + "        " + player2score, new Vector2(ScreenWidth / 2 - retroFont.MeasureString(player1score + "        " + player2score).X / 2, 0), Color.Cyan); player1.Draw(_spriteBatch);
            player1.Draw(_spriteBatch);
            player2.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public static int GetScreenWidth()
        {
            return ScreenWidth;
        }

        public static int GetScreenHeight()
        {
            return ScreenHeight;
        }
    }
}
