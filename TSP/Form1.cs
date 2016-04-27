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
    public partial class MainForm : Form
    {
        public Graphics canvas;
        WUGraph graph;
        Bitmap bitmapCanvas;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = this.CreateGraphics();
            graph = new WUGraph();
            bitmapCanvas = new Bitmap(this.Width, this.Height - 225);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            graph.GenerateRandom(Convert.ToInt32(verticesNumTextBox.Lines[0]));

            //graph.Draw(canvas);
            
            graph.Draw(bitmapCanvas, canvasPictureBox);
            pathWeightTextBox.Text = "";

        }

        private void drawPathButton_Click(object sender, EventArgs e)
        {
            WUGraphPath path = new WUGraphPath(Convert.ToInt32(verticesNumTextBox.Lines[0]));
            path.GenerateRandomPathFrom(Convert.ToInt32(beginFromTextBox.Lines[0]));
            graph.Draw(bitmapCanvas, canvasPictureBox);
            pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
        }

        private void mCBEbutton_Click(object sender, EventArgs e)
        {
            graph.Draw(bitmapCanvas, canvasPictureBox);

            WUGraphPath path = graph.MCE(Convert.ToInt32(threadsTextBox.Lines[0]),
                                         Convert.ToInt32(experimentsTextBox.Lines[0]),
                                         Convert.ToInt32(beginFromTextBox.Lines[0]));
            pathWeightTextBox.Text = (graph.DrawPath(path, bitmapCanvas, canvasPictureBox).ToString());
        }
    }
}
