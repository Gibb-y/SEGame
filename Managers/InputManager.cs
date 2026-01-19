using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SEGame.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private KeyboardState _keyboardState;
        private KeyboardState _prevKeyboardState;
        private ISet<MouseButtons> buttonsDown = new HashSet<MouseButtons>();


        public void Update(GameTime gameTime)
        {
            buttonsDown.Clear();
            var mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Pressed)
                buttonsDown.Add(MouseButtons.Left);
            if (mState.MiddleButton == ButtonState.Pressed)
                buttonsDown.Add(MouseButtons.Middle);
            if (mState.RightButton == ButtonState.Pressed)
                buttonsDown.Add(MouseButtons.Right);

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

        public bool IsJustPressed(MouseButtons button)
        {
            return !buttonsDown.Contains(button) && Mouse.GetState().LeftButton == ButtonState.Pressed;
        }
    }

    public enum MouseButtons
    {
        Left,
        Right,
        Middle
    }
}
