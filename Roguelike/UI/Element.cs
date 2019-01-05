using System.Collections.Generic;


namespace Roguelike.UI {

    public class Element {

        public bool       Dirty  { get; protected set; } // ставим когда матрица поменялась
        public CharMatrix Matrix { get; protected set; }

        protected LinkedList <Element> _children;

    }


    public class Window : Element {

        

    }


    public class CharacterSetupUI : Element {

        // name      : input field
        // race      : dropdown list
        // class     : dropdown list
        // stats     : view
        // equipment : view


        public CharacterSetupUI () {
            Matrix = new CharMatrix (80, 60);
            Matrix.Print ();
        }

    }

}