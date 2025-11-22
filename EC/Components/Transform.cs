using Microsoft.Xna.Framework;

namespace SEGame.EC.Components
{
    public class Transform : IComponent
    {
        public Transform()
        {
        }

        public Transform(Vector2 position)
        {
            Position = position;
            PreviousPosition = position;
        }

        public Transform(Point position)
        {
            Position = position.ToVector2();
            PreviousPosition = position.ToVector2();
        }

        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 PreviousPosition { get; private set; } = Vector2.Zero;
        public float Rotation { get; set; }

        public void Initialize(Entity entity)
        {
            Rotation = 0f;
        }

        public void Update(Entity entity, GameTime gameTime)
        {
            PreviousPosition = Position;
        }
    }
}
