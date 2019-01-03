using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike {

    public class Assets {

        public Texture2D Chars;
        public Texture2D WhitePixel;


        public Assets (ContentManager mgr) {
            Chars = mgr.Load <Texture2D> ("chars");
        }

    }

}