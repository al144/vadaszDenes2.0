using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.XPath;

namespace vadaszDenes
{

    internal class RoutePlanner
    {
        private class Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public float G { get; set; }
            public float H { get; set; }
            public float F => G + H;
            public Node Parent { get; set; }

            public Node(int x, int y)
            {
                X = x;
                Y = y;
                G = 0;
                H = 0;
                Parent = null;
            }
        }

        public List<(int x, int y)> AStar(
            int startX, int startY,
            int targetX, int targetY,
            int batteryLeft,
            Map map,
            bool isDaytime)
        {
            List<Node> openList = new List<Node>();
            HashSet<(int, int)> closedList = new HashSet<(int, int)>();

            Node startNode = new Node(startX, startY);
            startNode.H = Heuristic(startX, startY, targetX, targetY);
            openList.Add(startNode);

            while (openList.Count() > 0)
            {
                Node current = openList.OrderBy(n => n.F).First();

                if (current.X == targetX && current.Y == targetY)
                {
                    return ReconstructPath(current);
                }

                openList.Remove(current);
                closedList.Add((current.X, current.Y));


                foreach (var neighbor in GetNeighbors(current.X, current.Y, map))
                {
                    if (closedList.Contains(neighbor)) continue;

                }
            }

            return null; // ideiglenes
        }

        private List<(int x, int y)> GetNeighbors(int x, int y, Map map)
        {
            var neighbors = new List<(int, int)>();

            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                
                if (newX >= 0 && newX < 50 && newY >= 0 && newY < 50 && map.Grid[newX,newY] != '#')
                {
                    neighbors.Add((newX, newY));
                }
            }

            return neighbors;
        }
        private float Heuristic(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private float CalculateEnergy(int x1, int y1, int x2, int y2, bool isDaytime)
        {
            float distance = (x1 == x2 || y1 == y2) ? 1f : 1.414f;

            return 0;
        }

        private List<(int x, int y)> ReconstructPath(Node destinations)
        {
            var route = new List<(int x, int y)>();
            Node current = destinations;

            while (current != null)
            {
                route.Insert(0, (current.X, current.Y));
                current = current.Parent;
            }

            return route;
        }
    }
}



