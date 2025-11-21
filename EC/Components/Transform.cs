using Microsoft.Xna.Framework;

namespace SEGame.EC.Components
{
    public class Transform : IComponent
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }

        public void Initialize(Entity entity)
        {
            Position = Vector2.Zero;
            Rotation = 0f;
        }

        public void Update(Entity entity, GameTime gameTime)
        {
            
        }
    }
}
