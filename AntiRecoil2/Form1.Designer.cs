namespace AntiRecoil2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar4 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label7 = new Label();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 23);
            trackBar1.Maximum = 50;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(585, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll_1;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(12, 59);
            trackBar2.Maximum = 50;
            trackBar2.Minimum = -50;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(585, 45);
            trackBar2.TabIndex = 1;
            trackBar2.Scroll += trackBar3_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(12, 96);
            trackBar3.Maximum = 50;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(585, 45);
            trackBar3.TabIndex = 2;
            trackBar3.Scroll += trackBar3_Scroll_1;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(12, 123);
            trackBar4.Maximum = 50;
            trackBar4.Minimum = -50;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(585, 45);
            trackBar4.TabIndex = 3;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(615, 23);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 4;
            label1.Text = "X: 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(615, 59);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 5;
            label2.Text = "Y: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 268);
            label3.Name = "label3";
            label3.Size = new Size(38, 21);
            label3.TabIndex = 6;
            label3.Text = "OFF";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(295, 271);
            label4.Name = "label4";
            label4.Size = new Size(119, 21);
            label4.TabIndex = 7;
            label4.Text = "swastikkka Rico";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 185);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(12, 211);
            label6.Name = "label6";
            label6.Size = new Size(267, 25);
            label6.TabIndex = 12;
            label6.Text = "Enable    /    Disable  /  Xim Spin";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(615, 96);
            label8.Name = "label8";
            label8.Size = new Size(32, 15);
            label8.TabIndex = 13;
            label8.Text = "X2: 0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(615, 126);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 14;
            label9.Text = "Y2: 0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(127, 189);
            label10.Name = "label10";
            label10.Size = new Size(166, 15);
            label10.TabIndex = 15;
            label10.Text = "Delay for 2nd recoil (.seconds)";
            // 
            // button1
            // 
            button1.Location = new Point(522, 242);
            button1.Name = "button1";
            button1.Size = new Size(130, 47);
            button1.TabIndex = 16;
            button1.Text = "Load Config";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(522, 189);
            button2.Name = "button2";
            button2.Size = new Size(130, 47);
            button2.TabIndex = 17;
            button2.Text = "Save Config";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(441, 254);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Show BG :P";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(441, 201);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 19;
            button4.Text = "Rest All";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 273);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 20;
            label7.Text = "Current Op: ";
            // 
            // button5
            // 
            button5.Location = new Point(12, 239);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 22;
            button5.Text = "F1";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(106, 239);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 23;
            button6.Text = "F2";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(199, 239);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 24;
            button7.Text = "F3";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(664, 301);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBar4);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "AntiRecoil";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private TrackBar trackBar4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label7;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
