using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;
using SEGame.UI;

namespace SEGame.Scenes
{
    public class Level
    {
        public IGameState Paused;
        public IGameState Playing;

        private IGameState prevGameState;

        protected EntityManager _entityManager = EntityManager.Instance;
        private DrawManager _drawManager = DrawManager.Instance;

        public Level()
        {
            Paused = new PausedState(this);
            Playing = new PlayingState(this);
            CurrentGameSate = Playing;

            // set ui layer
            UserInterfaceManager.Instance.SetLayerAsActive("empty");
            // Create pause menu
            var layer = UserInterfaceManager.Instance.GetLayer("pause_menu");
            var canvas = layer.Get<ICanvas>();
            // Quit button
            var quitBanner = new Banner(AssetManager.Instance.GetFont("weiholmir"), Vector2.Zero, 4, "Quit");
            var quitButton = new TextButton(quitBanner, AssetManager.Instance.GetTexture2D("ui_buttons"), 1, Vector2.Zero, new Rectangle(0, 448, 64, 32));
            quitButton.OnButtonClick += GameManager.Instance.QuitGame;
            quitButton.CenterTextOnTexture();
            quitButton.TextOffset = new Vector2(0, -25);
            canvas.AddItem(quitButton);
            canvas.CenterItemHorizontally(quitButton);
            canvas.CenterItemVertically(quitButton);
            quitButton.Position += new Vector2(0, 200);
            // Resume button
            var resumeBanner = new Banner(AssetManager.Instance.GetFont("weiholmir"), Vector2.Zero, 4, "Resume");
            var resumeButton = new TextButton(resumeBanner, AssetManager.Instance.GetTexture2D("ui_buttons"), 1, Vector2.Zero, new Rectangle(0, 448, 64, 32));
            resumeButton.OnButtonClick += () => CurrentGameSate = Playing;
            resumeButton.CenterTextOnTexture();
            resumeButton.TextOffset = new Vector2(0, -25);
            canvas.AddItem(resumeButton);
            canvas.CenterItemHorizontally(resumeButton);
            canvas.CenterItemVertically(resumeButton);
            resumeButton.Position += new Vector2(0, -200);
            // Main menu button
            var mainMenuBanner = new Banner(AssetManager.Instance.GetFont("weiholmir"), Vector2.Zero, 4, "Main Menu");
            var mainMenuButton = new TextButton(mainMenuBanner, AssetManager.Instance.GetTexture2D("ui_buttons"), 1, Vector2.Zero, new Rectangle(0, 448, 64, 32));
            mainMenuButton.OnButtonClick += () => SceneManager.Instance.SetSceneAsActive("main_menu");
            mainMenuButton.OnButtonClick += () => CurrentGameSate = Playing;
            mainMenuButton.CenterTextOnTexture();
            mainMenuButton.TextOffset = new Vector2(0, -25);
            canvas.AddItem(mainMenuButton);
            canvas.CenterItemHorizontally(mainMenuButton);
            canvas.CenterItemVertically(mainMenuButton);
            // Show correct interface at correct time
            Paused.OnEntry += () => UserInterfaceManager.Instance.SetLayerAsActive("pause_menu");
            Playing.OnEntry += () => UserInterfaceManager.Instance.SetLayerAsActive("empty");
        }

        public IGameState CurrentGameSate { get; set; }

        public void Destroy()
        {
            _entityManager.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentGameSate.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (prevGameState != CurrentGameSate || prevGameState == null)
            {
                prevGameState?.OnEnd();
                CurrentGameSate.OnStart();
                prevGameState = CurrentGameSate;
            }
            CurrentGameSate.Update(gameTime);
        }
    }
}