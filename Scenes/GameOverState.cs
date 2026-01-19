using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;

namespace SEGame.Scenes
{
    public class GameOverState : IGameState
    {
        public event IGameState.OnStateEntry OnEntry;
        public event IGameState.OnStateExit OnExit;

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
        }
    }
}
