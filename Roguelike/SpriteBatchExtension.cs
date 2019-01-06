using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike {

    public static class SpriteBatchExtension {

        public static void Print (this SpriteBatch batch, CharMatrix m) {
            for (int x = 0; x < m.W; x++)
            for (int y = 0; y < m.H; y++) {
                var ch = m [x, y];
                batch.Draw (
                    _.Assets.WhitePixel,
                    new Rectangle (10 * x, 10 * y, 10, 10),
                    ch.Background.ToRgb ()
                );
                batch.Draw (
                    _.Assets.Chars,
                    new Vector2 (10 * x, 10 * y),
                    new Rectangle (ch.Character % 16 * 10, ch.Character / 16 * 10, 10, 10),
                    ch.Foreground.ToRgb ()
                );
            }
        }

    }

}