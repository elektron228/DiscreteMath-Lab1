using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Configuration;

namespace DiscreteMath_Lab1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(DrawingAreaPictureBox.Width, DrawingAreaPictureBox.Height);
            E = new List<Edge>();
            DrawingAreaPictureBox.Image = G.GetBitmap();
            GraphSizeComboBox.DataSource = ints;
        }
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;

        int[] ints = new int[5] {2,3,4,5,6};
        //Матрица смежности.
        int[,] AMatrix;
        //Матрица инцидентности.
        int[,] IMatrix;

        //Выбранные вершины, для соединения линиями.
        int selected1; 
        int selected2;


        private void SelectButton_Click(object sender, EventArgs e)
        {
            DrawVertexButton.Enabled = true;
            DrawEdgeButton.Enabled = true;
            DeleteElementButton.Enabled = true;
            G.ClearDrawinArea();
            G.drawALLGraph(V, E);
            DrawingAreaPictureBox.Image = G.GetBitmap();
            selected1 = -1;
        }

        private void DrawVertexButton_Click(object sender, EventArgs e)
        {
            DrawVertexButton.Enabled = false;
            DrawEdgeButton.Enabled = true;
            DeleteElementButton.Enabled = true;
            G.ClearDrawinArea();
            G.drawALLGraph(V, E);
            DrawingAreaPictureBox.Image = G.GetBitmap();
        }

        private void DrawEdgeButton_Click(object sender, EventArgs e)
        {
            DrawEdgeButton.Enabled = false;
            DrawVertexButton.Enabled = true;
            DeleteElementButton.Enabled = true;
            G.ClearDrawinArea();
            G.drawALLGraph(V, E);
            DrawingAreaPictureBox.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        private void DeleteElementButton_Click(object sender, EventArgs e)
        {
            DeleteElementButton.Enabled = false;
            DrawVertexButton.Enabled = true;
            DrawEdgeButton.Enabled = true;
            G.ClearDrawinArea();
            G.drawALLGraph(V, E);
            DrawingAreaPictureBox.Image = G.GetBitmap();
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            DrawVertexButton.Enabled = true;
            DrawEdgeButton.Enabled = true;
            DeleteElementButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.ClearDrawinArea();
                DrawingAreaPictureBox.Image = G.GetBitmap();
            }
        }

        private void CreateAdjMatrButton_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        private void CreateIncMatrButton_Click(object sender, EventArgs e)
        {
            createIncAndOut();
        }

        /// <summary>
        /// Создаёт матрицу смежности и выводит в листбокс.
        /// </summary>
        private void createAdjAndOut()
        {
            AMatrix = new int[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
            MatrixListBox.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < V.Count; i++)
                sOut += (i + 1) + " ";
            MatrixListBox.Items.Add(sOut);
            for (int i = 0; i < V.Count; i++)
            {
                sOut = (i + 1) + " | ";
                for (int j = 0; j < V.Count; j++)
                    sOut += AMatrix[i, j] + " ";
                MatrixListBox.Items.Add(sOut);
            }
        }

        /// <summary>
        /// Создает матрицу инцидентности и выводит в листбокс.
        /// </summary>
        private void createIncAndOut()
        {
            if (E.Count > 0)
            {
                IMatrix = new int[V.Count, E.Count];
                G.fillIncidenceMatrix(V.Count, E, IMatrix);
                MatrixListBox.Items.Clear();
                string sOut = "    ";
                for (int i = 0; i < E.Count; i++)
                    sOut += (char)('a' + i) + " ";
                MatrixListBox.Items.Add(sOut);
                for (int i = 0; i < V.Count; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < E.Count; j++)
                        sOut += IMatrix[i, j] + " ";
                    MatrixListBox.Items.Add(sOut);
                }
            }
            else
                MatrixListBox.Items.Clear();
        }


        private void DrawingAreaPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            
            //Если нажата кнопка "рисовать вершину".
            if (DrawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                DrawingAreaPictureBox.Image = G.GetBitmap();
            }
            //Если нажата кнопка "рисовать ребро".
            if (DrawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].X, V[i].Y);
                                selected1 = i;
                                DrawingAreaPictureBox.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].X, V[i].Y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                selected1 = -1;
                                selected2 = -1;
                                DrawingAreaPictureBox.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].X - e.X), 2) + Math.Pow((V[selected1].Y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].X, V[selected1].Y, (selected1 + 1).ToString());
                        selected1 = -1;
                        DrawingAreaPictureBox.Image = G.GetBitmap();
                    }
                }
            }
            //Если нажата кнопка "удалить элемент".
            if (DeleteElementButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику.
                //Если была нажата вершина.
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].Vertex1 == i) || (E[j].Vertex2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].Vertex1 > i) E[j].Vertex1--;
                                if (E[j].Vertex2 > i) E[j].Vertex2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //Если было нажато ребро.
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        //Если это петля.
                        if (E[i].Vertex1 == E[i].Vertex2) 
                        {
                            if ((Math.Pow((V[E[i].Vertex1].X - G.R - e.X), 2) + Math.Pow((V[E[i].Vertex1].Y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].Vertex1].X - G.R - e.X), 2) + Math.Pow((V[E[i].Vertex1].Y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        //Не петля.
                        else
                        {
                            if (((e.X - V[E[i].Vertex1].X) * (V[E[i].Vertex2].Y - V[E[i].Vertex1].Y) / (V[E[i].Vertex2].X - V[E[i].Vertex1].X) + V[E[i].Vertex1].Y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].Vertex1].X) * (V[E[i].Vertex2].Y - V[E[i].Vertex1].Y) / (V[E[i].Vertex2].X - V[E[i].Vertex1].X) + V[E[i].Vertex1].Y) >= (e.Y - 4))
                            {
                                if ((V[E[i].Vertex1].X <= V[E[i].Vertex2].X && V[E[i].Vertex1].X <= e.X && e.X <= V[E[i].Vertex2].X) ||
                                    (V[E[i].Vertex1].X >= V[E[i].Vertex2].X && V[E[i].Vertex1].X >= e.X && e.X >= V[E[i].Vertex2].X))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //Если что-то было удалено, то обновляем граф на экране.
                if (flag)
                {
                    G.ClearDrawinArea();
                    G.drawALLGraph(V, E);
                    DrawingAreaPictureBox.Image = G.GetBitmap();
                }
            }
        }

        private void SimpleGraphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SimpleGraphCheckBox.Checked)
            {
                LoopGraphCheckBox.Checked = false;
                LoopGraphCheckBox.Enabled = false;
                MultyGraphCheckBox.Checked = false;
                MultyGraphCheckBox.Enabled = false;
            }
            else
            {
                LoopGraphCheckBox.Enabled = true;
                MultyGraphCheckBox.Enabled = true;
            }
        }

        private void LoopGraphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LoopGraphCheckBox.Checked)
            {
                SimpleGraphCheckBox.Checked= false;
                SimpleGraphCheckBox.Enabled= false;
            }
            else if (!MultyGraphCheckBox.Checked && !FullGraphCheckBox.Checked)
            {
                SimpleGraphCheckBox.Enabled = true;
            }
        }

        private void MultyGraphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MultyGraphCheckBox.Checked)
            {
                SimpleGraphCheckBox.Checked = false;
                SimpleGraphCheckBox.Enabled = false;
            }
            else if (!LoopGraphCheckBox.Checked && !FullGraphCheckBox.Checked)
            {
                SimpleGraphCheckBox.Enabled = true;
            }
        }

        private void FullGraphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FullGraphCheckBox.Checked)
            {
                SimpleGraphCheckBox.Checked = false;
                SimpleGraphCheckBox.Enabled = false;
            }
            else if (!LoopGraphCheckBox.Checked && !MultyGraphCheckBox.Checked)
            {
                SimpleGraphCheckBox.Enabled = true;
            }
        }

        private void GenerateRandomGraphButton_Click(object sender, EventArgs e)
        {
            //Очищаем все поля.
            V.Clear();
            E.Clear();
            G.ClearDrawinArea();
            DrawingAreaPictureBox.Image = G.GetBitmap();

            int selectedSize = Int32.Parse(GraphSizeComboBox.SelectedItem.ToString());
            int x, y;
            Random rand = new Random();

            if (FullGraphCheckBox.Checked)
            {
                if (LoopGraphCheckBox.Checked && MultyGraphCheckBox.Checked)
                {
                    //Generate full graph.
                    for (int i = 0; i < selectedSize; ++i)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        for (int j = i + 1; j < selectedSize; j++)
                        {
                            E.Add(new Edge(i, j));
                        }
                    }
                    //Add loops.
                    for (int i = 0; i < selectedSize; i++)
                    {
                        int choise = rand.Next(0, 2);
                        if (choise == 1)
                        {
                            E.Add(new Edge(i, i));
                        }
                    }
                    //Add multyplicities.
                    for (int i = 0; i < 5; i++)
                    {
                        int firstNumb = rand.Next(selectedSize);
                        int secondNumb = rand.Next(selectedSize);
                        while (firstNumb == secondNumb)
                        {
                            secondNumb = rand.Next(selectedSize);
                        }
                        E.Add(new Edge(firstNumb, secondNumb));
                    }
                    G.drawALLGraph(V, E);
                }
                else if (LoopGraphCheckBox.Checked && !MultyGraphCheckBox.Checked)
                {
                    //Generate full graph.
                    for (int i = 0; i < selectedSize; ++i)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        for (int j = i + 1; j < selectedSize; j++)
                        {
                            E.Add(new Edge(i, j));
                        }
                    }
                    //Add loops.
                    for (int i = 0; i < selectedSize ; i++)
                    {
                        int choise = rand.Next(0, 2);
                        if (choise == 1)
                        {
                            E.Add(new Edge(i, i));
                        }
                    }
                    G.drawALLGraph(V, E);
                }
                else if (!LoopGraphCheckBox.Checked && MultyGraphCheckBox.Checked)
                {
                    //Generate full graph.
                    for (int i = 0; i < selectedSize; ++i)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        for (int j = i + 1; j < selectedSize; j++)
                        {
                            E.Add(new Edge(i, j));
                        }
                    }
                    //Add multiplicities.
                    for (int i = 0; i < 5; i++)
                    {
                        int firstNumb = rand.Next(selectedSize);
                        int secondNumb = rand.Next(selectedSize);
                        while (firstNumb == secondNumb)
                        {
                            secondNumb = rand.Next(selectedSize);
                        }
                        E.Add(new Edge(firstNumb, secondNumb));
                    }
                    G.drawALLGraph(V, E);
                }
                else if (!MultyGraphCheckBox.Checked && !LoopGraphCheckBox.Checked)
                {
                    //Generate full graph.
                    for (int i = 0; i < selectedSize; ++i)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        for (int j = i + 1; j < selectedSize; j++)
                        {
                            E.Add(new Edge(i, j));
                        }
                    }
                    G.drawALLGraph(V, E);
                }
            }
            else if (SimpleGraphCheckBox.Checked)
            {
                //Generate simple graph.
                for (int i = 0; i < selectedSize; i++)
                {
                    x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                    y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                    V.Add(new Vertex(x, y));
                    for (int j = i - 1;j < selectedSize; j++)
                    {
                        if (V.Count == 1)
                        {
                            break;
                        }
                        E.Add(new Edge(j, i ));
                        break;
                    }
                }
                
                G.drawALLGraph(V, E);
            }
            else if (MultyGraphCheckBox.Checked)
            {
                if (LoopGraphCheckBox.Checked)
                {
                    //Generate graph with loops and multiplicities.
                    for (int i = 0; i < selectedSize; i++)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        E.Add(new Edge(rand.Next(selectedSize), rand.Next(selectedSize)));
                    }
                    G.drawALLGraph(V, E);
                }
                else if (!LoopGraphCheckBox.Checked)
                {
                    //Generate graph with multiplicities.
                    for (int i = 0; i < selectedSize; i++)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                    }
                    for (int i = 0; i < rand.Next(6, 10); i++)
                    {
                        int firstNumb = rand.Next(selectedSize);
                        int secondNumb = rand.Next(selectedSize);
                        while (firstNumb == secondNumb)
                        {
                            secondNumb = rand.Next(selectedSize);
                        }
                        E.Add(new Edge(firstNumb, secondNumb));
                    }
                    G.drawALLGraph(V, E);
                }
            }
            else if (LoopGraphCheckBox.Checked)
            {
                //Generate graph with loops and multiplicities.
                if (MultyGraphCheckBox.Checked)
                {
                    for (int i = 0; i < selectedSize; i++)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        E.Add(new Edge(rand.Next(selectedSize), rand.Next(selectedSize)));
                    }
                    G.drawALLGraph(V, E);
                }
                //Generate graph with loops.
                else if (!MultyGraphCheckBox.Checked)
                {
                    for (int i = 0; i < selectedSize; i++)
                    {
                        x = rand.Next(15, DrawingAreaPictureBox.Size.Width - 15);
                        y = rand.Next(15, DrawingAreaPictureBox.Size.Height - 15);
                        V.Add(new Vertex(x, y));
                        for (int j = i - 1; j < selectedSize; j++)
                        {
                            if (V.Count == 1)
                            {
                                break;
                            }
                            E.Add(new Edge(j, i));
                            break;
                        }
                    }
                    for (int i = 0; i < selectedSize ; i++)
                    {
                        int choise = rand.Next(0, 2);
                        if (choise == 1)
                        {
                            E.Add(new Edge(i, i));
                        }
                    }
                    G.drawALLGraph(V, E);
                }

            }
            

        }
        

    }
}
