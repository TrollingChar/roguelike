using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Roguelike {

    public static class SpriteBatchExtension {

        [Obsolete]
        public static void Print (this SpriteBatch batch, char ch, int x, int y, Color color) {
            batch.Draw (
                _.Assets.Chars,
                new Vector2 (10 * x, 10 * y),
                new Rectangle (ch % 16 * 10, ch / 16 * 10, 10, 10),
                color
            );
        }


        [Obsolete]
        public static void Print (this SpriteBatch batch, string s, int x, int y, Color color) {
            for (int i = 0; i < s.Length; i++) {
                batch.Print (s [i], x + i, y, color);
            }
        }


        public static void Print (this SpriteBatch batch, CharMatrix m) {
            for (int x = 0; x < m.W; x++)
            for (int y = 0; y < m.H; y++) {
                var ch = m [x, y];
                batch.Draw (
                    _.Assets.WhitePixel,
                    new Rectangle (10 * x, 10 * y, 10, 10),
                    ch.Background
                );
                batch.Draw (
                    _.Assets.Chars,
                    new Vector2 (10 * x, 10 * y),
                    new Rectangle (ch.Character % 16 * 10, ch.Character / 16 * 10, 10, 10),
                    ch.Foreground
                );
            }
        }

    }

}