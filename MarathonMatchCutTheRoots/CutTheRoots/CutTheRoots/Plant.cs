using System;
using System.Collections.Generic;
using System.Linq;

namespace CutTheRoots
{
    public class Plant
    {
        public Point BasePoint { get; set; }
        public List<Point> Points { get; set; }
        public List<Root> Roots { get; set; }
        public double LengthOfRoots
        {
            get
            {
                return Roots.Select(root => root.Length).Sum();
            }
        }
    }
}

