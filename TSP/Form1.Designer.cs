﻿namespace TSP
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
            this.label2 = new System.Windows.Forms.Label();
            this.beginFromTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mCBEbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.threadsTextBox = new System.Windows.Forms.TextBox();
            this.experimentsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.canvasPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).BeginInit();
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
            // 
            // drawPathButton
            // 
            this.drawPathButton.Location = new System.Drawing.Point(87, 19);
            this.drawPathButton.Name = "drawPathButton";
            this.drawPathButton.Size = new System.Drawing.Size(75, 23);
            this.drawPathButton.TabIndex = 2;
            this.drawPathButton.Text = "Draw a path";
            this.drawPathButton.UseVisualStyleBackColor = true;
            this.drawPathButton.Click += new System.EventHandler(this.drawPathButton_Click);
            // 
            // pathWeightTextBox
            // 
            this.pathWeightTextBox.Location = new System.Drawing.Point(127, 13);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Starting point:";
            // 
            // beginFromTextBox
            // 
            this.beginFromTextBox.Location = new System.Drawing.Point(9, 35);
            this.beginFromTextBox.Name = "beginFromTextBox";
            this.beginFromTextBox.Size = new System.Drawing.Size(75, 20);
            this.beginFromTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Path Summary Weight:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.generateButton);
            this.groupBox1.Controls.Add(this.drawPathButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.verticesNumTextBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph control";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pathWeightTextBox);
            this.groupBox2.Location = new System.Drawing.Point(5, 635);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 40);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
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
            this.groupBox3.Location = new System.Drawing.Point(182, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MCE";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.beginFromTextBox);
            this.groupBox4.Location = new System.Drawing.Point(359, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(90, 100);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // canvasPictureBox
            // 
            this.canvasPictureBox.Location = new System.Drawing.Point(5, 118);
            this.canvasPictureBox.Name = "canvasPictureBox";
            this.canvasPictureBox.Size = new System.Drawing.Size(100, 50);
            this.canvasPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvasPictureBox.TabIndex = 17;
            this.canvasPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 687);
            this.Controls.Add(this.canvasPictureBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Name = "MainForm";
            this.Text = "TSP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox verticesNumTextBox;
        private System.Windows.Forms.Button drawPathButton;
        private System.Windows.Forms.TextBox pathWeightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox beginFromTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button mCBEbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox threadsTextBox;
        private System.Windows.Forms.TextBox experimentsTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox canvasPictureBox;
    }
}
