using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SEGame.UI
{
    public interface ICanvas : IUserInterface, EC.IDrawable
    {
        List<IUserInterface> Content { get; }
        List<Point> Positions { get; }

        int SizeX { get; }
        int SizeY { get; }
        float ContentScale { get; set; }

        void AddItem(IUserInterface item, Point position);
        public void AddItem(IUserInterface item);
        void RemoveItem(IUserInterface item);
        IUserInterface GetItem(int index);
        bool TryGetItem(int index, out IUserInterface item);
        void Clear();

        bool CenterItemHorizontally(IUserInterface item);
        bool CenterItemHorizontally(int itemIndex);
        bool CenterItemVertically(IUserInterface item);
        bool CenterItemVertically(int itemIndex);
        ISet<IClickable> GetClickables();

    }
}
