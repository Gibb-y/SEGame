using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace SEGame.UI
{
    public class Canvas : ICanvas
    {
        public List<IUserInterface> Content { get; private set; }

        public List<Point> Positions { get; private set; }

        public Vector2 Center => new(SizeX / 2, SizeY / 2);
        public Vector2 Position { get; set; }
        public int SizeX { get; set; }

        public int SizeY {  get; set; }

        public float ContentScale { get; set; }

        public Canvas(int width, int height, float contentScale=1)
        {
            SizeX = width;
            SizeY = height;
            Content = new List<IUserInterface>();
            Positions = new List<Point>();
            ContentScale = contentScale;
            Position = new Vector2(0, 0);
        }

        public void AddItem(IUserInterface item, Point position)
        {
            Content.Add(item);
            Positions.Add(position);
        }
        
        public void AddItem(IUserInterface item)
        {
            Content.Add(item);
            Positions.Add(item.Position.ToPoint());
        }

        public void Clear()
        {
            Content.Clear();
            Positions.Clear();
        }

        public IUserInterface GetItem(int index)
        {
            return Content[index];
        }

        public bool TryGetItem(int index, out IUserInterface item)
        {
            item = null;
            if (Content.Count >= index)
                return false;
            item = Content[index];
            return true;
        }

        public T Get<T>()
        {
            foreach (var item in Content)
                if (item is T t)
                    return t;
            return default;
        }

        public void RemoveItem(IUserInterface item)
        {
            var index = Content.IndexOf(item);
            Content.RemoveAt(index);
            Positions.RemoveAt(index);
        }

        public bool CenterItemHorizontally(IUserInterface item)
        {
            var target = Content.Find(e => e.Equals(item));
            if (target == null) return false;

            target.Position += new Vector2(Center.X - target.Center.X, 0);
            return true;
        }

        public bool CenterItemHorizontally(int itemIndex)
        {
            if (!TryGetItem(itemIndex, out var target)) return false;
            target.Position += new Vector2(Center.X - target.Center.X, 0);
            return true;
        }

        public bool CenterItemVertically(IUserInterface item)
        {
            var target = Content.Find(e => e.Equals(item));
            if (target == null) return false;

            target.Position += new Vector2(0, Center.Y - target.Center.Y);
            return true;
        }

        public bool CenterItemVertically(int itemIndex)
        {
            if (!TryGetItem(itemIndex, out var target)) return false;
            target.Position += new Vector2(0, Center.Y - target.Center.Y);
            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Content)
                item.Draw(spriteBatch);
        }

        public ISet<IClickable> GetClickables()
        {
            var result = new HashSet<IClickable>();
            foreach(var item in Content)
            {
                if (item is IClickable clickItem)
                    result.Add(clickItem);
                else if (item is ICanvas canvas)
                    result.UnionWith(canvas.GetClickables());
            }
            return result;
        }
    }
}
