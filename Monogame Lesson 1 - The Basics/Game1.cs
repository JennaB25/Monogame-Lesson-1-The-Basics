using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;

namespace Monogame_Lesson_1___The_Basics
{
    public class Game1 : Game
    {
        Random generator = new Random();
        int randomX;
        int x = 0;
        int y = 0;
        int x_ = 0;
        int y_ = 0;
        Texture2D dinoTexture;
        Texture2D buildingTexture;
        Texture2D streetTexture;
        Texture2D fireTexture;
        Texture2D moonTexture;
        Texture2D nightskyTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500; 
            _graphics.ApplyChanges(); 
            this.Window.Title = "Lesson 1: Monogame Project";
            randomX = generator.Next(50, 650);           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            dinoTexture = Content.Load<Texture2D>("dino");
            buildingTexture = Content.Load<Texture2D>("building");
            streetTexture = Content.Load<Texture2D>("street");
            fireTexture = Content.Load<Texture2D>("fire");
            moonTexture = Content.Load<Texture2D>("moon");
            nightskyTexture = Content.Load<Texture2D>("nightsky");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);
            
            _spriteBatch.Begin();

            _spriteBatch.Draw(nightskyTexture, new Vector2(-60, -120), Color.White);           

            x = -50;
            y = 110;
            for (int i = 0; i < 10; i++)             
            {
                _spriteBatch.Draw(buildingTexture, new Vector2(x, y), Color.White);
                x += 100;                
            }

            _spriteBatch.Draw(streetTexture, new Vector2(0, -55), Color.White);
            _spriteBatch.Draw(streetTexture, new Vector2(610, -55), Color.White);

            x_ = 0;
            y_ = 290;
            for (int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(fireTexture, new Vector2(x_, y_), Color.White);
                x_ += 200;
            }
            _spriteBatch.Draw(dinoTexture, new Vector2(100, 170), Color.White);

            _spriteBatch.Draw(moonTexture, new Vector2(randomX, 0), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}