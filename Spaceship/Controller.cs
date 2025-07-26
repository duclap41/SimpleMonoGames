using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Spaceship
{
    internal class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        int _asteroidSpeed = 180;
        double _timer = 2;
        double _spawnTime = 2; // 2 is inital spawn time
        double _difficult = 0.1;

        int _windowWidth;
        int _windowHeight;

        public Controller(int windowWidth, int windowHeight)
        {
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
        }

        public void controllerUpdate(GameTime gameTime)
        {
            _timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer <= 0)
            {
                asteroids.Add(new Asteroid(_asteroidSpeed, _windowWidth, _windowHeight));
                _timer = _spawnTime;

                if (_spawnTime > 0.3)
                {
                    _spawnTime -= _difficult; // asteroid will appear faster
                }
            }
        }
    }
}
