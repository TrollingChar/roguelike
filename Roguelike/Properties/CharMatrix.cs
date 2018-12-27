using System.Data;
using System.Xml;

namespace Roguelike.Properties
{
    public class CharMatrix
    {
        private static int width, height;
        private char filler;
        public CharMatrix(int x, int y, char f)
        {
            width = x;
            height = y;
            filler = f;
        }
       
        public Char[,] chars = new Char[width,height];

        public void FillMatrix()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0;j < height;j++)
                {
                    chars[i, j].Character = filler;
                }
            }
        }
    }
}