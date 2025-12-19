using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Collisions;
using SEGame.Managers;
using SEGame.Util;
using System.Collections.Generic;

namespace SEGame.EC.Components
{
    public abstract class Collider : IComponent, IDrawableComponent
    {
        protected Entity _owner;
        protected Transform _transform;
        private bool _debug;
        private Texture2D _debugShape;

        private HashSet<Collision> _collisions;
        public HashSet<Collision> Collisions { get => _collisions; }

        public bool InsideBoundingBox { get; set; }
        public Rectangle CollisionBox { get; set; }

        public Collider()
        {
            _collisions = new();
        }

        public Collider(Rectangle collisionBox, bool debug = false)
        {
            _collisions = new();
            CollisionBox = collisionBox;
            _debug = debug;
            if (_debug)
                _debugShape = Shapes.Instance.CreateRectangle(CollisionBox.Width, CollisionBox.Height);
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

        public abstract void OnBoundingBox(Rectangle boundingBox);

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_debug)
                spriteBatch.Draw(_debugShape, _transform.Position, null, Color.White, 0f, Vector2.Zero, 2, SpriteEffects.None, 1);
        }
    }
}
