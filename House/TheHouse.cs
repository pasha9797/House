using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class TheHouse
    {
        private List<TheFloor> floors;
        public TheHouse()
        {
            floors = new List<TheFloor>(10);
            for (int i=1; i<=10; i++)
            {
                floors.Add(new House.TheFloor(i));
            }
        }
    }
}
