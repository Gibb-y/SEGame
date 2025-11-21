using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SEGame.EC.Components;

namespace SEGame.EC.Scripts
{
    public class PlayerScript : IScript
    {
        private Transform _transform;
        private Physics _physics;

        public void Initialize(Entity entity)
        {
            _transform = entity.GetComponent<Transform>();
            _physics = entity.GetComponent<Physics>();
        }

        public void Update(GameTime gameTime)
        {
            var delta = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                delta.X -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                delta.X += 1;
            }

            _transform.Position += delta;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _physics.Velocity -= Vector2.UnitY * 5;
            }

            if (_transform.Position.Y > 200)
            {
                var newPos = _transform.Position;
                newPos.Y = 200;
                _transform.Position = newPos;
            }
        }
    }
}
