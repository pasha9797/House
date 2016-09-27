using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace House
{
    public class TheResident
    {
        private int floor, id;
        private float[] coords;
        private float[] newCoords;
        private int exitHour, enterHour;
        private int whereHeIs;
        private int wantsTo=1;
        private int animStep;
        private float dX, dY;
        Timer animTimer;

        public int WantsTo
        {
            get
            {
                return wantsTo;
            }
            set
            {
                if(value>=1 && value <=Settings.FloorsAmount) wantsTo = value;
            }
        }
        public int WhereHeIs
        {
            get
            {
                return whereHeIs;
            }
            set
            {
                whereHeIs = value;
            }
        }
        public float[] Coords
        {
            get
            {
                return coords;
            }
            set
            {
                this.coords = value;
            }
        }
        public int Floor
        {
            get
            {
                return floor;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public int ExitHour
        {
            get
            {
                return exitHour;
            }
        }
        public int EnterHour
        {
            get
            {
                return enterHour;
            }
        }

        private void AnimateMovement(float x, float y)
        {
            animStep = 0;
            if (animTimer.Enabled) animTimer.Stop();
            newCoords = new float[2] { x, y };
            dX = (newCoords[0] - coords[0]) / Settings.AnimStepAmount;
            dY = (newCoords[1] - coords[1]) / Settings.AnimStepAmount;
            animTimer.Start();
        }
        private void AnimTick(Object source, ElapsedEventArgs e)
        {
            coords[0] += dX;
            coords[1] += dY;
            animStep++;
            if (animStep >= Settings.AnimStepAmount) animTimer.Stop();
        }
        public void SetHomeCoords()
        {
            float x = Settings.startX + id * Settings.stepRes;
            float y = Settings.startY - floor * Settings.floorSize;
            AnimateMovement(x, y);
            whereHeIs = 1;
        }
        public void SetWaitingCoords(int waitFloor, int waitId)
        {
            float x = Settings.waitX +  waitId* Settings.stepRes;
            float y = Settings.startY - waitFloor * Settings.floorSize - (floor-2);
            AnimateMovement(x, y);
            whereHeIs = 2;
        }
        public void SetLiftCoords(int place, float liftFloor)
        {
            if (animTimer.Enabled) animTimer.Stop();
            coords[0] = Settings.liftX + place * Settings.stepLift;
            coords[1] = Settings.startY - liftFloor * Settings.floorSize;
            whereHeIs = 3;
        }
        public void SetOutdoorCoords()
        {
            float x = Settings.waitX + 200 + Settings.stepRes * (id + 5 * (floor - 2));
            float y = Settings.startY - 1 * Settings.floorSize;
            AnimateMovement(x, y);
            whereHeIs = 4;
        }

        public TheResident(int floor, int id)
        {
            this.floor = floor;
            this.id = id;
            this.exitHour = 11 - (id + floor-1) / 2;
            this.enterHour = 22 - (id + floor-1) / 2;
            this.coords = new float[2];
            animTimer = new Timer(Settings.DrawInterval);
            animTimer.Elapsed += AnimTick;
            animTimer.AutoReset = true;
            animTimer.Enabled = false;
            SetHomeCoords();
        }
    }
}
