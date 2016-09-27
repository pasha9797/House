using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public static class Settings
    {
        public static int TimeSpeed = 5000;//Длительность одного часа
        public static int LiftSpeed = 700;//За сколько лифт проедет 1 этаж
        public static int DrawInterval = 100;//Интервал обновления экрана

        public static int MaxTimeSpeed = 10000;
        public static int MinTimeSpeed = DrawInterval;
        public static int MaxLiftSpeed = 5000;
        public static int MinLiftSpeed = DrawInterval;

        public static int LiftCapacity = 4;//Максимальная вместительность лифта
        public static int FloorCapacity = 5;//Количество жильцов на этаже
        public static int FloorsAmount = 7;//Количество этажей

        public static int stepRes = 15; // Расстояние между людьми на этаже
        public static int stepLift = 14;//Расстояние между людьми в лифте
        public static float floorSize = 76.4F;//Расстояние между этажами
        public static int wholeStartX = 300;//Положение всего рисунка по X
        public static int startX = wholeStartX + 205;//Положение людей на этаже по X
        public static int startY = 650; // Положение людей на этаже по Y
        public static int waitX = wholeStartX + 110;//Положение людей в очереди по X
        public static int liftX = wholeStartX + 37;//Положение лифта по X
        public static int liftY = 43;//Положение лифта по Y
        public static int AnimStepAmount = 5;//За сколько шагов выполнять анимацию
    }
}
