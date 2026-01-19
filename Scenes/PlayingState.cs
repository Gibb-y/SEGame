using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SEGame.Managers;

namespace SEGame.Scenes
{
    public class PlayingState : IGameState
    {
        public event IGameState.OnStateEntry OnEntry;
        public event IGameState.OnStateExit OnExit;

        private EntityManager _entityManager = EntityManager.Instance;
        private DrawManager _drawManager = DrawManager.Instance;
        private Level _scene;

        public PlayingState(Level scene)
        {
            _scene = scene;
        }

        public void OnEnd()
        {
            OnExit?.Invoke();
        }

        public void OnStart()
        {
            OnEntry?.Invoke();
        }

        public void Update(GameTime gameTime)
        {
            _entityManager.Update(gameTime);

            if (InputManager.Instance.IsKeyJustDown(Keys.Escape))
                _scene.CurrentGameSate = _scene.Paused;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _drawManager.Draw(spriteBatch);
        }
    }
}
