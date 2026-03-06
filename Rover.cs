using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vadaszDenes
{
    class Rover
    {
        enum Action{
            MovingSlow,
            MovingNormal,
            MovingFast,
            Mining,
            

        }

        private string name { get; set; }
        private int[] startPos { get; set; }
        private int[] currentPos { get; set; }
        private int battery { get; set; }


        public Rover(string name) { this.name = name; }

        public Rover(string[] data)
        {

        }
    }
}
