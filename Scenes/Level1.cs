using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Entities;
using SEGame.Managers;
using System;

namespace SEGame.Scenes
{
    public class Level1 : IScene
    {
        public string Name => "level_1";

        private EntityManager _entityManager;
        private DrawManager _drawManager;

        public Level1()
        {
            _entityManager = EntityManager.Instance;
            _drawManager = DrawManager.Instance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _drawManager.Draw(spriteBatch);
        }

        public void Initialize(GameTime gameTime)
        {
            Player _player = new();
            var platform = new Platform(new Point(400, 600), new Rectangle(400, 600, 16 * 3, 16));
            var platform2 = new Platform(new Point(600, 500), new Rectangle(400, 600, 16 * 8, 16));
            var platform3 = new Platform(new Point(900, 400), new Rectangle(400, 600, 16 * 3, 16));
            var platform4 = new Platform(new Point(750, 250), new Rectangle(400, 600, 16 * 3, 16));
            Enemy enemy = new Enemy(new Vector2(700, 330));

            _entityManager.AddEntity(_player);
            _entityManager.AddEntity(platform);
            _entityManager.AddEntity(platform2);
            _entityManager.AddEntity(platform3);
            _entityManager.AddEntity(enemy);
        }

        public void Update(GameTime gameTime)
        {
            _entityManager.Update(gameTime);
        }

        public void Destroy()
        {
            _entityManager.Clear();
        }
    }
}
