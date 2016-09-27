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
        static Image houseImg = Image.FromFile("pichouse.png");
        static Image liftImg = Image.FromFile("plift.png");
        static Image residentImg = Image.FromFile("picresident.png");

        public static void Draw(Graphics g)
        {
            try
            {
                g.Clear(Color.White);

                g.DrawImage(houseImg, Settings.wholeStartX, 0);
                g.DrawImage(liftImg, Settings.liftX, Settings.liftY + Settings.floorSize * (7 - Program.mainForm.House.Lift.Floor));

                Font font = new Font("Arial", 16);
                SolidBrush brush = new SolidBrush(Color.Black);
                string str = "Время: " + Program.mainForm.House.Time.ToString() + ":00\n";
                int curFloor = (int)Math.Round(Program.mainForm.House.Lift.Floor);
                str += "Этаж лифта: " + curFloor + "\n";
                str += "Вызван на этажи: ";
                foreach (int num in Program.mainForm.House.Lift.PressedButton)
                {
                    str += num.ToString() + " ";
                }
                str += "\nВнутри нажаты кнопки: ";
                foreach (int num in Program.mainForm.House.Lift.PressedInside)
                {
                    str += num.ToString() + " ";
                }
                g.DrawString(str, font, brush, 0, 0);

                foreach (TheFloor floor in Program.mainForm.House.Floors)
                {
                    foreach (TheResident resident in floor.Residents)
                    {
                        g.DrawImage(residentImg, resident.Coords[0], resident.Coords[1], 30, 30);
                    }
                }
            }
            catch { }
        }
    }
}
