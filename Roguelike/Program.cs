using Microsoft.Xna.Framework;


namespace Roguelike {

    public class Program {

        public static void Main (string [] args) {
            using (var game = new Game ()) {
                game.Run ();
            }
        }

    }


    public class Game : Microsoft.Xna.Framework.Game {

        private GraphicsDeviceManager _graphicsDevice;


        public Game () {
            _graphicsDevice = new GraphicsDeviceManager(this);
        }

    }

}