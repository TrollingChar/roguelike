using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike {

    public class Game : Microsoft.Xna.Framework.Game {

        private GraphicsDeviceManager _graphicsDevice;
        private SpriteBatch _spriteBatch;


        public Game () {
            _graphicsDevice = new GraphicsDeviceManager (this) {
                PreferredBackBufferWidth  = 800,
                PreferredBackBufferHeight = 600,
            };
        }


        protected override void Initialize () {
            base.Initialize ();
            _spriteBatch = new SpriteBatch (GraphicsDevice);
        }


        protected override void LoadContent () {
            _.Assets = new Assets (Content);
        }


        protected override void Update (GameTime gameTime) {
            // update game
            base.Update (gameTime);
        }


        protected override void Draw (GameTime gameTime) {
            GraphicsDevice.Clear (Color.Black);
            // draw game
            _spriteBatch.Begin ();
            _spriteBatch.Print ("Hello world!", 1, 1, Color.Lime);
            _spriteBatch.End ();
            base.Draw (gameTime);
        }

    }

}