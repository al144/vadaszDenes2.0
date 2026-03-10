using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace vadaszDenes
{
    class Rover
    {
         public enum Action{
            MovingSlow,
            MovingNormal,
            MovingFast,
            Mining,
            Idle
        }

        public string Name { get; private set; }
        public int[] StartPos { get; private set; }
        public int[] CurrentPos { get; private set; }
        public int[] Destination { get; private set; }
        public int Battery { get; private set; }
        public Action CurrentAction { get; private set; }
        public int BlueCrystals { get; private set; }
        public int YellowCrystals { get; private set; }
        public int GreenCrystals { get; private set; }
        public int AllCrystals { get; private set; }


        public Rover(string name, int[] startPos)
        {
            Name = name;
            StartPos = new int[] { startPos[0], startPos[1] };
            CurrentPos = new int[] { startPos[0], startPos[1] };
            Destination = new int[] { startPos[0], startPos[1] };
            Battery = 100;
            CurrentAction = Action.Idle;
            BlueCrystals = 0;
            YellowCrystals = 0;
            GreenCrystals = 0;
            AllCrystals = 0;
        }

        public void SetDestination(int[] pos)
        {
            Destination = new int[] { pos[0], pos[1] };
        }

        public void Move()
        {

        }

    }
}
