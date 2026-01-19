//using DangerSpace.Background;
using SEGame.Scenes;
using Microsoft.Xna.Framework;

namespace SEGame.Managers
{
    internal class GameManager : Singleton<GameManager>
    {
        private Game game;
        private bool initialized;
        public Vector2 ScreenSize { get; set; }

        public GameManager() { initialized = false; }


        public bool Initialize(Game game, Vector2 screenSize)
        {
            if (initialized) return false;

            this.game = game;
            ScreenSize = screenSize;
            //BackgroundFactory backgroundFactory = new();
            //BackgroundManager backgroundManager = BackgroundManager.GetInstance();
            //backgroundManager.AddBackground("default_paralax", BackgroundFactory.CreateBackground("default_paralax"));
            //backgroundManager.AddBackground("default_static", BackgroundFactory.CreateBackground("default_static"));
            //backgroundManager.SetBackground("default_paralax");
            SceneManager sceneManager = SceneManager.Instance;
            sceneManager.AddScene("level_1", new Level1());
            sceneManager.AddScene("level_2", new Level2());
            sceneManager.AddScene("main_menu", new MainMenu());
            sceneManager.SetSceneAsActive("main_menu");

            initialized = true;
            return true;
        }

        public void QuitGame()
        {
            game.Exit();
        }
    }
}
