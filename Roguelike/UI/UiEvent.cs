using System;


namespace Roguelike.UI {

    [Flags]
    public enum UiEvent : byte {

        KeyPress   = 1,
        MouseHover = 2,
        MouseWheel = 4,
        MouseClick = 8

    }

}