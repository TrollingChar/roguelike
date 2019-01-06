using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.UI;


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
            _.Assets.WhitePixel.SetData (new [] {Microsoft.Xna.Framework.Color.White});
        }


        protected override void Initialize () {
            base.Initialize ();
            _spriteBatch = new SpriteBatch (GraphicsDevice);

            IsMouseVisible = true;

            _.Time  = 0;
            _.Input = new Input ();

            _matrix = new CharMatrix (80, 60, new Char ((char) 176, Color.Gray, Color.Black));
//            _matrix.Print (1, 1, "[F1] Help", Color.White, Color.Black);
//            _matrix.Print (1, 3, "[F2] Play", Color.White, Color.Black);

            new Window (10, 10, 50, 50, Color.Blue).Open ();
            new Window (20, 20, 50, 50, Color.DarkGreen).Open ();
            new Window (0, 30, 20, 20, Color.DarkRed).Open ();
            new Window (30, 0, 20, 20, Color.Black).Open ();
        }


        protected override void Update (GameTime gameTime) {
            _.Input.Update ();
            UiEvent e = 0;
            foreach (var w in _.Windows.ToList ()) {
                w.Update (ref e);
            }

            _matrix = new CharMatrix (80, 60, new Char ((char) 176, Color.Gray, Color.Black));
            foreach (var w in _.Windows.Reverse ()) {
                _matrix.Print (w.X, w.Y, w.Matrix);
            }
            _.Time++;
            base.Update (gameTime);
        }


        protected override void Draw (GameTime gameTime) {
            GraphicsDevice.Clear (Microsoft.Xna.Framework.Color.Black);
            _spriteBatch.Begin ();
            _spriteBatch.Print (_matrix);
            _spriteBatch.End ();
            base.Draw (gameTime);
        }

    }

}