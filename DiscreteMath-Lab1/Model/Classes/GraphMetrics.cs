using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMath_Lab1
{
    class GraphMetrics
    {
        private int[,] matrix;

        public GraphMetrics(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public int FindRadius()
        {
            int[,] distances = CalculateDistances();

            int radius = int.MaxValue;
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                int maxDistance = 0;
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    if (distances[i, j] > maxDistance)
                    {
                        maxDistance = distances[i, j];
                    }
                }
                if (maxDistance < radius)
                {
                    radius = maxDistance;
                }
            }

            return radius;
        }

        public int FindDiameter()
        {
            int[,] distances = CalculateDistances();

            int diameter = 0;
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    if (distances[i, j] > diameter)
                    {
                        diameter = distances[i, j];
                    }
                }
            }

            return diameter;
        }

        public List<int> FindCentralVertices()
        {
            int radius = FindRadius();
            List<int> centralVertices = new List<int>();

            int[,] distances = CalculateDistances();
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                int maxDistance = 0;
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    if (distances[i, j] > maxDistance)
                    {
                        maxDistance = distances[i, j];
                    }
                }
                if (maxDistance == radius)
                {
                    centralVertices.Add(i);
                }
            }

            return centralVertices;
        }

        public List<int> FindPeripheralVertices()
        {
            int diameter = FindDiameter();
            List<int> peripheralVertices = new List<int>();

            int[,] distances = CalculateDistances();
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                int maxDistance = 0;
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    if (distances[i, j] > maxDistance)
                    {
                        maxDistance = distances[i, j];
                    }
                }
                if (maxDistance == diameter)
                {
                    peripheralVertices.Add(i);
                }
            }

            return peripheralVertices;
        }

        private int[,] CalculateDistances()
        {
            int n = matrix.GetLength(0);
            int[,] distances = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distances[i, j] = matrix[i, j];
                }
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distances[i, k] + distances[k, j] < distances[i, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }

            return distances;
        }
    }
}
