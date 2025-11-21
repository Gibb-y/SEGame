using Microsoft.Xna.Framework;

namespace SEGame.EC
{
    public interface IComponent
    {
        void Initialize(Entity entity);

        void Update(Entity entity, GameTime gameTime);
    }
}
