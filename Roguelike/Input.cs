using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;


namespace Roguelike {

    public class Input {

        private KeyboardState _keys;
        private MouseState    _mouse;

        private Dictionary <Keys, int> _pressed;  // время когда кнопку в последний раз нажимали
        private Dictionary <Keys, int> _released; // когда в последний раз отпускали

        private int _lmbPressed, _lmbReleased;
        private int _rmbPressed, _rmbReleased;
        private int _mmbPressed, _mmbReleased;

        private int _x0, _y0, _x, _y;

        private Keys _lastPressed;


        public Input () {
            _pressed     = new Dictionary <Keys, int> (256);
            _released    = new Dictionary <Keys, int> (256);
            _lastPressed = Keys.None;
        }


        // не использовать внутри класса эти свойства
        public int X => _x;
        public int Y => _y;
        public bool LmbJustPressed => _mouse.LeftButton == ButtonState.Pressed && _lmbPressed == _.Time;


        public void Update () {
            var keys  = Keyboard.GetState ();
            var mouse = Mouse.GetState ();

            bool isPressed, wasPressed;
            foreach (Keys key in Enum.GetValues (typeof (Keys))) {
                isPressed  = keys.IsKeyDown (key);
                wasPressed = _keys.IsKeyDown (key);
                if (isPressed) {
                    if (!wasPressed) {
                        _pressed [key] = _.Time;
                        _lastPressed   = key; // todo: обработать Shift, Ctrl и Alt по особому
                    }
                }
                else {
                    if (wasPressed) {
                        _released [key] = _.Time;
                    }
                }
            }

            isPressed  = mouse.LeftButton == ButtonState.Pressed;
            wasPressed = _mouse.LeftButton == ButtonState.Pressed;
            if (isPressed) {
                if (!wasPressed) {
                    _lmbPressed = _.Time;
                }
            }
            else {
                if (wasPressed) {
                    _lmbReleased = _.Time;
                }
            }

            isPressed  = mouse.RightButton == ButtonState.Pressed;
            wasPressed = _mouse.RightButton == ButtonState.Pressed;
            if (isPressed) {
                if (!wasPressed) {
                    _rmbPressed = _.Time;
                }
            }
            else {
                if (wasPressed) {
                    _rmbReleased = _.Time;
                }
            }

            isPressed  = mouse.MiddleButton == ButtonState.Pressed;
            wasPressed = _mouse.MiddleButton == ButtonState.Pressed;
            if (isPressed) {
                if (!wasPressed) {
                    _mmbPressed = _.Time;
                }
            }
            else {
                if (wasPressed) {
                    _mmbReleased = _.Time;
                }
            }

            _x0 = _x;
            _y0 = _y;
            _x = mouse.Position.X / 10;
            _y = mouse.Position.Y / 10;

            _keys  = keys;
            _mouse = mouse;
        }

    }

}