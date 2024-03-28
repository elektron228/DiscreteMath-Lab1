using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMath_Lab1
{
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
        /// Рисует вершину.
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
    }
}
