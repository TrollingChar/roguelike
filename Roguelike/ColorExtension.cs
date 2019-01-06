using XNA = Microsoft.Xna.Framework;


namespace Roguelike {

    public static class ColorExtension {

        private static readonly Microsoft.Xna.Framework.Color [] _map = new [] {
            Microsoft.Xna.Framework.Color.Transparent,

            new XNA.Color (0x00, 0x00, 0x00),
            new XNA.Color (0x55, 0x55, 0x55),
            new XNA.Color (0xaa, 0xaa, 0xaa),
            new XNA.Color (0xff, 0xff, 0xff),

            new XNA.Color (0x00, 0x00, 0xaa),
            new XNA.Color (0x00, 0xaa, 0xff),
            new XNA.Color (0x55, 0xff, 0xff),

            new XNA.Color (0x00, 0xaa, 0x00),
            new XNA.Color (0x55, 0xff, 0x55),

            new XNA.Color (0xaa, 0x55, 0x00),
            new XNA.Color (0xff, 0xaa, 0x00),
            new XNA.Color (0xff, 0xff, 0x55),

            new XNA.Color (0xaa, 0x00, 0x00),
            new XNA.Color (0xff, 0x55, 0x55),

            new XNA.Color (0xaa, 0x00, 0xaa),
            new XNA.Color (0xff, 0x55, 0xff),
        };


        public static XNA.Color ToRgb (this Color color) => _map [(int) color];

    }

}