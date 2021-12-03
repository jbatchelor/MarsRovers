using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    internal class SearchGrid
    {
        public int xSize
        { get; set; }
        public int ySize
        { get; set; }

        public SearchGrid(int intXSize, int intYSize)
        {
            xSize = intXSize;
            ySize = intYSize;
        }
    }
}
