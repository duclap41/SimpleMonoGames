using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootingGallery
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _targetSprite;
        private Texture2D _crosshairSprite;
        private Texture2D _backgroundSprite;
        private SpriteFont _gameFont;

        private Vector2 _targetPosition = new Vector2(300, 300);
        private const int _targetRadius = 45;

        private MouseState _mouseState;
        private bool _mouseReleased = true;
        private const int _crosshairRadius = 25;

        private int _score = 0;
        private double _timer = 10; // double type keep value more precise than float (floating point issue)

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _targetSprite = Content.Load<Texture2D>("target");
            _crosshairSprite = Content.Load<Texture2D>("crosshairs");
            _backgroundSprite = Content.Load<Texture2D>("sky");
            _gameFont = Content.Load<SpriteFont>("galleryFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // Every code in here, will be executed in every single frame (60 fps)

            if (_timer > 0)
            {
                _timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (_timer <= 0) // Use else statement will be miss a frame
            {
                _timer = 0;
            }

            _mouseState = Mouse.GetState();

            if (_mouseState.LeftButton == ButtonState.Pressed && _mouseReleased == true)
            {
                float mouseTargetDist = Vector2.Distance(_targetPosition, _mouseState.Position.ToVector2());
                if (mouseTargetDist <= _targetRadius && _timer > 0)
                {
                    _score++;

                    Random rand = new Random();

                    _targetPosition.X = rand.Next(0 + _targetRadius, _graphics.PreferredBackBufferWidth - _targetRadius);
                    _targetPosition.Y = rand.Next(0 + _targetRadius, _graphics.PreferredBackBufferHeight - _targetRadius);
                }
                _mouseReleased = false;
            }

            if (_mouseState.LeftButton == ButtonState.Released)
            {
                _mouseReleased = true;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_backgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(_gameFont, "Score: " + _score.ToString(), new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(_gameFont, "Time: " + Math.Ceiling(_timer).ToString(), new Vector2(0, 40), Color.White);
            
            if (_timer > 0)
            {
                _spriteBatch.Draw(_targetSprite, new Vector2(_targetPosition.X - _targetRadius, _targetPosition.Y - _targetRadius), Color.White);
            }

            _spriteBatch.Draw(_crosshairSprite, new Vector2(_mouseState.X - _crosshairRadius, _mouseState.Y - _crosshairRadius), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
