using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM686
{
    public class TreeAndVertex
    {
        static void Main(string[] args)
        {
            int[] tree = {0, 0, 0};
            Console.WriteLine(get(tree));
        }

        public static int get(int[] tree)
        {
            int firstVertex = tree[0];
            int result;

            IEnumerable<IGrouping<int,int>> groups = tree.GroupBy(x => x);
            IGrouping<int, int> largest = groups.OrderByDescending(x => x.Count()).First();

            if (tree.All(vertex => vertex == firstVertex))
            {
                result = largest.Count();
            }
            else
            {
                result = largest.Count() + 1;
            }

            return result;
        }
    }
}
