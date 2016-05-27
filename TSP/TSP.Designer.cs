namespace TSP
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.generateButton = new System.Windows.Forms.Button();
            this.verticesNumTextBox = new System.Windows.Forms.TextBox();
            this.drawPathButton = new System.Windows.Forms.Button();
            this.pathWeightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSymmetry = new System.Windows.Forms.Button();
            this.buttonLoadFromFile = new System.Windows.Forms.Button();
            this.buttonSaveGraph = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mCBEbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.threadsTextBox = new System.Windows.Forms.TextBox();
            this.experimentsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.canvasPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonRandomMode = new System.Windows.Forms.Button();
            this.buttonMapMode = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIterations = new System.Windows.Forms.TextBox();
            this.textBoxGenerationCap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGAThredsNum = new System.Windows.Forms.TextBox();
            this.buttonGARun = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAutoGraph = new System.Windows.Forms.Button();
            this.textBoxNewVertice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(6, 19);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // verticesNumTextBox
            // 
            this.verticesNumTextBox.Location = new System.Drawing.Point(6, 61);
            this.verticesNumTextBox.Name = "verticesNumTextBox";
            this.verticesNumTextBox.Size = new System.Drawing.Size(75, 20);
            this.verticesNumTextBox.TabIndex = 1;
            this.verticesNumTextBox.TextChanged += new System.EventHandler(this.verticesNumTextBox_TextChanged);
            // 
            // drawPathButton
            // 
            this.drawPathButton.Location = new System.Drawing.Point(87, 59);
            this.drawPathButton.Name = "drawPathButton";
            this.drawPathButton.Size = new System.Drawing.Size(75, 23);
            this.drawPathButton.TabIndex = 2;
            this.drawPathButton.Text = "Draw a path";
            this.drawPathButton.UseVisualStyleBackColor = true;
            this.drawPathButton.Click += new System.EventHandler(this.drawPathButton_Click);
            // 
            // pathWeightTextBox
            // 
            this.pathWeightTextBox.Location = new System.Drawing.Point(9, 32);
            this.pathWeightTextBox.Name = "pathWeightTextBox";
            this.pathWeightTextBox.ReadOnly = true;
            this.pathWeightTextBox.Size = new System.Drawing.Size(75, 20);
            this.pathWeightTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vertices:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Path summary weight:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSymmetry);
            this.groupBox1.Controls.Add(this.buttonLoadFromFile);
            this.groupBox1.Controls.Add(this.generateButton);
            this.groupBox1.Controls.Add(this.buttonSaveGraph);
            this.groupBox1.Controls.Add(this.drawPathButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.verticesNumTextBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph control";
            // 
            // buttonSymmetry
            // 
            this.buttonSymmetry.Location = new System.Drawing.Point(168, 59);
            this.buttonSymmetry.Name = "buttonSymmetry";
            this.buttonSymmetry.Size = new System.Drawing.Size(24, 24);
            this.buttonSymmetry.TabIndex = 31;
            this.buttonSymmetry.Text = "S";
            this.buttonSymmetry.UseVisualStyleBackColor = true;
            this.buttonSymmetry.Click += new System.EventHandler(this.buttonSymmetry_Click);
            // 
            // buttonLoadFromFile
            // 
            this.buttonLoadFromFile.Location = new System.Drawing.Point(168, 20);
            this.buttonLoadFromFile.Name = "buttonLoadFromFile";
            this.buttonLoadFromFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFromFile.TabIndex = 30;
            this.buttonLoadFromFile.Text = "Load graph";
            this.buttonLoadFromFile.UseVisualStyleBackColor = true;
            this.buttonLoadFromFile.Click += new System.EventHandler(this.buttonLoadFromFile_Click);
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(87, 19);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveGraph.TabIndex = 28;
            this.buttonSaveGraph.Text = "Save graph";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            this.buttonSaveGraph.Click += new System.EventHandler(this.buttonSaveGraph_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.textBoxTime);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pathWeightTextBox);
            this.groupBox2.Location = new System.Drawing.Point(894, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 99);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(9, 70);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(75, 20);
            this.textBoxTime.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Time:";
            // 
            // mCBEbutton
            // 
            this.mCBEbutton.Location = new System.Drawing.Point(6, 19);
            this.mCBEbutton.Name = "mCBEbutton";
            this.mCBEbutton.Size = new System.Drawing.Size(75, 23);
            this.mCBEbutton.TabIndex = 10;
            this.mCBEbutton.Text = "Run";
            this.mCBEbutton.UseVisualStyleBackColor = true;
            this.mCBEbutton.Click += new System.EventHandler(this.mCBEbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Threads:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Experiments:";
            // 
            // threadsTextBox
            // 
            this.threadsTextBox.Location = new System.Drawing.Point(9, 61);
            this.threadsTextBox.Name = "threadsTextBox";
            this.threadsTextBox.Size = new System.Drawing.Size(72, 20);
            this.threadsTextBox.TabIndex = 13;
            // 
            // experimentsTextBox
            // 
            this.experimentsTextBox.Location = new System.Drawing.Point(87, 61);
            this.experimentsTextBox.Name = "experimentsTextBox";
            this.experimentsTextBox.Size = new System.Drawing.Size(72, 20);
            this.experimentsTextBox.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mCBEbutton);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.experimentsTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.threadsTextBox);
            this.groupBox3.Location = new System.Drawing.Point(263, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MCE";
            // 
            // canvasPictureBox
            // 
            this.canvasPictureBox.Location = new System.Drawing.Point(5, 117);
            this.canvasPictureBox.Name = "canvasPictureBox";
            this.canvasPictureBox.Size = new System.Drawing.Size(1104, 620);
            this.canvasPictureBox.TabIndex = 17;
            this.canvasPictureBox.TabStop = false;
            this.canvasPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonLoadImage);
            this.groupBox5.Controls.Add(this.buttonRandomMode);
            this.groupBox5.Controls.Add(this.buttonMapMode);
            this.groupBox5.Location = new System.Drawing.Point(716, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(172, 99);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Experiment mode";
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Enabled = false;
            this.buttonLoadImage.Location = new System.Drawing.Point(88, 20);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImage.TabIndex = 23;
            this.buttonLoadImage.Text = "Load image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonRandomMode
            // 
            this.buttonRandomMode.Location = new System.Drawing.Point(7, 49);
            this.buttonRandomMode.Name = "buttonRandomMode";
            this.buttonRandomMode.Size = new System.Drawing.Size(75, 23);
            this.buttonRandomMode.TabIndex = 1;
            this.buttonRandomMode.Text = "Random";
            this.buttonRandomMode.UseVisualStyleBackColor = true;
            this.buttonRandomMode.Click += new System.EventHandler(this.buttonRandomMode_Click);
            // 
            // buttonMapMode
            // 
            this.buttonMapMode.Location = new System.Drawing.Point(7, 20);
            this.buttonMapMode.Name = "buttonMapMode";
            this.buttonMapMode.Size = new System.Drawing.Size(75, 23);
            this.buttonMapMode.TabIndex = 0;
            this.buttonMapMode.Text = "Map";
            this.buttonMapMode.UseVisualStyleBackColor = true;
            this.buttonMapMode.Click += new System.EventHandler(this.buttonMapMode_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.from,
            this.to,
            this.cost});
            this.dataGridView1.Location = new System.Drawing.Point(1115, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(221, 589);
            this.dataGridView1.TabIndex = 21;
            // 
            // from
            // 
            this.from.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.from.HeaderText = "From";
            this.from.Name = "from";
            this.from.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.from.Width = 55;
            // 
            // to
            // 
            this.to.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.to.HeaderText = "To";
            this.to.Name = "to";
            this.to.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.to.Width = 45;
            // 
            // cost
            // 
            this.cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cost.HeaderText = "Cost";
            this.cost.Name = "cost";
            this.cost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cost.Width = 53;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(1115, 652);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 22;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBoxIterations);
            this.groupBox4.Controls.Add(this.textBoxGenerationCap);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxGAThredsNum);
            this.groupBox4.Controls.Add(this.buttonGARun);
            this.groupBox4.Location = new System.Drawing.Point(439, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 100);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "GA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Interations:";
            // 
            // textBoxIterations
            // 
            this.textBoxIterations.Location = new System.Drawing.Point(168, 61);
            this.textBoxIterations.Name = "textBoxIterations";
            this.textBoxIterations.Size = new System.Drawing.Size(75, 20);
            this.textBoxIterations.TabIndex = 5;
            // 
            // textBoxGenerationCap
            // 
            this.textBoxGenerationCap.Location = new System.Drawing.Point(87, 61);
            this.textBoxGenerationCap.Name = "textBoxGenerationCap";
            this.textBoxGenerationCap.Size = new System.Drawing.Size(75, 20);
            this.textBoxGenerationCap.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Generation cap:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Threads:";
            // 
            // textBoxGAThredsNum
            // 
            this.textBoxGAThredsNum.Location = new System.Drawing.Point(6, 61);
            this.textBoxGAThredsNum.Name = "textBoxGAThredsNum";
            this.textBoxGAThredsNum.Size = new System.Drawing.Size(75, 20);
            this.textBoxGAThredsNum.TabIndex = 1;
            // 
            // buttonGARun
            // 
            this.buttonGARun.Location = new System.Drawing.Point(6, 19);
            this.buttonGARun.Name = "buttonGARun";
            this.buttonGARun.Size = new System.Drawing.Size(75, 23);
            this.buttonGARun.TabIndex = 0;
            this.buttonGARun.Text = "Run";
            this.buttonGARun.UseVisualStyleBackColor = true;
            this.buttonGARun.Click += new System.EventHandler(this.buttonGARun_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1020, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAutoGraph
            // 
            this.buttonAutoGraph.Location = new System.Drawing.Point(1196, 652);
            this.buttonAutoGraph.Name = "buttonAutoGraph";
            this.buttonAutoGraph.Size = new System.Drawing.Size(75, 23);
            this.buttonAutoGraph.TabIndex = 24;
            this.buttonAutoGraph.Text = "Auto";
            this.buttonAutoGraph.UseVisualStyleBackColor = true;
            this.buttonAutoGraph.Click += new System.EventHandler(this.buttonAutoGraph_Click);
            // 
            // textBoxNewVertice
            // 
            this.textBoxNewVertice.Location = new System.Drawing.Point(1115, 31);
            this.textBoxNewVertice.Name = "textBoxNewVertice";
            this.textBoxNewVertice.Size = new System.Drawing.Size(221, 20);
            this.textBoxNewVertice.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1112, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Add point:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 733);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxNewVertice);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonAutoGraph);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.canvasPictureBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "MainForm";
            this.Text = "TSP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvasPictureBox_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox verticesNumTextBox;
        private System.Windows.Forms.Button drawPathButton;
        private System.Windows.Forms.TextBox pathWeightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button mCBEbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox threadsTextBox;
        private System.Windows.Forms.TextBox experimentsTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox canvasPictureBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonRandomMode;
        private System.Windows.Forms.Button buttonMapMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonGARun;
        private System.Windows.Forms.TextBox textBoxGenerationCap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGAThredsNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIterations;
        private System.Windows.Forms.Button buttonAutoGraph;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSaveGraph;
        private System.Windows.Forms.TextBox textBoxNewVertice;
        private System.Windows.Forms.Button buttonLoadFromFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn to;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.Button buttonSymmetry;
    }
}

