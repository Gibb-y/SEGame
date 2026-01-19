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
            var platform4 = new Platform(new Point(1000, 300), new Rectangle(400, 600, 16 * 3, 16));
            var goal = new Goal(new Point(980, 170));
            var we = new WalkingEnemy(new Point(400, 600));
            var spikes = new Spikes(new Point(350, 600));
            var spikes2 = new Spikes(new Point(300, 600));
            var spikes3 = new Spikes(new Point(650, 600));
            var spikes4 = new Spikes(new Point(700, 600));

            _entityManager.AddEntity(_player);
            _entityManager.AddEntity(platform);
            _entityManager.AddEntity(platform2);
            _entityManager.AddEntity(platform3);
            _entityManager.AddEntity(platform4);
            _entityManager.AddEntity(goal);
            _entityManager.AddEntity(spikes);
            _entityManager.AddEntity(spikes2);
            _entityManager.AddEntity(spikes3);
            _entityManager.AddEntity(spikes4);
            _entityManager.AddEntity(we);
        }


    }
}
