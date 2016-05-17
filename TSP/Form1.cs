using System;
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
    enum Mode { EDIT, SIMPLE };

    public partial class MainForm : Form
    {
        public Graphics canvas;
        WUGraph graph;
        Bitmap bitmapCanvas;
        Mode mode;
        Bitmap map;
        int count;
        Bitmap mapDotted;


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
            mode = Mode.SIMPLE;
            count = 0;
        }

        private void TableFill()
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
            TableFill();
            dataGridView1.Update();


        }

        private void drawPathButton_Click(object sender, EventArgs e)
        {
            
            WUGraphPath path = new WUGraphPath(Convert.ToInt32(graph.GetVerticesNumber()));
            //canvas.DrawImage(map, 0, 155);
            path.GenerateRandomPathFrom(Convert.ToInt32(beginFromTextBox.Lines[0]));
            canvas.Clear(SystemColors.Control);
            if (mode == Mode.SIMPLE)
            {
                pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
            }
            else
            {
                pathWeightTextBox.Text = (graph.DrawPath(path, new Bitmap(map), canvasPictureBox).ToString());
            }
            //graph.DrawPath(path, canvas);
        }

        private void mCBEbutton_Click(object sender, EventArgs e)
        {
            WUGraphPath path = graph.MCE(Convert.ToInt32(threadsTextBox.Lines[0]),
                                         Convert.ToInt32(experimentsTextBox.Lines[0]),
                                         Convert.ToInt32(beginFromTextBox.Lines[0]));
            pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
        }

        private void radioButtonSimpleMode_CheckedChanged(object sender, EventArgs e)
        {

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
            //TableFill();
            //dataGridView1.Update();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            string mapPath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            mapPath = ofd.FileName;
            map = new Bitmap(mapPath);
            mapDotted = new Bitmap(mapPath);
            //canvas.DrawImage(map, 0, 155);
            canvasPictureBox.Image = map;
            //canvas = Graphics.FromImage(map);
            //graph.Draw(map, canvasPictureBox);

            

        }

        private void canvasPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == Mode.EDIT)
            {
                Graphics canvas0 = Graphics.FromImage(canvasPictureBox.Image);
                canvas0.FillEllipse(Brushes.Red, e.X - 5, e.Y - 5, 10, 10);
                graph.VerticeAdd(new WUGraphVertice(e.X, e.Y, count.ToString()));
                canvasPictureBox.Image = new Bitmap(canvasPictureBox.Image.Width, canvasPictureBox.Image.Height, canvas0);
                dataGridView1.Rows.Add(count, count, 0);
                count++;

                dataGridView1.Update();
            }


        }

        private void buttonEditingStart_Click(object sender, EventArgs e)
        {
            mode = Mode.EDIT;
            buttonLoadImage.Enabled = true;
        }

        private void buttonEditingStop_Click(object sender, EventArgs e)
        {
            mode = Mode.SIMPLE;
            buttonLoadImage.Enabled = false;
        }
    }
}
