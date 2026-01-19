using Microsoft.Xna.Framework;
namespace SEGame.Scenes
{
    public interface IGameState : EC.IDrawable
    {
        delegate void OnStateEntry();
        event OnStateEntry OnEntry;

        delegate void OnStateExit();
        event OnStateExit OnExit;

        void OnStart();
        void OnEnd();
        void Update(GameTime gameTime);
    }
}
