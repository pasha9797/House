using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class TheLift
    {
        private List<TheResident> passengers;
        private int floor;
        public List<TheResident> Passengers
        {
            get
            {
                return passengers;
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
                if (value > 0 && value <= 10) floor = value;
            }
        }
        public TheLift()
        {
            passengers = new List<TheResident>(5);
        }
    }
}
