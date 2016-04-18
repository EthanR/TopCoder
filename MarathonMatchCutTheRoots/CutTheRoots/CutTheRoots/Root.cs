using System;

namespace CutTheRoots
{
    public class Root
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double Length 
        {
            get
            {
                // slope for distance of line between StartPoint and EndPoint. 
                return (StartPoint.XCoordinate - EndPoint.XCoordinate) / (EndPoint.YCoordinate - StartPoint.YCoordinate);
            }
        }
    }
}

