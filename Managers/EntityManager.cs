using Microsoft.Xna.Framework;
using System.Collections.Generic;
using SEGame.EC;
using System.Linq;

namespace SEGame.Managers
{
    public class EntityManager : Singleton<EntityManager>
    {
        private List<Entity> _entities;

        public EntityManager()
        {
            _entities = new();
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        public void Clear()
        {
            for (int i = _entities.Count - 1; i >= 0; i--)
            {
                _entities[i].Destroy();
            }
        }

        public T FindByType<T>() where T : Entity
        {
            return _entities.Find(e => e is T) as T;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var ent in _entities)
            {
                ent.UpdateComponents(gameTime);
            }

            CollisionManager.Instance.Update();

            foreach (var ent in _entities)
            {
                ent.UpdateScripts(gameTime);
            }
        }
    }
}
