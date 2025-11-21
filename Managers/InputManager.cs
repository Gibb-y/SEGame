using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SEGame.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private KeyboardState _keyboardState;
        private KeyboardState _prevKeyboardState;

        public void Update(GameTime gameTime)
        {
            _prevKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return _keyboardState.IsKeyDown(key);
        }

        public bool IsKeyJustDown(Keys key)
        {
            return !_prevKeyboardState.IsKeyDown(key) && _keyboardState.IsKeyDown(key);
        }
    }
}
