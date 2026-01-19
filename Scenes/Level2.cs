using Microsoft.Xna.Framework;
using SEGame.Entities;

namespace SEGame.Scenes
{
    public class Level2 : Level, IScene
    {
        public string Name => "level_2";

        public void Initialize(GameTime gameTime)
        {
            Player _player = new();
            var platform = new Platform(new Point(800, 600), new Rectangle(400, 600, 16 * 3, 16));
            var platform2 = new Platform(new Point(700, 500), new Rectangle(400, 600, 16 * 3, 16));
            var platform3 = new Platform(new Point(800, 400), new Rectangle(400, 600, 16 * 3, 16));
            var we = new WalkingEnemy(new Point(400, 600));

            _entityManager.AddEntity(_player);
            _entityManager.AddEntity(platform);
            _entityManager.AddEntity(platform2);
            _entityManager.AddEntity(platform3);
            _entityManager.AddEntity(we);
        }


    }
}
