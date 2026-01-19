using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;
using SEGame.UI;

namespace SEGame.Scenes
{
    public class MainMenu : IScene
    {
        public string Name => "main_menu";

        private Banner banner;
        private TextButton button;

        public void Destroy()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
            //BackgroundManager.Instance.Draw(spriteBatch);
            UserInterfaceManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Initialize(GameTime gameTime)
        {
            // Get Fullscreen Canvas
            UserInterfaceManager.Instance.SetLayerAsActive("main_menu");
            var ui = UserInterfaceManager.Instance.CurrentLayer;
            var canvas = ui.Get<ICanvas>();
            // Setup level 1 button
            banner = new(AssetManager.Instance.GetFont("weiholmir"), new Vector2(100, 100), 4, "Level 1");
            button = new(banner, AssetManager.Instance.GetTexture2D("ui_buttons"), 4, new Vector2(100, 100), new Rectangle(0, 448, 64, 32));
            button.OnButtonClick += () => SceneManager.Instance.SetSceneAsActive("level_1");
            button.CenterTextOnTexture();
            button.TextOffset = new Vector2(0, -25);
            canvas.AddItem(button);
            canvas.CenterItemHorizontally(button);
            canvas.CenterItemVertically(button);
            button.Position += new Vector2(-300, 0);
            // Setup level 2 button
            var lvl2banner = new Banner(AssetManager.Instance.GetFont("weiholmir"), new Vector2(100, 100), 4, "Level 2");
            var lvl2button = new TextButton(lvl2banner, AssetManager.Instance.GetTexture2D("ui_buttons"), 4, new Vector2(100, 100), new Rectangle(0, 448, 64, 32));
            lvl2button.OnButtonClick += () => SceneManager.Instance.SetSceneAsActive("level_2");
            lvl2button.CenterTextOnTexture();
            lvl2button.TextOffset = new Vector2(0, -25);
            canvas.AddItem(lvl2button);
            canvas.CenterItemHorizontally(lvl2button);
            canvas.CenterItemVertically(lvl2button);
            lvl2button.Position += new Vector2(300, 0);
            // Setup Quit button
            var quitBanner = new Banner(AssetManager.Instance.GetFont("weiholmir"), Vector2.Zero, 4, "Quit");
            var quitButton = new TextButton(quitBanner, AssetManager.Instance.GetTexture2D("ui_buttons"), 4, Vector2.Zero, new Rectangle(0, 448, 64, 32));
            quitButton.OnButtonClick += GameManager.Instance.QuitGame;
            quitButton.CenterTextOnTexture();
            quitButton.TextOffset = new Vector2(0, -25);
            canvas.AddItem(quitButton);
            canvas.CenterItemHorizontally(quitButton);
            canvas.CenterItemVertically(quitButton);
            quitButton.Position += new Vector2(0, 200);
            // Set up title
            var titleBanner = new Banner(AssetManager.Instance.GetFont("weiholmir"), Vector2.Zero, 8, "Danger Jump");
            canvas.AddItem(titleBanner);
            canvas.CenterItemHorizontally(titleBanner);
            canvas.CenterItemVertically(titleBanner);
            titleBanner.Position += new Vector2(0, -300);
            ui.AddItem(canvas);
        }

        public void Update(GameTime gameTime)
        {
            UserInterfaceManager.Instance.Update(gameTime);
        }
    }
}
