using Microsoft.Xna.Framework;
using SEGame.Collisions;
using System.Collections.Generic;

namespace SEGame.Managers
{
    public class CollisionManager : Singleton<CollisionManager>
    {
        private List<Collider> _colliders;
        private Rectangle _boundingBox;

        public CollisionManager()
        {
            _colliders = new();
        }

        public void Initialize(int width, int height)
        {
            var xOffset = (int)(width * 0.1);
            var yOffset = (int)(height * 0.1);
            _boundingBox = new Rectangle(xOffset / 2, yOffset / 2, width - xOffset, height - yOffset);
        }

        public void RegisterCollider(Collider collider)
        {
            _colliders.Add(collider);
        }

        public void DeregisterCollider(Collider collider)
        {
            _colliders.Remove(collider);
        }

        public void ProcessCollisions()
        {
            foreach (var collider in _colliders)
            {
                collider.Update(null, null);
            }

            for (int i = 0; i < _colliders.Count; i++)
            {
                for (int j = 0; j < _colliders.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (_colliders[i].CollisionBox.Intersects(_colliders[j].CollisionBox))
                    {
                        var collision = new Collision() { FirstCollisionObject = _colliders[i], SecondCollisionObject = _colliders[j] };
                        _colliders[i].AddCollision(collision);
                        _colliders[j].AddCollision(collision);
                    }
                }
            }
        }

        public void ProcessBoundingBox()
        {
            foreach (var collider in _colliders)
            {
                if (_boundingBox.Contains(collider.CollisionBox))
                {
                    collider.InsideBoundingBox = true;
                }
                else
                {
                    collider.InsideBoundingBox = false;
                }
            }
        }

        public void ClearCollisions()
        {
            foreach (var collider in _colliders)
            {
                collider.ClearCollisions();
            }
        }

        public void ProcessOnBoundingBox()
        {
            foreach (var collider in _colliders)
            {
                collider.OnBoundingBox(_boundingBox);
            }
        }

        public void ProcessOnCollision()
        {
            foreach (var collider in _colliders)
            {
                foreach (var collision in collider.Collisions)
                {
                    collider.OnCollision(collision);
                }
            }
        }

        public void Update()
        {
            ClearCollisions();

            ProcessBoundingBox();
            ProcessOnBoundingBox();

            ProcessCollisions();
            ProcessBoundingBox();
            ProcessOnCollision();
        }
    }
}
