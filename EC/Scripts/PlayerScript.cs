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
        }
    }
}
