using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SEGame.Managers;
using static System.Formats.Asn1.AsnWriter;

namespace SEGame.Scenes
{
    public class PausedState : IGameState
    {
        public event IGameState.OnStateEntry OnEntry;
        public event IGameState.OnStateExit OnExit;

        private Level _scene;

        public PausedState(Level scene)
        {
            _scene = scene;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
            //BackgroundManager.Instance.Draw(spriteBatch);
            UserInterfaceManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
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
            UserInterfaceManager.Instance.Update(gameTime);
            if (InputManager.Instance.IsKeyJustDown(Keys.Escape))
                _scene.CurrentGameSate = _scene.Playing;
        }
    }
}
