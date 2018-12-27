namespace Roguelike {

    public class CharMatrix {

        private int      _width, _height;
        private Char [,] _chars;


        public CharMatrix (int w, int h) {
            _width  = w;
            _height = h;
            _chars  = new Char [w, h];
        }


        public CharMatrix (int w, int h, Char filler) : this (w, h) {
            for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++) {
                _chars [x, y] = filler;
            }
        }

        public string ConvertToString()
        {
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    s += _chars[j, i].Character;
                }

                s += "\n";
            }

            return s;
        }

    }

}