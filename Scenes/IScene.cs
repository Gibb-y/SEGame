using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SEGame.Scenes
{
    public interface IScene
    {
        string Name { get; }
        void Initialize(GameTime gameTime);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Destroy();
    }
}
