using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMath_Lab1
{
    /// <summary>
    /// Хранит информацию о ребре.
    /// </summary>
    class Edge
    {
        public int Vertex1 {  get; set; }
        public int Vertex2 { get; set; }

        public Edge(int v1, int v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
        }
    }
}
