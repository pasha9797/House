using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class TheFloor
    {
        private int number;
        private List<TheResident> residents;
        private Queue<TheResident> waiting;
        public int Number
        {
            get
            {
                return Number;
            }
        }
        public List<TheResident> Residents
        {
            get
            {
                return residents;
            }
        }
        public Queue<TheResident> Waiting
        {
            get
            {
                return waiting;
            }
        }
        public TheFloor(int number)
        {
            this.number = number;
            Random r = new Random();
            int resnum = r.Next(1, 11);
            residents = new List<TheResident>(resnum);
            waiting = new Queue<TheResident>(resnum);
            for (int i = 0; i < resnum; i++)
            {
                residents.Add(new TheResident(number, i));
            }
        }
    }
}
