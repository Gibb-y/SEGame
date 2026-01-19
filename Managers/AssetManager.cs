using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SEGame.Managers
{
    public class AssetManager : Singleton<AssetManager>
    {
        private readonly Dictionary<string, Texture2D> textures;
        private readonly Dictionary<string, Util.SpriteFont> fonts;

        public AssetManager() { textures = new(); fonts = new(); }

        public bool AddTexture2D(string name, Texture2D texture)
        {
            return textures.TryAdd(name, texture);
        }

        public bool AddSpriteFont(string name, Util.SpriteFont font)
        {
            return fonts.TryAdd(name, font);
        }

        public Texture2D GetTexture2D(string name) { return textures[name]; }

        public Util.SpriteFont GetFont(string name) { return fonts[name]; }
    }
}
