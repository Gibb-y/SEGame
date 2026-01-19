using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Scenes;
using System.Collections.Generic;

namespace SEGame.Managers
{
    public class SceneManager : Singleton<SceneManager>
    {
        private readonly IDictionary<string, IScene> scenes;
        private IScene activeScene;
        private string activeSceneName;

        public SceneManager()
        {
            scenes = new Dictionary<string, IScene>();
        }

        public bool AddScene(string name, IScene scene)
        {
            return scenes.TryAdd(name, scene);
        }


        public bool SetSceneAsActive(string name)
        {
            return scenes.TryGetValue(name, out activeScene);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            activeScene.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (activeSceneName == null || activeSceneName != activeScene.Name)
            {
                if (activeSceneName is not null)
                    scenes[activeSceneName].Destroy();
                activeSceneName = activeScene.Name;
                activeScene.Initialize(gameTime);
            }
            //update scene
            activeScene.Update(gameTime);
            //always update input manager
            InputManager.Instance.Update(gameTime);
        }
    }
}
