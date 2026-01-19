using Microsoft.Xna.Framework;

namespace SEGame.UI
{
    public interface IClickable : IUserInterface
    {
        void OnClick();
        Rectangle GetClickableArea();
    }
}
