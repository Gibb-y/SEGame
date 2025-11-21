using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SEGame.EC
{
    public class Entity
    {
        private List<IComponent> _components;
        private List<IScript> _scripts;

        public Entity()
        {
            _components = new();
            _scripts = new();
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
            component.Initialize(this);
        }

        public void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        public T GetComponent<T>() where T : IComponent
        {
            return _components.OfType<T>().First();
        }

        public void AddScript(IScript script)
        {
            _scripts.Add(script);
            script.Initialize(this);
        }

        public void RemoveScript(IScript script)
        {
            _scripts.Remove(script);
        }

        public T GetScript<T>() where T : IScript
        {
            return _scripts.OfType<T>().First();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Update(this, gameTime);
            }

            for (int i = 0; i < _scripts.Count; i++)
            {
                _scripts[i].Update(gameTime);
            }
        }
    }
}
