using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;


namespace Roguelike {

    public class Input {

        private KeyboardState _keys;
        private MouseState    _mouse;

        private Dictionary <Keys, int> _pressed;  // время когда кнопку в последний раз нажимали
        private Dictionary <Keys, int> _released; // когда в последний раз отпускали

        private Keys _lastPressed;


        public Input () {
            _pressed     = new Dictionary <Keys, int> (256);
            _released    = new Dictionary <Keys, int> (256);
            _lastPressed = Keys.None;
        }


        public void Update () {
            var keys  = Keyboard.GetState ();
            var mouse = Mouse.GetState ();

            foreach (Keys key in Enum.GetValues (typeof (Keys))) {
                bool isPressed  = keys.IsKeyDown (key);
                bool wasPressed = _keys.IsKeyDown (key);
                if (isPressed) {
                    if (!wasPressed) {
                        _pressed [key] = _.Time;
                        _lastPressed   = key;
                    }
                }
                else {
                    if (wasPressed) {
                        _released [key] = _.Time;
                    }
                }
            }

            _keys  = keys;
            _mouse = mouse;
        }

    }

}