using System;
using System.Collections.Generic;
using System.Text;

namespace WormLifeSimulator
{
    public class Worm: Field
    {
        public String _name;
        
        public Worm(int x, int y, String name): base(x, y)
        {
            this._name = name;
        }

        public String Name
        {
            get { return _name; }
        }
    }
}
