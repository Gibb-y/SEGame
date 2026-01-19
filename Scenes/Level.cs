using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;

namespace SEGame.Scenes
{
    public class Level
    {
        public IGameState Paused;
        public IGameState Playing;

        private IGameState prevGameState;

        protected EntityManager _entityManager = EntityManager.Instance;
        private DrawManager _drawManager = DrawManager.Instance;

        public Level()
        {
            Paused = new PausedState(this);
            Playing = new PlayingState(this);
            CurrentGameSate = Playing;
        }

        public IGameState CurrentGameSate { get; set; }

        public void Destroy()
        {
            _entityManager.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _drawManager.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (prevGameState != CurrentGameSate || prevGameState == null)
            {
                prevGameState?.OnEnd();
                CurrentGameSate.OnStart();
                prevGameState = CurrentGameSate;
            }
            CurrentGameSate.Update(gameTime);
        }
    }
}