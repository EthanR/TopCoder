using System;
using System.Collections.Generic;
using System.Linq;

namespace CutTheRoots
{
    class CutTheRoots
    {
        public static void Main(string[] args)
        {
            int[] testPoints =
            {
                 0, 0,   11, 11,   22, 22,   33, 33,   44, 44,                      
                 1, 1,   12, 12,   23, 23,   34, 34,   45, 45,
                 2, 2,   13, 13,   24, 24,   35, 35,   46, 46,
                 3, 3,   14, 14,   25, 25,   36, 36,   47, 47,
                 4, 4,   15, 15,   26, 26,   37, 37,   48, 48,
                 5, 5,   16, 16,   27, 27,   38, 38,   49, 49,
                 6, 6,   17, 17,   28, 28,   39, 39,   50, 50,
                 7, 7,   18, 18,   29, 29,   40, 40,   51, 51,
                 8, 8,   19, 19,   30, 30,   41, 41,   52, 52,
                 9, 9,   20, 20,   31, 31,   42, 42,   53, 53,
               10, 10,   21, 21,   32, 32,   43, 43,   54, 54
            };

            int [] testRoots =
            {
               0, 5,   5, 10,   10, 15,   15, 20,   20, 25,   25, 30,   30, 35,   35, 40,   40, 45,   45, 50,
               1, 6,   6, 11,   11, 16,   16, 21,   21, 26,   26, 31,   31, 36,   36, 41,   41, 46,   46, 51,
               2, 7,   7, 12,   12, 17,   17, 22,   22, 27,   27, 32,   32, 37,   37, 42,   42, 47,   47, 52,
               3, 8,   8, 13,   13, 18,   18, 23,   23, 28,   28, 33,   33, 38,   38, 43,   43, 48,   48, 53,
               4, 9,   9, 14,   14, 19,   19, 24,   24, 29,   29, 34,   34, 39,   39, 44,   44, 49,   49, 54 
            };

            int[] cuts = makeCuts(5, testPoints, testRoots);
            foreach (int cut in cuts)
            {
                Console.WriteLine(cut);
            }
        }

        public static int[] makeCuts(int NP, int[] points, int[] roots)
        {
            int numberOfPlants = NP;
            List<Point> normalizedPoints = new List<Point>();
            List<Root> normalizedRoots = new List<Root>();
            List<Cut> cuts = new List<Cut>();
            List<int> results = new List<int>();

            for (int i = 0; i < points.Length - 1; i += 2)
            {
                normalizedPoints.Add(new Point
                    {
                        XCoordinate = points[i],
                        YCoordinate = points[i+1],
                        IsBase = i < numberOfPlants * 2,
                        ConnectedRoots = new List<Root>()
                    });
            }

            for (int i = 0; i < roots.Length - 1; i += 2)
            {
                normalizedRoots.Add(new Root
                    {
                        StartPoint = normalizedPoints[roots[i]],
                        EndPoint = normalizedPoints[roots[i + 1]]
                    });
            }

            foreach (Point point in normalizedPoints)
            {
                List<Root> connectedRoots = normalizedRoots.Where(root => root.StartPoint == point).ToList();
                point.ConnectedRoots.AddRange(connectedRoots);
            }

            List<Point> orderedPoints = normalizedPoints.Where(normalPoint => normalPoint.IsBase)
                .OrderBy(normalPoint => normalPoint.XCoordinate)
                .ThenBy(normalPoint => normalPoint.YCoordinate).ToList();

            for (int i = 0; i < orderedPoints.Count - 1; i++)
            {
                cuts.Add(new Cut
                    {
                        StartPoint = new Point
                            {
                                XCoordinate = orderedPoints[i].XCoordinate + 1,
                                YCoordinate = orderedPoints[i].YCoordinate + 1
                            },
                        EndPoint = new Point
                            {
                                XCoordinate = orderedPoints[i].XCoordinate + 1,
                                YCoordinate = orderedPoints[i].YCoordinate - 1
                            }
                    });
            }

            foreach (Cut cut in cuts)
            {
                results.Add(cut.StartPoint.XCoordinate);
                results.Add(cut.StartPoint.YCoordinate);
                results.Add(cut.EndPoint.XCoordinate);
                results.Add(cut.EndPoint.YCoordinate);
            }

            return results.ToArray();
        }
    }
}
