using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Entities;
using SEGame.Managers;
using System;

namespace SEGame.Scenes
{
    public class Level1 : IScene
    {
        public string Name => "Level 1";

        private EntityManager _entityManager;

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Initialize(GameTime gameTime)
        {
            _entityManager = EntityManager.Instance;

            Player _player = new();
            var platform = new Platform(new Point(400, 600), new Rectangle(400, 600, 16 * 3, 16));
            var platform2 = new Platform(new Point(600, 400), new Rectangle(400, 600, 16 * 3, 16));

            _entityManager.AddEntity(_player);
            _entityManager.AddEntity(platform);
            _entityManager.AddEntity(platform2);
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
