using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class TheResident
    {
        private int x, floor, id;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
            }
        }
        public TheResident(int floor, int id)
        {
            this.floor = floor;
            this.id = id;
            this.x = Drawer.start + id * Drawer.step;
        }
    }
}
