using Microsoft.Xna.Framework;

namespace SEGame.EC
{
    public interface IScript
    {
        void Initialize(Entity entity);
        void Update(GameTime gameTime);
    }
}
