using System;
using System.Collections.Generic;

namespace CutTheRoots
{
    public class Point
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public List<Root> ConnectedRoots { get; set; }
        public bool IsBase { get; set; }
        public Point MyBasePoint { get; set; }
    }
}

