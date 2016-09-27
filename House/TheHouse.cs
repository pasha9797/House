using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace House
{
    public class TheHouse
    {
        private List<TheFloor> floors;
        private TheLift lift;
        private Timer houseTimer;
        private int time = 5;

        public List<TheFloor> Floors
        {
            get
            {
                return floors;
            }
        }
        public TheLift Lift
        {
            get
            {
                return lift;
            }
        }
        public int Time
        {
            get
            {
                return time;
            }
        }

        private void Tick(Object source, ElapsedEventArgs e)
        {
            time++;
            if (time == 24) time = 0;
            foreach (TheFloor floor in floors)
            {
                foreach (TheResident resident in floor.Residents)
                {
                    if (resident.ExitHour == time && resident.WhereHeIs==1)
                    {
                        floor.Waiting.Enqueue(resident);
                        resident.SetWaitingCoords(floor.Number, resident.Id);
                        resident.WantsTo = 1;
                        lift.PressButton(floor.Number);
                    }
                    else
                    if (resident.EnterHour == time && resident.WhereHeIs==4)
                    {
                        floors[0].Waiting.Enqueue(resident);
                        resident.SetWaitingCoords(1, resident.Id);
                        resident.WantsTo = resident.Floor;
                        lift.PressButton(1);
                    }
                }
                
            }
            houseTimer.Interval=Settings.TimeSpeed;
        }

        public TheHouse()
        {
            floors = new List<TheFloor>(Settings.FloorsAmount);
            lift = new TheLift();
            lift.Floor = 1;
            for (int i=1; i<=Settings.FloorsAmount; i++)
            {
                floors.Add(new House.TheFloor(i));
            }
            houseTimer = new Timer(Settings.TimeSpeed);
            houseTimer.Elapsed += Tick;
            houseTimer.AutoReset = true;
            houseTimer.Enabled = true;
        }
    }
}
