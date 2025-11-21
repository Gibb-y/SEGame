using Microsoft.Xna.Framework.Graphics;

namespace SEGame.EC
{
    public interface IDrawableComponent : IComponent
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
