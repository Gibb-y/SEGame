using Microsoft.Xna.Framework;
using SEGame.EC;
using SEGame.EC.Components;
using SEGame.Managers;
using System.Collections.Generic;

namespace SEGame.Collisions
{
    public abstract class Collider : IComponent
    {
        protected Entity _owner;
        protected Transform _transform;

        private HashSet<Collision> _collisions;
        public HashSet<Collision> Collisions { get => _collisions; }

        public bool InsideBoundingBox { get; set; }
        public Rectangle CollisionBox { get; set; }

        public Collider()
        {
            _collisions = new();
        }

        public Collider(Rectangle collisionBox)
        {
            _collisions = new();
            CollisionBox = collisionBox;
        }

        public void Initialize(Entity entity)
        {
            _owner = entity;
            _transform = _owner.GetComponent<Transform>();
            CollisionManager.Instance.RegisterCollider(this);
            _owner.OnDestroy += () => CollisionManager.Instance.DeregisterCollider(this);
        }

        public void Update(Entity entity, GameTime gameTime)
        {
            var newColl = CollisionBox;
            newColl.Location = _transform.Position.ToPoint();
            CollisionBox = newColl;
        }

        public void ClearCollisions()
        {
            _collisions.Clear();
        }

        public void AddCollision(Collision collision)
        {
            _collisions.Add(collision);
        }

        public abstract void OnCollision(Collision collision);

        public abstract void OnBoundingBox();
    }
}
