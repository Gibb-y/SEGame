using Microsoft.Xna.Framework;

namespace SEGame.UI
{
    public interface ITextArea : IUserInterface
    {
        string Text { get; }
        float Scale { get; }
        float Rotation { get; }
        Vector2 BaseSize { get; }
        Vector2 ScaledSize { get; }
        Util.SpriteFont Font { get; }
        void SetText(string text);
        void AppendText(string text);
        void SetFont(Util.SpriteFont font);
        void Clear();
    }
}
