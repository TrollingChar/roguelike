using System;
using System.Collections.Generic;


namespace Roguelike.UI {

    public class Window {

        private LinkedListNode <Window> _handle;

        public           int   X { get; }
        public           int   Y { get; }
        private readonly int   _w;
        private readonly int   _h;
        private readonly Color _color;


        public Window (int x, int y, int w, int h, Color color) {
            X      = x;
            Y      = y;
            _w     = w;
            _h     = h;
            _color = color;
        }


        public void Open () {
            if (_handle != null) throw new InvalidOperationException ("That window is already open!");
            _handle = _.Windows.AddFirst (this);
        }


        public void SetFocus () {
            if (_handle == null) throw new InvalidOperationException ("That window isn't open!");
            _.Windows.Remove (_handle);
            _.Windows.AddFirst (_handle);
        }


        public void Close () {
            if (_handle == null) throw new InvalidOperationException ("That window isn't open!");
            _.Windows.Remove (_handle);
            _handle = null;
        }


        public CharMatrix Matrix => new CharMatrix (_w, _h, new Char (' ', 0, _color));


        public virtual void Update (ref UiEvent e) {
            if ((e & UiEvent.MouseClick) != 0) return;
            if (!_.Input.LmbJustPressed) return;
            if (_.Input.X < X || _.Input.Y < Y || _.Input.X >= X + _w || _.Input.Y >= Y + _h) return;

            SetFocus ();
            e |= UiEvent.MouseClick;
        }

    }


}