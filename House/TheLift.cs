using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace House
{
    public class TheLift
    {
        private List<TheResident> passengers;
        private float floor;
        private List<int> pressedButton;
        private List<int> pressedInside;
        private System.Timers.Timer liftTimer;
        private float dY;

        public List<int> PressedButton
        {
            get
            {
                return pressedButton;
            }
        }
        public List<int> PressedInside
        {
            get
            {
                return pressedInside;
            }
        }
        public List<TheResident> Passengers
        {
            get
            {
                return passengers;
            }
        }
        public float Floor
        {
            get
            {
                return floor;
            }
            set
            {
                if (value > 0 && value <= 7) floor = value;
            }
        }


        public void PressButton(int floor)
        {
            if (!pressedButton.Contains(floor)) pressedButton.Add(floor);
        }
        public void PressInsideButton(int floor)
        {
            if (!pressedInside.Contains(floor)) pressedInside.Add(floor);
        }
        private void playSound(string path)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }
        private void MoveLift(float dist)
        {
            floor += dist;
            if (Math.Abs(floor - Math.Round(floor)) <= dY/2)
                floor = (float)Math.Round(floor);
        }
        private void LiftTick(Object source, ElapsedEventArgs e)
        {
            if (pressedInside.Count == 0)//если внутри не нажато
            {
                if (pressedButton.Count() > 0)//если он вызван на этаж
                {
                    if (floor == pressedButton.First())//на текущий этаж
                    {
                        GatherFloor((int)floor);//забираем людей
                    }
                    //иначе двигаем в нужную сторону
                    else if (pressedButton.First() > floor) MoveLift(dY);
                    else if (pressedButton.First() < floor) MoveLift(-dY);
                    
                }
            }
            else//если внутри нажато
            {
                if (floor==(int)floor && pressedInside.Contains((int)floor))//если нажат текущий этаж
                {
                    GetOut((int)floor);//выпускаем людей
                }
                //иначе едем в нужную сторону
                else if (pressedInside.First() > floor) MoveLift(dY);
                else if (pressedInside.First() < floor) MoveLift(-dY);

                //если по дороге встретим этаж где ждут люди и есть свободное место, забираем их
                if(floor == (int)floor && pressedButton.Contains((int)floor) && passengers.Count()<Settings.LiftCapacity)
                {
                    GatherFloor((int)floor);
                }
            }

            //прописываем координаты пассажирам
            foreach (TheResident resident in passengers)
            {
                resident.SetLiftCoords(passengers.IndexOf(resident), floor);
            }

            dY = (float)Settings.DrawInterval / (float)Settings.LiftSpeed;
        }
        private void GatherFloor(int curFloor)
        {
            playSound("ding.wav");
            StopLiftForNotLong();
            int i = passengers.Count();
            while (i < Settings.LiftCapacity && Program.mainForm.House.Floors[curFloor - 1].Waiting.Count() > 0)
            {
                TheResident resident = Program.mainForm.House.Floors[curFloor - 1].Waiting.Dequeue();
                passengers.Add(resident);
                resident.SetLiftCoords(i, curFloor);
                PressInsideButton(resident.WantsTo);
                i++;
            }
            if (Program.mainForm.House.Floors[curFloor - 1].Waiting.Count() == 0) pressedButton.Remove(curFloor);
        }
        private void GetOut(int curFloor)
        {
            //playSound("ding.wav");
            StopLiftForNotLong();
            int i = 0;
            while (i < passengers.Count())
            {
                TheResident resident = passengers[i];
                if (resident.WantsTo == curFloor)
                {
                    passengers.Remove(resident);
                    if (resident.WantsTo == 1) resident.SetOutdoorCoords();
                    else resident.SetHomeCoords();
                }
                else i++;
            }
            pressedInside.Remove(curFloor);
        }
        private void StopLiftForNotLong()
        {
            liftTimer.Stop();
            System.Timers.Timer aTimer = new System.Timers.Timer(Settings.LiftSpeed);
            aTimer.Elapsed += StartLiftAgain;
            aTimer.Start();
        }
        private void StartLiftAgain(Object source, ElapsedEventArgs e)
        {
            liftTimer.Start();
        }

        public TheLift()
        {
            passengers = new List<TheResident>(Settings.LiftCapacity);
            pressedButton = new List<int>(7);
            pressedInside = new List<int>(Settings.LiftCapacity);
            dY = (float)Settings.DrawInterval / (float)Settings.LiftSpeed;
            liftTimer = new System.Timers.Timer(Settings.DrawInterval);
            liftTimer.Elapsed += LiftTick;
            liftTimer.AutoReset = true;
            liftTimer.Enabled = true;
        }
    }
}
