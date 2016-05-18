﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = this.CreateGraphics();
            graph = new WUGraph();
            bitmapCanvas = new Bitmap(this.Width, this.Height - 225);
            canvasPictureBox.Image = bitmapCanvas;
            mode = Mode.RANDOM;
            count = 0;
        }

        private void _TableFill()
        {
            for (int i = 0; i < graph.GetEdgesNumber(); i++)
            {
                dataGridView1.Rows.Add();   
                dataGridView1.Rows[i].Cells[0].Value = graph.EdgeAt(i).GetVertice1Index();
                dataGridView1.Rows[i].Cells[1].Value = graph.EdgeAt(i).GetVertice2Index();
                dataGridView1.Rows[i].Cells[2].Value = graph.EdgeAt(i).GetWeight();
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            graph.GenerateRandom(Convert.ToInt32(verticesNumTextBox.Lines[0]));
            
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
            path.GenerateRandomPathFrom(Convert.ToInt32(beginFromTextBox.Lines[0]));

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
            WUGraphPath path = graph.MCE(Convert.ToInt32(threadsTextBox.Lines[0]),
                                         Convert.ToInt32(experimentsTextBox.Lines[0]),
                                         Convert.ToInt32(beginFromTextBox.Lines[0]));
            if (mode == Mode.RANDOM)
            {
                pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
            }
            else
            {
                pathWeightTextBox.Text = (graph.DrawPathOnMap(path, canvas, new Bitmap(map), canvasPictureBox).ToString());
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            graph.ClearEdges();

            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                graph.EdgeAdd(graph.GetVerticeByName(dataGridView1.Rows[i].Cells[0].Value.ToString()),
                              graph.GetVerticeByName(dataGridView1.Rows[i].Cells[1].Value.ToString()),
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
                Bitmap bitmap = new Bitmap(canvasPictureBox.Image);
                Graphics canvas0 = Graphics.FromImage(bitmap);
                canvasPictureBox.Image = bitmap;
                canvas0.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);

                Font font = new Font("Arial", 12);
                System.Drawing.SolidBrush brush = new SolidBrush(Color.Blue);
                canvas0.DrawString(count.ToString(), font, brush, e.X + 10, e.Y - 10);

                graph.VerticeAdd(new WUGraphVertice(e.X, e.Y, count.ToString()));
                dataGridView1.Rows.Add(count, count, 0);
                count++;

                dataGridView1.Update();
            }
        }

        private void buttonMapMode_Click(object sender, EventArgs e)
        {
            mode = Mode.REAL_MAP;
            buttonLoadImage.Enabled = true;
        }

        private void buttonRandomMode_Click(object sender, EventArgs e)
        {
            mode = Mode.RANDOM;
            buttonLoadImage.Enabled = false;
        }

        private void beginFromTextBox_TextChanged(object sender, EventArgs e)
        {
            int i;

            if (int.TryParse(beginFromTextBox.Text, out i))
            {
                mCBEbutton.Enabled = true;
                drawPathButton.Enabled = true;
            }
            else
            {
                mCBEbutton.Enabled = false;
                drawPathButton.Enabled = false;
            }
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
    }
}
