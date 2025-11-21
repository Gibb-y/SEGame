using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SEGame.Managers
{
    public class AssetManager : Singleton<AssetManager>
    {
        private readonly Dictionary<string, Texture2D> textures;

        public AssetManager() { textures = new(); }

        public bool AddTexture2D(string name, Texture2D texture)
        {
            return textures.TryAdd(name, texture);
        }

        public Texture2D GetTexture2D(string name) { return textures[name]; }
    }
}
