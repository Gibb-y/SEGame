using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Entities;
using SEGame.Managers;
using System;

namespace SEGame.Scenes
{
    public class Level1 : Level, IScene
    {
        public string Name => "level_1";

        public Level1() : base()
        {
        }

        public void Initialize(GameTime gameTime)
        {
            Player _player = new();
            var platform = new Platform(new Point(400, 600), new Rectangle(400, 600, 16 * 3, 16));
            var platform2 = new Platform(new Point(600, 500), new Rectangle(400, 600, 16 * 8, 16));
            var platform3 = new Platform(new Point(900, 400), new Rectangle(400, 600, 16 * 3, 16));
            var platform4 = new Platform(new Point(750, 250), new Rectangle(400, 600, 16 * 3, 16));
            var goal = new Goal(new Point(730, 120));
            Enemy enemy = new Enemy(new Vector2(700, 330));

            _entityManager.AddEntity(_player);
            _entityManager.AddEntity(platform);
            _entityManager.AddEntity(platform2);
            _entityManager.AddEntity(platform3);
            _entityManager.AddEntity(enemy);
        }
    }
}
