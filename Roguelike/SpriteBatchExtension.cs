using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike {

    public static class SpriteBatchExtension {

        public static void Print (this SpriteBatch batch, char ch, int x, int y, Color color) {
            batch.Draw (
                _.Assets.Chars,
                new Vector2 (10 * x, 10 * y),
                new Rectangle (ch % 16 * 10, ch / 16 * 10, 10, 10),
                color
            );
        }


        public static void Print (this SpriteBatch batch, string s, int x, int y, Color color) {
            for (int i = 0; i < s.Length; i++) {
                batch.Print (s [i], x + i, y, color);
            }
        }

    }

}