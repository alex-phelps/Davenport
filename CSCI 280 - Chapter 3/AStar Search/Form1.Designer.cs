namespace AStar_Search
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.displayGraphButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aStarButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.startNodeXCB = new System.Windows.Forms.ComboBox();
            this.startNodeYCB = new System.Windows.Forms.ComboBox();
            this.goalNodeXCB = new System.Windows.Forms.ComboBox();
            this.goalNodeYCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.obstaclesCountCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // displayGraphButton
            // 
            this.displayGraphButton.Location = new System.Drawing.Point(22, 26);
            this.displayGraphButton.Name = "displayGraphButton";
            this.displayGraphButton.Size = new System.Drawing.Size(140, 23);
            this.displayGraphButton.TabIndex = 0;
            this.displayGraphButton.Text = "Display Graph";
            this.displayGraphButton.UseVisualStyleBackColor = true;
            this.displayGraphButton.Click += new System.EventHandler(this.displayGraphButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Node";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Goal Node";
            // 
            // aStarButton
            // 
            this.aStarButton.Location = new System.Drawing.Point(22, 78);
            this.aStarButton.Name = "aStarButton";
            this.aStarButton.Size = new System.Drawing.Size(140, 23);
            this.aStarButton.TabIndex = 5;
            this.aStarButton.Text = "Start A *";
            this.aStarButton.UseVisualStyleBackColor = true;
            this.aStarButton.Click += new System.EventHandler(this.aStarButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 249);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(587, 238);
            this.listBox1.TabIndex = 6;
            // 
            // startNodeXCB
            // 
            this.startNodeXCB.FormattingEnabled = true;
            this.startNodeXCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.startNodeXCB.Location = new System.Drawing.Point(381, 26);
            this.startNodeXCB.Name = "startNodeXCB";
            this.startNodeXCB.Size = new System.Drawing.Size(47, 21);
            this.startNodeXCB.TabIndex = 7;
            this.startNodeXCB.SelectedIndexChanged += new System.EventHandler(this.startNodeXCB_SelectedIndexChanged);
            // 
            // startNodeYCB
            // 
            this.startNodeYCB.FormattingEnabled = true;
            this.startNodeYCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.startNodeYCB.Location = new System.Drawing.Point(444, 27);
            this.startNodeYCB.Name = "startNodeYCB";
            this.startNodeYCB.Size = new System.Drawing.Size(47, 21);
            this.startNodeYCB.TabIndex = 8;
            this.startNodeYCB.SelectedIndexChanged += new System.EventHandler(this.startNodeYCB_SelectedIndexChanged);
            // 
            // goalNodeXCB
            // 
            this.goalNodeXCB.FormattingEnabled = true;
            this.goalNodeXCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.goalNodeXCB.Location = new System.Drawing.Point(381, 65);
            this.goalNodeXCB.Name = "goalNodeXCB";
            this.goalNodeXCB.Size = new System.Drawing.Size(47, 21);
            this.goalNodeXCB.TabIndex = 9;
            this.goalNodeXCB.SelectedIndexChanged += new System.EventHandler(this.goalNodeXCB_SelectedIndexChanged);
            // 
            // goalNodeYCB
            // 
            this.goalNodeYCB.FormattingEnabled = true;
            this.goalNodeYCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.goalNodeYCB.Location = new System.Drawing.Point(444, 66);
            this.goalNodeYCB.Name = "goalNodeYCB";
            this.goalNodeYCB.Size = new System.Drawing.Size(47, 21);
            this.goalNodeYCB.TabIndex = 10;
            this.goalNodeYCB.SelectedIndexChanged += new System.EventHandler(this.goalNodeYCB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Obstacles";
            // 
            // obstaclesCountCB
            // 
            this.obstaclesCountCB.FormattingEnabled = true;
            this.obstaclesCountCB.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.obstaclesCountCB.Location = new System.Drawing.Point(381, 105);
            this.obstaclesCountCB.Name = "obstaclesCountCB";
            this.obstaclesCountCB.Size = new System.Drawing.Size(47, 21);
            this.obstaclesCountCB.TabIndex = 12;
            this.obstaclesCountCB.SelectedIndexChanged += new System.EventHandler(this.obstaclesCountCB_SelectedIndexChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 494);
            this.Controls.Add(this.obstaclesCountCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goalNodeYCB);
            this.Controls.Add(this.goalNodeXCB);
            this.Controls.Add(this.startNodeYCB);
            this.Controls.Add(this.startNodeXCB);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.aStarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayGraphButton);
            this.Name = "mainForm";
            this.Text = "A * Search";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button displayGraphButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button aStarButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox startNodeXCB;
        private System.Windows.Forms.ComboBox startNodeYCB;
        private System.Windows.Forms.ComboBox goalNodeXCB;
        private System.Windows.Forms.ComboBox goalNodeYCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox obstaclesCountCB;
    }
}

