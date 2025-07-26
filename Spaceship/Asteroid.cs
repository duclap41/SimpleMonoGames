using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    internal class Asteroid
    {
        public Vector2 position;
        public const int radius = 118 / 2;
        int speed;
        Random rand = new Random();

        public Asteroid(int newSpeed, int windowWidth, int windowHeight)
        {
            speed = newSpeed;
            position = new Vector2(windowWidth + radius, rand.Next(0, windowHeight + 1)); // random from right edge
        }

        public void asteroidUpdate(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.X -= speed * deltaTime;
        }
    }
}
