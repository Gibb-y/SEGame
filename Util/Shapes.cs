using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;

namespace SEGame.Util
{
    public class Shapes : Singleton<Shapes>
    {
        GraphicsDevice _graphicsDevice;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public Texture2D CreateRectangle(int width, int height)
        {
            Color[] data = new Color[width * height];
            Texture2D rectTexture = new Texture2D(_graphicsDevice, width, height);

            // make rectangle transparent
            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.Transparent;
            // draw top line
            for (int x = 0; x < width; ++x)
                data[x] = Color.Red;
            // draw bottom line
            for (int x = data.Length - width - 1; x < data.Length; ++x)
                data[x] = Color.Red;
            // draw both sides
            for (int x = width; x < data.Length; x += width)
            {
                data[x - 1] = Color.Red;
                data[x] = Color.Red;
            }
            // draw the very last pixel
            data[data.Length - 1] = Color.Red;

            rectTexture.SetData(data);
            return rectTexture;
        }
    }
}
