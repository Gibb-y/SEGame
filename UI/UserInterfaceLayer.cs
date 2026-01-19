using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;

namespace SEGame.UI
{
    internal class UserInterfaceLayer : EC.IDrawable
    {
        public string Name { get; set; }
        public ISet<IUserInterface> Elements { get; private set; }

        public UserInterfaceLayer(string name)
        {
            Name = name;
            Elements = new HashSet<IUserInterface>();
        }

        public void AddItem(IUserInterface item)
        {
            Elements.Add(item);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var element in Elements)
            {
                if (element is IClickable e)
                {
                    var mouseState = Mouse.GetState();
                    var pressed = InputManager.Instance.IsJustPressed(MouseButtons.Left);
                    if (e.GetClickableArea().Contains(mouseState.Position) && pressed)
                        e.OnClick();
                }
                if (element is ICanvas canvas)
                {
                    var clicables = canvas.GetClickables();
                    foreach (var item in clicables)
                    {
                        var mouseState = Mouse.GetState();
                        var pressed = InputManager.Instance.IsJustPressed(MouseButtons.Left);
                        if (item.GetClickableArea().Contains(mouseState.Position) && pressed)
                            item.OnClick();
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Elements)
                item.Draw(spriteBatch);
        }

        public T Get<T>()
        {
            foreach (var item in Elements)
                if (item is T t)
                    return t;
            return default;
        }
    }
}
