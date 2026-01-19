using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEGame.Managers;
using SEGame.Scenes;
using SEGame.UI;
using SEGame.Util;

namespace SEGame
{
    public class InfiniJump : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AssetManager _assetManager;
        private DrawManager _drawManager;
        private CollisionManager _collisionManager;
        private SceneManager _sceneManager;


        public InfiniJump()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _assetManager = AssetManager.Instance;
            _drawManager = DrawManager.Instance;
            _collisionManager = CollisionManager.Instance;
            _collisionManager.Initialize(1280, 800);
            Shapes.Instance.Initialize(GraphicsDevice);
            base.Initialize();
            _sceneManager = SceneManager.Instance;
            UserInterfaceManager userInterfaceManager = UserInterfaceManager.Instance;
            // main menu
            userInterfaceManager.AddLayer(new UserInterfaceLayer("main_menu"));
            userInterfaceManager.AddItemTo(new Canvas(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), "main_menu");
            // pause screen
            userInterfaceManager.AddLayer(new UserInterfaceLayer("pause_menu"));
            userInterfaceManager.AddItemTo(new Canvas(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), "pause_menu");
            // victory screen
            userInterfaceManager.AddLayer(new UserInterfaceLayer("victory_menu"));
            userInterfaceManager.AddItemTo(new Canvas(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), "victory_menu");
            // death screen
            userInterfaceManager.AddLayer(new UserInterfaceLayer("death_menu"));
            userInterfaceManager.AddItemTo(new Canvas(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), "death_menu");
            // empty layer
            userInterfaceManager.AddLayer(new UserInterfaceLayer("empty"));
            GameManager.Instance.Initialize(this, new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _assetManager.AddTexture2D("idle", Content.Load<Texture2D>("Player/idle"));
            _assetManager.AddTexture2D("run", Content.Load<Texture2D>("Player/run"));
            _assetManager.AddTexture2D("jump", Content.Load<Texture2D>("Player/jump"));
            _assetManager.AddTexture2D("fall", Content.Load<Texture2D>("Player/fall"));
            _assetManager.AddTexture2D("terrain", Content.Load<Texture2D>("Environment/terrain"));
            AssetLoader.LoadTextures2DFromXmlFile("C:\\Users\\Sander\\source\\repos\\SEGame\\AssetList.xml", Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            _sceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //_drawManager.Draw(_spriteBatch);
            _sceneManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
