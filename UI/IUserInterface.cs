using Microsoft.Xna.Framework;
using SEGame.EC;

namespace SEGame.UI
{
    public interface IUserInterface : EC.IDrawable
    {
        Vector2 Position { get; set; }
        Vector2 Center { get; }
    }
}
