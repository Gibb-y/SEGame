using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SEGame.EC.Components;
using SEGame.Managers;

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

            if (InputManager.Instance.IsKeyDown(Keys.A))
            {
                delta.X -= 1;
            }

            if (InputManager.Instance.IsKeyDown(Keys.D))
            {
                delta.X += 1;
            }

            _transform.Position += delta;

            if (InputManager.Instance.IsKeyJustDown(Keys.Space))
            {
                var newVel = _physics.Velocity;
                newVel.Y = -5;
                _physics.Velocity = newVel;
            }

            if (_transform.Position.Y > 200)
            {
                var newPos = _transform.Position;
                newPos.Y = 200;
                _transform.Position = newPos;
                if (_physics.Velocity.Y > 0)
                {
                    var newVel = _physics.Velocity;
                    newVel.Y = 0;
                    _physics.Velocity = newVel;
                }
            }
        }
    }
}
