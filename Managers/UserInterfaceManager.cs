using SEGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SEGame.Managers
{
    internal class UserInterfaceManager : Singleton<UserInterfaceManager>
    {
        public List<UserInterfaceLayer> Elements { get; private set; }
        public UserInterfaceLayer CurrentLayer { get; private set; }

        public UserInterfaceManager() { Elements = new List<UserInterfaceLayer>(); }


        public void AddLayer(UserInterfaceLayer layer)
        {
            Elements.Add(layer);
        }

        public void AddItemToCurrentLayer(IUserInterface item)
        {
            CurrentLayer.Elements.Add(item);
        }

        public bool AddItemTo(IUserInterface item, string name)
        {
            UserInterfaceLayer target = null;
            foreach (UserInterfaceLayer layer in Elements)
                if (layer.Name == name)
                    target = layer;
            target?.AddItem(item);
            return item != null;
        }

        public UserInterfaceLayer GetLayer(string name)
        {
            return Elements.Find(e => e.Name == name);
        } 

        public bool SetLayerAsActive(string name)
        {
            foreach (UserInterfaceLayer layer in Elements)
                if (layer.Name == name)
                {
                    CurrentLayer = layer;
                    return true;
                }
            return false;
        }

        public void Update(GameTime gameTime)
        {
            CurrentLayer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentLayer.Draw(spriteBatch);
        }
    }
}
