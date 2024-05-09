using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMath_Lab1
{
    class DijkstraAlg
    {
        // Метод для преобразования матрицы смежности в весовую матрицу
        public int[,] ConvertToWeightedMatrix(int[,] adjacencyMatrix)
        {
            int size = adjacencyMatrix.GetLength(0);
            int[,] weightedMatrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[i, j] == 1) // Если есть ребро между вершинами
                    {
                        weightedMatrix[i, j] = random.Next(1, 10); // Задаем случайный вес
                    }
                    else
                    {
                        weightedMatrix[i, j] = 0; // Вес равен 0, если нет ребра
                    }
                }
            }

            return weightedMatrix;
        }

        // Алгоритм Дейкстры для нахождения кратчайшего расстояния между вершинами
        public int Dijkstra(int[,] weightedMatrix, int start, int end)
        {
            int size = weightedMatrix.GetLength(0);
            bool[] visited = new bool[size];
            int[] distance = new int[size];

            for (int i = 0; i < size; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[start] = 0;

            for (int i = 0; i < size - 1; i++)
            {
                int minDistance = int.MaxValue;
                int minIndex = -1;

                for (int v = 0; v < size; v++)
                {
                    if (!visited[v] && distance[v] < minDistance)
                    {
                        minDistance = distance[v];
                        minIndex = v;
                    }
                }

                visited[minIndex] = true;

                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] && weightedMatrix[minIndex, j] != 0 && distance[minIndex] != int.MaxValue &&
                        distance[minIndex] + weightedMatrix[minIndex, j] < distance[j])
                    {
                        distance[j] = distance[minIndex] + weightedMatrix[minIndex, j];
                    }
                }
            }

            return distance[end];
        }
    }
}
