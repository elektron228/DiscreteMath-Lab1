    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMath_Lab1
{
    /// <summary>
    /// Хранит информацию о вершине.
    /// </summary>
    class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        } 
    }
}
