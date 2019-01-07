using System.Collections.Generic;


namespace Roguelike.UI {

    public class Element {

        public CharMatrix Matrix { get; private set; }
        public bool       Dirty;


        protected Element        Parent;
        protected List <Element> Children;


        // эти значения означают реальное положение элемента
        // их выставляет элемент-родитель
        public int X;
        public int Y;
        public int W;
        public int H;
        

        // эти значения ставит сам
        public int PreferredX;
        public int PreferredY;
        public int PreferredW;
        public int PreferredH;
        // можно наверное следить из родительского элемента когда эти значения меняются


        public void Refresh () {
            // обновить матрицу и сбросить флаг
            Dirty = false;
        }


        protected void SetDirty () {
            Dirty = true;
            Parent?.SetDirty ();
        }

    }

}