using Microsoft.Xna.Framework;
using System.Collections.Generic;
using SEGame.EC;

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
