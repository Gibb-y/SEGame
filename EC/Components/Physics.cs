using Microsoft.Xna.Framework;

namespace SEGame.EC.Components
{
    public class Physics : IComponent
    {
        public Vector2 Velocity { get; set; }
        public float Drag { get; set; }
        public float Gravity
        {
            get => _gravity;
            set
            {
                _gravityVector = Vector2.UnitY * value;
                _gravity = value;
            }
        }

        private Transform _transform;
        private float _gravity;
        private Vector2 _gravityVector;

        public void Initialize(Entity entity)
        {
            _transform = entity.GetComponent<Transform>();
            Drag = 1.2f;
            Gravity = .3f;
        }

        public void Update(Entity entity, GameTime gameTime)
        {
            var newVel = Velocity;
            newVel += _gravityVector;
            newVel.X /= Drag;
            //newVel.Y -= Drag;
            //Velocity = (100 - (Drag / 100)) * Velocity;
            Velocity = newVel;
            _transform.Position += Velocity;
        }
    }
}
