using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    internal class Ship
    {
        public Vector2 position = new Vector2(100, 100);
        public const int width = 68;
        public const int height = 100;
        const int speed = 3 * 60;

        public void ShipUpdate(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            // Use if statement allow to move diagonally.
            if (keyboardState.IsKeyDown(Keys.D))
            {
                position.X += speed * deltaTime; // this prevent the different speed from fps fluctuate (60 is faster 30)
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                position.X -= speed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                position.Y += speed * deltaTime;
            }

        }
    }
}
