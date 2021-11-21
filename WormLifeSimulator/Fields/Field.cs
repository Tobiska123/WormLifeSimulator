using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    class Field
    {
        private int _x;
        private int _life;
        private int _y;
        public Field(int x, int y)
        {
            this._x = x;
            this._y = y;
            this._life = 10;
        }

        public int Life
        {
            set { this._life = value; }
            get { return _life; }
        }

        public void DecreaseLife()
        {
            this._life--;
        }

        public int X
        {
            set { _x = value; }
            get { return _x; }
        }

        public int Y
        {
            set { _y = value; }
            get { return _y; }
        }
    }
}
