using System;
using System.Collections.Generic;
using System.Linq;

namespace CutTheRoots
{
    class CutTheRoots
    {
        public static void Main(string[] args)
        {
            int[] cuts = makeCuts(5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 0, 1, 2, 3, 4 });
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
                                XCoordinate = orderedPoints[i].XCoordinate,
                                YCoordinate = orderedPoints[i].YCoordinate + 1
                            },
                        EndPoint = new Point
                            {
                                XCoordinate = orderedPoints[i].XCoordinate,
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
