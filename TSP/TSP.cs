using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TSP
{
    enum Mode { REAL_MAP, RANDOM };
    
    public partial class MainForm : Form
    {
        public Graphics canvas;
        WUGraph graph;
        Bitmap bitmapCanvas;
        Mode mode;
        Bitmap map;
        int count;
        bool enteringFromTable;
        string fname;
        int fileIndex;
        string[] table;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = this.CreateGraphics();
            
            bitmapCanvas = new Bitmap(this.Width, this.Height);
            canvasPictureBox.Image = bitmapCanvas;
            mode = Mode.RANDOM;
            count = 0;
            buttonRandomMode.Text = "*Random";
            enteringFromTable = false;
            fileIndex = 0;
            graph = null;
        }

        private void _TableFill()
        {
            dataGridView1.Rows.Clear();

            int rowIndex = 0;
            for (int i = 0; i < graph.GetVerticesNumber(); i++)
            {
                for (int j = 0; j < graph.GetVerticesNumber(); j++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = graph.GetVerticeName(i);
                    dataGridView1.Rows[rowIndex].Cells[1].Value = graph.GetVerticeName(j);
                    dataGridView1.Rows[rowIndex].Cells[2].Value = graph.EdgeWeight(i, j).ToString();
                    rowIndex++;
                }
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            graph = new WUGraph(Convert.ToInt32(verticesNumTextBox.Text));
            graph.GenerateRandom(Convert.ToInt16(verticesNumTextBox.Lines[0]));
            
            graph.Draw(bitmapCanvas, canvasPictureBox);
            pathWeightTextBox.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            _TableFill();
            dataGridView1.Update();
        }

        private void drawPathButton_Click(object sender, EventArgs e)
        {
            
            WUGraphPath path = new WUGraphPath(Convert.ToInt32(graph.GetVerticesNumber()));
            path.GenerateRandomPath();

            canvas.Clear(SystemColors.Control);

            if (mode == Mode.RANDOM)
            {
                pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
            }
            else
            {
                pathWeightTextBox.Text = (graph.DrawPathOnMap(path, canvas, new Bitmap(map), canvasPictureBox).ToString());
            }
        }

        private void mCBEbutton_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            if (mode == Mode.RANDOM)
            {
                    pathWeightTextBox.Text = (graph.DrawPath(graph.MCE(Convert.ToInt32(threadsTextBox.Text),
                                             Convert.ToInt64(experimentsTextBox.Text)), bitmapCanvas, canvasPictureBox).ToString());

            }
            else
            {
                pathWeightTextBox.Text = (graph.DrawPathOnMap(graph.MCE(Convert.ToInt32(threadsTextBox.Text),
                                             Convert.ToInt32(experimentsTextBox.Text)), canvas, new Bitmap(map), canvasPictureBox).ToString());
            }

            stopwatch.Stop();

            textBoxTime.Text = stopwatch.ElapsedMilliseconds.ToString();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                graph.EdgeAdd(graph.GetVerticeIndex(dataGridView1.Rows[i].Cells[0].Value.ToString()),
                              graph.GetVerticeIndex(dataGridView1.Rows[i].Cells[1].Value.ToString()),
                              Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value));
            }
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            string mapPath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            mapPath = ofd.FileName;
            map = new Bitmap(mapPath);
            canvasPictureBox.Image = map;
        }

        private void canvasPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == Mode.REAL_MAP)
            {
                
                if (enteringFromTable == false)
                {
                    if (graph == null)
                    {
                        graph = new WUGraph(0);
                    }
        
                    Bitmap bitmap = new Bitmap(canvasPictureBox.Image);
                    Graphics canvas0 = Graphics.FromImage(bitmap);
                    canvasPictureBox.Image = bitmap;
                    canvas0.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);

                    Font font = new Font("Arial", 12);
                    System.Drawing.SolidBrush brush = new SolidBrush(Color.Blue);
                    canvas0.DrawString(count.ToString(), font, brush, e.X + 10, e.Y - 10);

                    graph.VerticeAdd(e.X, e.Y, textBoxNewVertice.Text);

                    count++;
                }
                else
                {
                    Bitmap bitmap = new Bitmap(canvasPictureBox.Image);
                    Graphics canvas0 = Graphics.FromImage(bitmap);
                    canvasPictureBox.Image = bitmap;
                    canvas0.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);
                    System.Drawing.SolidBrush brush = new SolidBrush(Color.Blue);

                    int buffer;
                    if (fileIndex+1 < table.Count() && !int.TryParse(table[fileIndex+1], out buffer)) { 
                        graph.VerticeAdd(e.X, e.Y, table[fileIndex]);
                        dataGridView1.Rows.Add(table[fileIndex], table[fileIndex], 0);
                        fileIndex++;
                        dataGridView1.Update();
                    }
                    else {
                        fileIndex++;

                        for (int j = 0; j < graph.GetVerticesNumber()  && fileIndex  < table.Count(); j++)
                        {
                            for (int k = j + 1; k < graph.GetVerticesNumber(); k++)
                            {
                                WUGraphEdge edge = new WUGraphEdge(j, k, Convert.ToInt32(table[fileIndex]));
                                graph.EdgeAdd(j, k, Convert.ToInt32(table[fileIndex]));
                                WUGraphEdge edge2 = new WUGraphEdge(k, j, Convert.ToInt32(table[fileIndex]));
                                graph.EdgeAdd(k, j, Convert.ToInt32(table[fileIndex]));
                                fileIndex++;
                            }
                            fileIndex++;
                        }
                    }
                    dataGridView1.Update(); 
                }
            }
        }

        private void buttonMapMode_Click(object sender, EventArgs e)
        {
            mode = Mode.REAL_MAP;
            buttonLoadImage.Enabled = true;
            buttonMapMode.Text = "*Map";
            buttonRandomMode.Text = "Random";
            buttonGARun.Enabled = true;
            drawPathButton.Enabled = true;
            mCBEbutton.Enabled = true;
        }

        private void buttonRandomMode_Click(object sender, EventArgs e)
        {
            mode = Mode.RANDOM;
            buttonLoadImage.Enabled = false;
            buttonRandomMode.Text = "*Random";
            buttonMapMode.Text = "Map";
        }

        private void verticesNumTextBox_TextChanged(object sender, EventArgs e)
        {
            int i;

            if (int.TryParse(verticesNumTextBox.Text, out i) && i > 0)
            {
                generateButton.Enabled = true;
            }
            else
            {
                generateButton.Enabled = false;
            }
        }

        private void buttonGARun_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            if (mode == Mode.RANDOM)
            {
                pathWeightTextBox.Text = (graph.DrawPath(graph.GA(Convert.ToInt32(textBoxGAThredsNum.Text),
                                                                  Convert.ToInt32(textBoxGenerationCap.Text),
                                                                  Convert.ToInt64(textBoxIterations.Text)),
                                                                  bitmapCanvas,
                                                                  canvasPictureBox).ToString());
            }
            else
            {
                pathWeightTextBox.Text = (graph.DrawPathOnMap(graph.GA(Convert.ToInt32(textBoxGAThredsNum.Text),
                                                                  Convert.ToInt32(textBoxGenerationCap.Text),
                                                                  Convert.ToInt64(textBoxIterations.Text)),
                                                                  canvas, new Bitmap(map), canvasPictureBox).ToString());
            }

            stopwatch.Stop();

            textBoxTime.Text = stopwatch.ElapsedMilliseconds.ToString();
        }

        private void buttonAutoGraph_Click(object sender, EventArgs e)
        {
            graph.GenerateEdges();
            _TableFill();
            dataGridView1.Update();
        }

        private void buttonLoadTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog d;
            d = new OpenFileDialog();
            d.ShowDialog();
            fname = d.FileName;
            table = System.IO.File.ReadAllLines(fname);
            enteringFromTable = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _TableFill();
            dataGridView1.Update();
            enteringFromTable = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chromosome path1 = new Chromosome(Convert.ToInt32(verticesNumTextBox.Text));
            path1.GenerateRandomPath();
            string path1s = "";
            for(int i = 0; i < Convert.ToInt32(verticesNumTextBox.Text); i++)
            {
                path1s += "(" + i.ToString() + "," + path1.pathIndexes[i].ToString() + ")";

            }
            Chromosome path2 = new Chromosome(Convert.ToInt32(verticesNumTextBox.Text));
            path2.GenerateRandomPath();
            string path2s = "";
            for (int i = 0; i < Convert.ToInt32(verticesNumTextBox.Text); i++)
            {
                path2s += "(" + i.ToString() + "," + path2.pathIndexes[i].ToString() + ")";

            }
            
            Chromosome path = new Chromosome(Convert.ToInt32(verticesNumTextBox.Text));
            path = path1.Crossingover(path2);
            //path.Mutate();
            string paths = "";
            for (int i = 0; i < Convert.ToInt32(verticesNumTextBox.Text); i++)
            {
                paths += "(" + i.ToString() + "," + path.pathIndexes[i].ToString() + ")";

            }
            MessageBox.Show(path1s + "+" + path2s + "=" +paths);
            pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
        }

        private void buttonSaveGraph_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.ShowDialog();
            graph.SafeToFile(d.FileName);
        }

        private void buttonLoadFromFile_Click(object sender, EventArgs e)
        {
            graph = new WUGraph(0);
            OpenFileDialog d = new OpenFileDialog();
            d.ShowDialog();
            graph.ReadFromFile(d.FileName);

            if (mode == Mode.RANDOM) {
                graph.Draw(bitmapCanvas, canvasPictureBox);
            }
            else
            {
                graph.DrawOnMap(canvas, new Bitmap(map), canvasPictureBox);
            }
            _TableFill();
        }

        private void buttonSymmetry_Click(object sender, EventArgs e)
        {
            graph.Symmetry();
            _TableFill();
            dataGridView1.Update();
        }

    }
}
