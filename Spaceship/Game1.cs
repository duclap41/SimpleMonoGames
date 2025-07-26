using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // csharp use private for default
        Texture2D _shipSprite;
        Texture2D _asteroidSprite;
        Texture2D _spaceSprite;
        SpriteFont _gameFont;
        SpriteFont _timerFont;

        Ship _player = new Ship();
        Controller _gameControlelr;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _shipSprite = Content.Load<Texture2D>("ship");
            _asteroidSprite = Content.Load<Texture2D>("asteroid");
            _spaceSprite = Content.Load<Texture2D>("space");
            _gameFont = Content.Load<SpriteFont>("spaceFont");
            _timerFont = Content.Load<SpriteFont>("timerFont");

            _gameControlelr = new Controller(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.ShipUpdate(gameTime);
            _gameControlelr.controllerUpdate(gameTime);

            // Update each asteroid position
            for (int i = 0; i < _gameControlelr.asteroids.Count; i++)
            {
                _gameControlelr.asteroids[i].asteroidUpdate(gameTime);

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(_shipSprite, new Vector2(_player.position.X - Ship.width / 2, _player.position.Y - Ship.height / 2), Color.White);

            for (int i = 0; i < _gameControlelr.asteroids.Count; i++)
            {
                _spriteBatch.Draw(_asteroidSprite, 
                    new Vector2(_gameControlelr.asteroids[i].position.X - Asteroid.radius, _gameControlelr.asteroids[i].position.Y), 
                    Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
