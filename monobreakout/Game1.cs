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

namespace monobreakout
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

        private static int GameState = 0;

        
        private static Brick[,] bricks;
        private static Texture2D brickTexture;

        const int PADDLE_OFFSET = 0;
        const float PADDLE_SPEED = 7f;
        
        const float SPIN = 2.5f;
        const float BALL_STARTSPEED = 4f;

        const int BRICKS_WIDE =  8;
        const int BRICKS_HIGH =  10;

        const int LIVES = 3;

        private static int BricksLeft = BRICKS_HIGH * BRICKS_WIDE;
        private static int Lives = LIVES;

        Player player;
        Ball ball;

        SpriteFont retroFont;

        KeyboardState OldKeyState;

        public Game1()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here
            
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;
            
            
            _graphics.IsFullScreen = false;
            
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 600;
            
            player = new Player();
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

            retroFont = Content.Load<SpriteFont>("RetroFont");

            Texture2D playertexture = player.GetTexture();
            playertexture = Content.Load<Texture2D>("Paddle");
            player.SetTexture(playertexture);

            Texture2D balltexture = ball.GetTexture();
            balltexture = Content.Load<Texture2D>("Ball");
            ball.SetTexture(balltexture);

            brickTexture = Content.Load<Texture2D>("brick");

            Vector2 playerposition = player.GetPosition();
            playerposition = new Vector2(ScreenWidth/2 - player.Texture.Width, ScreenHeight - player.Texture.Height);
            player.SetPosition(playerposition);
            int playerTextureHeight = player.Texture.Height;
            int playerTextureWidth = player.Texture.Width;

            ball.Launch(BALL_STARTSPEED, playerposition, playerTextureHeight, playerTextureWidth);

            LoadBricks();

            SoundManager.LoadSounds(Content);
            
        }

        public static void LoadBricks()
        {
            bricks = new Brick[BRICKS_WIDE, BRICKS_HIGH];

            for (int y = 0; y < BRICKS_HIGH; y++)
            {
                Color tint = Color.White;

                switch (y)
                {
                    case 0:
                        tint = Color.Blue;
                        break;
                    case 1:
                        tint = Color.Red;
                        break;
                    case 2:
                        tint = Color.Green;
                        break;
                    case 3:
                        tint = Color.Yellow;
                        break;
                    case 4:
                        tint = Color.White;
                        break;
                    case 5:
                        tint = Color.Cyan;
                        break;
                    case 6:
                        tint = Color.AliceBlue;
                        break;
                    case 7:
                        tint = Color.Azure;
                        break;
                    case 8:
                        tint = Color.Coral;
                        break;
                    case 9:
                        tint = Color.DarkSalmon;
                        break;
                    case 10:
                        tint = Color.Gainsboro;
                        break;
                }

                for (int x = 0; x < BRICKS_WIDE; x++)
                {
                    bricks[x, y] = new Brick(
                        brickTexture,
                        new Rectangle(
                            x * brickTexture.Width,
                            y * brickTexture.Height,
                            brickTexture.Width,
                            brickTexture.Height),
                            tint,
                            true);
                }
            }
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
            CheckGameState();
            
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            Vector2 ballVelocity = ball.GetVelocity();

            Vector2 playerVelocity = Input.GetKeyboardInputDirection(PlayerIndex.One) * PADDLE_SPEED;
            
            if (GameState == 1)
            {
                ball.Move(ballVelocity);
                player.Move(playerVelocity);
            }
            
            if (playerVelocity.X != 0) playerVelocity.Normalize();

            if (GameObject.CheckPaddleBallCollision(player, ball))
            {
                Vector2 ballPosition = ball.GetPosition();
                Vector2 ballSpeed = ball.GetVelocity();
                Vector2 playerPosition = player.GetPosition();

                ballPosition.Y = playerPosition.Y - player.Texture.Height;
                ball.SetPosition(ballPosition);
                ball.Velocity += playerVelocity * SPIN;
                ball.SetVelocityY(-Math.Abs(ballSpeed.Y));
                
                SoundEffect soundeffect = SoundManager.GetSoundEffectPB();
                SoundManager.PlaySoundEffect(soundeffect);
            }

            if (ball.Position.Y > ScreenHeight)
            {
                Vector2 playerposition = player.GetPosition();
                int playerTextureHeight = player.Texture.Height;
                int playerTextureWidth = player.Texture.Width;
                ball.Launch(BALL_STARTSPEED, playerposition, playerTextureHeight, playerTextureWidth);
                DeductLife();
            }

            ball.SetCollided(false);

            foreach (Brick brick in bricks)
                brick.CheckCollision(ball);

            if (BricksLeft == 0) GameState = 2;
            
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
            
            if (GameState == 0)
            {
                _spriteBatch.DrawString(retroFont, "MENU", new Vector2(ScreenWidth / 2 - retroFont.MeasureString("MENU").X / 2, ScreenHeight / 4), Color.Cyan);
                _spriteBatch.DrawString(retroFont, "Enter to play", new Vector2(ScreenWidth / 2 - retroFont.MeasureString("Enter to play").X / 2, ScreenHeight / 2), Color.Cyan);
                _spriteBatch.DrawString(retroFont, "Esc to quit", new Vector2(ScreenWidth / 2 - retroFont.MeasureString("Esc to quit").X / 2, ScreenHeight / 2 + retroFont.MeasureString("Esc to quit").Y), Color.Cyan);
            }

            if (GameState == 1)
            {
                player.Draw(_spriteBatch);

                ball.Draw(_spriteBatch);

                foreach (Brick brick in bricks)
                    brick.Draw(_spriteBatch);
            }

            if (GameState == 2)
            {
                _spriteBatch.DrawString(retroFont, "WINRAR!", new Vector2(ScreenWidth / 2 - retroFont.MeasureString("WINRAR!").X / 2, ScreenHeight / 2), Color.Cyan);
            }

            if (GameState == 3)
            {
                _spriteBatch.DrawString(retroFont, "LOSAR!", new Vector2(ScreenWidth / 2 - retroFont.MeasureString("LOSAR!").X / 2, ScreenHeight / 2), Color.Cyan);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public static int GetScreenHeight()
        {
            return ScreenHeight;
        }

        internal static int GetScreenWidth()
        {
            return ScreenWidth;
        }

        private void CheckGameState()
        {
            
            if (GameState == 0)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
                    GameState = 1;
                
                if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
                    GameState = 2;
            }

            if (GameState == 1)
            {
                KeyboardState NewKeyState = Keyboard.GetState();
                if (NewKeyState.IsKeyUp(Keys.Escape) && OldKeyState.IsKeyDown(Keys.Escape))
                    GameState = 0;
                OldKeyState = NewKeyState;
            }

            if (GameState == 2)
            {
                KeyboardState NewKeyState = Keyboard.GetState();
                if (NewKeyState.IsKeyUp(Keys.Enter) && OldKeyState.IsKeyDown(Keys.Enter))
                    GameState = 0;
                OldKeyState = NewKeyState;
            }

            if (GameState == 3)
            {
                KeyboardState NewKeyState = Keyboard.GetState();
                if (NewKeyState.IsKeyUp(Keys.Enter) && OldKeyState.IsKeyDown(Keys.Enter))
                    GameState = 0;
                OldKeyState = NewKeyState;
            }
            
        }
        
        public static void DeductBricksLeft()
        {
            BricksLeft--;
        }


        public static void DeductLife()
        {
            Lives--;
            if (Lives == 0) GameState = 3;
        }
    }
}
