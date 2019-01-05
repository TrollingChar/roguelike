using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike {

    public class Game : Microsoft.Xna.Framework.Game {

        private GraphicsDeviceManager _graphicsDevice;
        private SpriteBatch           _spriteBatch;
        private CharMatrix            _matrix;


        public Game () {
            _graphicsDevice = new GraphicsDeviceManager (this) {
                PreferredBackBufferWidth  = 800,
                PreferredBackBufferHeight = 600,
            };
        }


        protected override void LoadContent () {
            _.Assets = new Assets (Content);

            _.Assets.WhitePixel = new Texture2D (GraphicsDevice, 1, 1);
            _.Assets.WhitePixel.SetData (new [] {Color.White});
        }


        protected override void Initialize () {
            base.Initialize ();
            _spriteBatch = new SpriteBatch (GraphicsDevice);

            IsMouseVisible = true;

            _.Time = 0;
            _.Input = new Input ();

            _matrix = new CharMatrix (80, 60, new Char ((char) 176, Color.Gray, Color.Black));
//            _matrix.Print (1, 1, "[F1] Help", Color.White, Color.Black);
//            _matrix.Print (1, 3, "[F2] Play", Color.White, Color.Black);
        }


        protected override void Update (GameTime gameTime) {
            _matrix = new CharMatrix (80, 60, new Char ((char) 176, Color.Gray, Color.Black));
            
            base.Update (gameTime);
        }


        protected override void Draw (GameTime gameTime) {
            GraphicsDevice.Clear (Color.Black);
            // draw game
            _spriteBatch.Begin ();
            _spriteBatch.Print (_matrix);
            _spriteBatch.End ();
            base.Draw (gameTime);
        }

    }

}