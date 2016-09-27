using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class TheFloor
    {
        private int number;
        private List<TheResident> residents;
        private Queue<TheResident> waiting;

        public int Number
        {
            get
            {
                return number;
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
            residents = new List<TheResident>(Settings.FloorCapacity);
            waiting = new Queue<TheResident>(Settings.FloorCapacity);
            if (number > 1)
            {
                for (int i = 0; i < Settings.FloorCapacity; i++)
                {
                    residents.Add(new TheResident(number, i));
                }
            }
        }
    }
}
