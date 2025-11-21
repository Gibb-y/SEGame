using Microsoft.Xna.Framework.Graphics;
using SEGame.EC;
using System.Collections.Generic;

namespace SEGame.Managers
{
    public class DrawManager : Singleton<DrawManager>
    {
        private List<IDrawableComponent> _drawables;

        public DrawManager()
        {
            _drawables = new();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (var drawable in _drawables)
            {
                drawable.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public void AddDrawable(IDrawableComponent component)
        {
            _drawables.Add(component);
        }

        public void RemoveDrawable(IDrawableComponent component)
        {
            _drawables.Remove(component);
        }
    }
}
