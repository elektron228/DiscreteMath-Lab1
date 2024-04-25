using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace DiscreteMath_Lab1
{
    /// <summary>
    /// Создан для работы с отрисовкой графа и его элементов.
    /// </summary>
    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 14; //радиус окружности вершины

        /// <summary>
        /// Создает экземпляр класса <see cref="DrawGraph"/>.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            ClearDrawinArea();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.DarkGoldenrod);
            darkGoldPen.Width = 2;
            fo = new Font("Arial", 10);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void ClearDrawinArea()
        {
            gr.Clear(Color.White);
        }

        /// <summary>
        /// Отрисовывает вершину.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="number"></param>
        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 7, y - 7);
            gr.DrawString(number, fo, br, point);
        }

        /// <summary>
        /// Окрашивает выбранную вершину при добавлении ребра.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        /// <summary>
        /// Отрисовывает ребро.
        /// </summary>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <param name="E"></param>
        /// <param name="numberE"></param>
        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            //Петля.
            if (E.Vertex1 == E.Vertex2)
            {
                gr.DrawArc(darkGoldPen, (V1.X - 2 * R), (V1.Y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.X - (int)(2.75 * R), V1.Y - (int)(2.75 * R));
                gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                drawVertex(V1.X, V1.Y, (E.Vertex1 + 1).ToString());
            }
            else
            {
                gr.DrawLine(darkGoldPen, V1.X, V1.Y, V2.X, V2.Y);
                point = new PointF((V1.X + V2.X) / 2, (V1.Y + V2.Y) / 2);
                gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                drawVertex(V1.X, V1.Y, (E.Vertex1 + 1).ToString());
                drawVertex(V2.X, V2.Y, (E.Vertex2 + 1).ToString());
            }
        }

        /// <summary>
        /// Отрисовывает граф.
        /// </summary>
        /// <param name="V"></param>
        /// <param name="E"></param>
        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //Рисует ребра.
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].Vertex1 == E[i].Vertex2)
                {
                    gr.DrawArc(darkGoldPen, (V[E[i].Vertex1].X - 2 * R), (V[E[i].Vertex1].Y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].Vertex1].X - (int)(2.75 * R), V[E[i].Vertex1].Y - (int)(2.75 * R));
                    gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                }
                else
                {
                    gr.DrawLine(darkGoldPen, V[E[i].Vertex1].X, V[E[i].Vertex1].Y, V[E[i].Vertex2].X, V[E[i].Vertex2].Y);
                    point = new PointF((V[E[i].Vertex1].X + V[E[i].Vertex2].X ) / 2, (V[E[i].Vertex1].Y + V[E[i].Vertex2].Y) / 2);
                    gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                }
            }
            //Рисует вершины.
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].X, V[i].Y, (i + 1).ToString());
            }
        }

        /// <summary>
        /// Заполняет матрицу смежности.
        /// </summary>
        /// <param name="numberV"></param>
        /// <param name="E"></param>
        /// <param name="matrix"></param>
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            //Очищаем матрицу.
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;
            //Заполняем матрицу.
            for (int i = 0; i < E.Count; i++)
            {
                //Если кратные ребра.
                if (matrix[E[i].Vertex1, E[i].Vertex2] >= 1)
                {
                    //Если это петля.
                    if (E[i].Vertex1 == E[i].Vertex2)
                    {
                        matrix[E[i].Vertex1, E[i].Vertex2]++;
                    }
                    else
                    {
                        matrix[E[i].Vertex1, E[i].Vertex2]++;
                        matrix[E[i].Vertex2, E[i].Vertex1]++;
                    }
                }
                else
                {
                    matrix[E[i].Vertex1, E[i].Vertex2] = 1;
                    matrix[E[i].Vertex2, E[i].Vertex1] = 1;
                }
            }
        }

        public int[,] CreateMetricsMatrix(int[,] adjacencyMatrix)
        {
            int n = adjacencyMatrix.GetLength(0);
            int[,] distanceMatrix = new int[n, n];

            // Инициализируем матрицу метрик значением int.MaxValue
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distanceMatrix[i, j] = int.MaxValue;
                }
            }

            // Заполняем матрицу метрик значениями из матрицы смежности
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        // Расстояние от вершины до самой себя равно 0
                        distanceMatrix[i, j] = 0;
                    }
                    else if (adjacencyMatrix[i, j] != 0)
                    {
                        // Расстояние от вершины до смежной вершины
                        distanceMatrix[i, j] = adjacencyMatrix[i, j];
                    }
                }
            }
            //Не учитываем кратные ребра. 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (adjacencyMatrix[i, j] >= 1)
                    {
                        // Расстояние от вершины до смежной вершины
                        distanceMatrix[i, j] = 1;
                    }
                }
            }

            // Используем алгоритм Флойда-Уоршелла для нахождения кратчайших путей между всеми парами вершин
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distanceMatrix[i, k] != int.MaxValue && distanceMatrix[k, j] != int.MaxValue &&
                            distanceMatrix[i, k] + distanceMatrix[k, j] < distanceMatrix[i, j])
                        {
                            distanceMatrix[i, j] = distanceMatrix[i, k] + distanceMatrix[k, j];
                        }
                    }
                }
            }

            return distanceMatrix;
        }

        /// <summary>
        /// Заполняет матрицу инцидентности.
        /// </summary>
        /// <param name="numberV"></param>
        /// <param name="E"></param>
        /// <param name="matrix"></param>
        public void fillIncidenceMatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            //Очищаем матрицу.
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < E.Count; j++)
                    matrix[i, j] = 0;
            //Заполняем матрицу.
            for (int i = 0; i < E.Count; i++)
            {
                //Если петля.
                if (E[i].Vertex1 == E[i].Vertex2)
                {
                    matrix[E[i].Vertex1, i] = 2;
                }
                else
                {
                    matrix[E[i].Vertex1, i] = 1;
                    matrix[E[i].Vertex2, i] = 1;
                }
            }
        }

        /// <summary>
        /// Алгоритм поиска максимального пустого подграфа в графе
        /// </summary>
        /// <param name="adjacencyMatrix">Матрица смежности графа</param>
        /// <returns>Список множеств вершин, представляющих пустые подграфы</returns>
        public List<HashSet<int>> FindMaxEmptySubgraph(int[,] adjacencyMatrix)
        {
            // Создание списка смежности для графа
            var adjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                adjacencyList[i] = new List<int>();
            }

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        adjacencyList[i].Add(j);
                        adjacencyList[j].Add(i);
                    }
                }
            }

            // Создание списка посещенных вершин
            var visited = new HashSet<int>();

            // Инициализация результата
            var emptySubgraphs = new List<HashSet<int>>();

            // Перебор всех вершин графа
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                if (!visited.Contains(i))
                {
                    // Поиск пустого подграфа, начинающегося с данной вершины
                    var emptySubgraph = FindEmptySubgraph(i, adjacencyList, visited);

                    // Добавление найденного пустого подграфа в результат
                    emptySubgraphs.Add(emptySubgraph);
                }
            }

            // Сортировка найденных пустых подграфов по убыванию размера
            emptySubgraphs.Sort((a, b) => b.Count - a.Count);

            // Возврат максимального по размеру пустого подграфа
            return emptySubgraphs;
        }

        /// <summary>
        /// Поиск пустого подграфа в графе, начинающегося с данной вершины
        /// </summary>
        /// <param name="vertex">Начальная вершина</param>
        /// <param name="adjacencyList">Список смежности для графа</param>
        /// <param name="visited">Список посещенных вершин</param>
        /// <returns>Множество вершин, представляющее пустой подграф</returns>
        private HashSet<int> FindEmptySubgraph(int vertex, Dictionary<int, List<int>> adjacencyList, HashSet<int> visited)
        {
            // Добавление вершины в список посещенных
            visited.Add(vertex);

            // Создание множества вершин, представляющее пустой подграф
            var emptySubgraph = new HashSet<int>();
            emptySubgraph.Add(vertex);

            // Перебор соседей вершины
            foreach (var neighbor in adjacencyList[vertex])
            {
                // Если сосед не был посещен
                if (!visited.Contains(neighbor))
                {
                    // Рекурсивный поиск пустого подграфа, начинающегося с соседа
                    var neighborEmptySubgraph = FindEmptySubgraph(neighbor, adjacencyList, visited);

                    // Объединение найденного пустого подграфа с текущим
                    emptySubgraph.UnionWith(neighborEmptySubgraph);
                }
            }

            // Возврат множества вершин, представляющее пустой подграф
            return emptySubgraph;
        }

        /// <summary>
        /// Алгоритм раскраски графа по матрице смежности
        /// </summary>
        /// <param name="adjacencyMatrix">Матрица смежности графа</param>
        /// <returns>Массив цветов, присвоенных вершинам графа</returns>
        public  int[] GraphColoring(int[,] adjacencyMatrix)
        {
            // Количество вершин в графе
            int n = adjacencyMatrix.GetLength(0);

            // Массив цветов, присвоенных вершинам
            int[] colors = new int[n];

            // Список доступных цветов
            List<int> availableColors = new List<int>();

            // Для каждой вершины
            for (int i = 0; i < n; i++)
            {
                // Получить список цветов, доступных для данной вершины
                availableColors.Clear();
                for (int j = 0; j < n; j++)
                {
                    if (adjacencyMatrix[i, j] >= 1 && colors[j] != 0)
                    {
                        availableColors.Add(colors[j]);
                    }
                }

                // Присвоить вершине первый доступный цвет
                int color = 1;
                while (availableColors.Contains(color))
                {
                    color++;
                }
                colors[i] = color;
            }

            // Возвратить массив цветов
            return colors;
        }





        /// <summary>
        /// Алгоритм Дейкстры для поиска кратчайшего пути между двумя заданными вершинами по матрице смежности
        /// </summary>
        /// <param name="adjacencyMatrix">Матрица смежности графа</param>
        /// <param name="startVertex">Начальная вершина</param>
        /// <param name="endVertex">Конечная вершина</param>
        /// <returns>Кратчайшее расстояние между двумя заданными вершинами</returns>
        public  int FindShortestPath(int[,] adjacencyMatrix, int startVertex, int endVertex)
        {
            // Количество вершин в графе
            int n = adjacencyMatrix.GetLength(0);

            // Создание массива расстояний
            int[] distances = new int[n];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[startVertex] = 0;

            // Создание очереди приоритетов
            var priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(startVertex, 0);

            // Пока очередь приоритетов не пуста
            while (priorityQueue.Count > 0)
            {
                // Извлечение вершины с минимальным расстоянием
                var currentVertex = priorityQueue.Dequeue();

                // Если текущая вершина - конечная вершина, то завершить алгоритм и вернуть расстояние
                if (currentVertex == endVertex)
                {
                    return distances[currentVertex];
                }

                // Обновление расстояний до соседних вершин
                for (int i = 0; i < n; i++)
                {
                    if (adjacencyMatrix[currentVertex, i] > 0)
                    {
                        int newDistance = distances[currentVertex] + adjacencyMatrix[currentVertex, i];
                        if (newDistance < distances[i])
                        {
                            distances[i] = newDistance;
                            priorityQueue.Enqueue(i, newDistance);
                        }
                    }
                }
            }

            // Если конечная вершина недостижима, то вернуть -1
            return -1;
        }

        /// <summary>
        /// Класс очереди приоритетов
        /// </summary>
        /// <typeparam name="TPriority">Тип приоритета</typeparam>
        /// <typeparam name="TValue">Тип значения</typeparam>
        private class PriorityQueue<TPriority, TValue>
        {
            private SortedDictionary<TPriority, Queue<TValue>> _queue = new SortedDictionary<TPriority, Queue<TValue>>();

            /// <summary>
            /// Добавление элемента в очередь
            /// </summary>
            /// <param name="priority">Приоритет</param>
            /// <param name="value">Значение</param>
            public void Enqueue(TPriority priority, TValue value)
            {
                if (!_queue.ContainsKey(priority))
                {
                    _queue[priority] = new Queue<TValue>();
                }
                _queue[priority].Enqueue(value);
            }

            /// <summary>
            /// Извлечение элемента с минимальным приоритетом
            /// </summary>
            /// <returns>Значение элемента с минимальным приоритетом</returns>
            public TValue Dequeue()
            {
                if (_queue.Count == 0)
                {
                    throw new InvalidOperationException("Очередь пуста");
                }

                var minPriority = _queue.First().Key;
                var value = _queue[minPriority].Dequeue();

                if (_queue[minPriority].Count == 0)
                {
                    _queue.Remove(minPriority);
                }

                return value;
            }

            /// <summary>
            /// Количество элементов в очереди
            /// </summary>
            public int Count => _queue.Values.Sum(q => q.Count);
        }
    }
}
