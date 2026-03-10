using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace vadaszDenes
{
    class Map
    {
        public char[,] Grid {  get; private set; }
        public int[] StartPosition { get; private set; }
        public int BlueCrystals { get; private set; }
        public int YellowCrystals { get; private set; }
        public int GreenCrystals { get; private set; }
        public int AllCrystals => BlueCrystals + YellowCrystals + GreenCrystals;

        public Map(string[] map)
        {
            Grid = new char[50,50];
            BlueCrystals = 0;
            YellowCrystals = 0;
            GreenCrystals = 0;
            StartPosition = new int[2] { -1, -1 };

            for (int y = 0; y < map.Length; y++)
            {
                string line = map[y].Replace(",", "");
                for (int x = 0; x < line.Length; x++)
                {
                    Grid[x, y] = line[x];
                    switch (line[x])
                    {
                        case 'B': BlueCrystals++; break;
                        case 'Y': YellowCrystals++; break;
                        case 'G': GreenCrystals++; break;
                        case 'S': StartPosition = new int[] { x, y }; break;
                    }

                }
            }
            MessageBox.Show($"{AllCrystals}");
        }

    }
}
