namespace Roguelike {

    public struct Char {

        public char  Character;
        public Color Foreground;
        public Color Background;


        public Char (char c, Color fg, Color bg) {
            Character  = c;
            Foreground = fg;
            Background = bg;
        }

    }

}