using System;
using System.Collections.Generic;


namespace Roguelike.UI {

    public class Window {

        private LinkedListNode <Window> _handle;

        public             int X { get; }
        public             int Y { get; }
        protected readonly int W;
        protected readonly int H;
//        private readonly Color _color;


        public Window (int x, int y, int w, int h) {
            X = x;
            Y = y;
            W = w;
            H = h;
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


        public virtual CharMatrix Matrix => new CharMatrix (W, H, new Char (' ', 0, Color.DarkBlue));


        public virtual void Update (ref UiEvent e) {
            if ((e & UiEvent.MouseClick) != 0) return;
            if (!_.Input.LmbJustPressed) return;
            if (_.Input.X < X || _.Input.Y < Y || _.Input.X >= X + W || _.Input.Y >= Y + H) return;

            SetFocus ();
            e |= UiEvent.MouseClick;
        }

    }


    public class BorderedWindow : Window {

        private readonly string _title;
        private readonly Color  _color;


        public BorderedWindow (int x, int y, int w, int h, string title, Color color) : base (x, y, w, h) {
            _title = title;
            _color = color;
        }


        public override CharMatrix Matrix {
            get {
                var m = new CharMatrix (W, H);
                for (int y = 0; y < H; y++) {
                    m.Print (0,     y, new Char ((char) 178, _color, Color.Black));
                    m.Print (W - 1, y, new Char ((char) 178, _color, Color.Black));
                }
                for (int x = 0; x < W; x++) {
                    m.Print (x, 0,     new Char ((char) 178, _color, Color.Black));
                    m.Print (x, H - 1, new Char ((char) 178, _color, Color.Black));
                }
                return m;
            }
        }

    }


}