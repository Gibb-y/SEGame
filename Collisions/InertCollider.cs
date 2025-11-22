using Microsoft.Xna.Framework;
namespace SEGame.Collisions
{
    public class InertCollider : Collider
    {
        public InertCollider()
        {
        }

        public InertCollider(Rectangle collisionBox) : base(collisionBox)
        {
        }

        public override void OnBoundingBox(Rectangle boundingBox)
        {
        }

        public override void OnCollision(Collision collision)
        {
        }
    }
}
