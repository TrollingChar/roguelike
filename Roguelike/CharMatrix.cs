using System;
using Microsoft.Xna.Framework;


namespace Roguelike {

    public class CharMatrix {

        public  int      W { get; }
        public  int      H { get; }
        private Char [,] _chars;


        public CharMatrix (int w, int h) {
            W      = w;
            H      = h;
            _chars = new Char [w, h];
        }


        public CharMatrix (int w, int h, Char filler) : this (w, h) {
            for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++) {
                _chars [x, y] = filler;
            }
        }


        public Char this [int x, int y] => _chars [x, y];


        public void Print (int x, int y, Char ch) {
            if (x < 0 || y < 0 || x >= W || y >= H) return;
            _chars [x, y] = ch;
        }


        public void Print (int x, int y, string s, Color fg, Color bg) {
            if (y < 0 || y >= H) return;

            int sx  = Math.Max (0, x);
            int smx = x - sx;
            int ex  = Math.Min (W, x + s.Length);

            for (int ix = sx, mx = smx; ix < ex; mx++, ix++) {
                _chars [ix, y] = new Char (s [mx], fg, bg);
            }
        }


        public void Print (int x, int y, CharMatrix m) {
            int sx  = Math.Max (0, x);
            int smx = x - sx;
            int ex  = Math.Min (W, x + m.W);

            int sy  = Math.Max (0, y);
            int smy = y - sy;
            int ey  = Math.Min (H, y + m.H);

            for (int ix = sx, mx = smx; ix < ex; mx++, ix++)
            for (int iy = sy, my = smy; iy < ey; my++, iy++) {
                _chars [ix, iy] = m._chars [mx, my];
            }
        }


        [Obsolete]
        public string ConvertToString () {
            string s = "";
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    s += _chars [j, i].Character;
                }

                s += "\n";
            }

            return s;
        }

    }

}