using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace House
{
    public static class Drawer
    {
        public const int start = 100;
        public const int step = 20;
        public static void Draw(Graphics g)
        {
            g.Clear(Color.White);
        }
    }
}
