using Microsoft.Xna.Framework;


namespace Roguelike {

    public struct Char {

        public char  Character;
        public Color Foreground;
        public Color Background;

        public Char(char c, Color f, Color b)
        {
            Character = c;
            Foreground = f;
            Background = b;
        }
        
    }

}