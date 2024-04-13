namespace DiscreteMath_Lab1
{
    partial class MainForm
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
            this.DrawVertexButton = new System.Windows.Forms.Button();
            this.DeleteElementButton = new System.Windows.Forms.Button();
            this.DrawEdgeButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.CreateIncMatrButton = new System.Windows.Forms.Button();
            this.CreateAdjMatrButton = new System.Windows.Forms.Button();
            this.DrawingAreaPictureBox = new System.Windows.Forms.PictureBox();
            this.MatrixListBox = new System.Windows.Forms.ListBox();
            this.GenerateGraphGroupBox = new System.Windows.Forms.GroupBox();
            this.GraphSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MultyGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.LoopGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.SimpleGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.FullGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.GenerateRandomGraphButton = new System.Windows.Forms.Button();
            this.MetrixMatrButton = new System.Windows.Forms.Button();
            this.EmptySubgraphButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingAreaPictureBox)).BeginInit();
            this.GenerateGraphGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawVertexButton
            // 
            this.DrawVertexButton.Location = new System.Drawing.Point(23, 12);
            this.DrawVertexButton.Name = "DrawVertexButton";
            this.DrawVertexButton.Size = new System.Drawing.Size(86, 23);
            this.DrawVertexButton.TabIndex = 1;
            this.DrawVertexButton.Text = "DrawVertex";
            this.DrawVertexButton.UseVisualStyleBackColor = true;
            this.DrawVertexButton.Click += new System.EventHandler(this.DrawVertexButton_Click);
            // 
            // DeleteElementButton
            // 
            this.DeleteElementButton.Location = new System.Drawing.Point(23, 70);
            this.DeleteElementButton.Name = "DeleteElementButton";
            this.DeleteElementButton.Size = new System.Drawing.Size(86, 23);
            this.DeleteElementButton.TabIndex = 3;
            this.DeleteElementButton.Text = "Delete One";
            this.DeleteElementButton.UseVisualStyleBackColor = true;
            this.DeleteElementButton.Click += new System.EventHandler(this.DeleteElementButton_Click);
            // 
            // DrawEdgeButton
            // 
            this.DrawEdgeButton.Location = new System.Drawing.Point(23, 41);
            this.DrawEdgeButton.Name = "DrawEdgeButton";
            this.DrawEdgeButton.Size = new System.Drawing.Size(86, 23);
            this.DrawEdgeButton.TabIndex = 2;
            this.DrawEdgeButton.Text = "DrawEdge";
            this.DrawEdgeButton.UseVisualStyleBackColor = true;
            this.DrawEdgeButton.Click += new System.EventHandler(this.DrawEdgeButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Location = new System.Drawing.Point(23, 99);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(86, 23);
            this.DeleteAllButton.TabIndex = 4;
            this.DeleteAllButton.Text = "Delete All";
            this.DeleteAllButton.UseVisualStyleBackColor = true;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // CreateIncMatrButton
            // 
            this.CreateIncMatrButton.Location = new System.Drawing.Point(613, 12);
            this.CreateIncMatrButton.Name = "CreateIncMatrButton";
            this.CreateIncMatrButton.Size = new System.Drawing.Size(64, 23);
            this.CreateIncMatrButton.TabIndex = 5;
            this.CreateIncMatrButton.Text = "Inc Matrix";
            this.CreateIncMatrButton.UseVisualStyleBackColor = true;
            this.CreateIncMatrButton.Click += new System.EventHandler(this.CreateIncMatrButton_Click);
            // 
            // CreateAdjMatrButton
            // 
            this.CreateAdjMatrButton.Location = new System.Drawing.Point(542, 12);
            this.CreateAdjMatrButton.Name = "CreateAdjMatrButton";
            this.CreateAdjMatrButton.Size = new System.Drawing.Size(65, 23);
            this.CreateAdjMatrButton.TabIndex = 6;
            this.CreateAdjMatrButton.Text = "Adj Matrix";
            this.CreateAdjMatrButton.UseVisualStyleBackColor = true;
            this.CreateAdjMatrButton.Click += new System.EventHandler(this.CreateAdjMatrButton_Click);
            // 
            // DrawingAreaPictureBox
            // 
            this.DrawingAreaPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingAreaPictureBox.Location = new System.Drawing.Point(136, 12);
            this.DrawingAreaPictureBox.Name = "DrawingAreaPictureBox";
            this.DrawingAreaPictureBox.Size = new System.Drawing.Size(400, 400);
            this.DrawingAreaPictureBox.TabIndex = 7;
            this.DrawingAreaPictureBox.TabStop = false;
            this.DrawingAreaPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingAreaPictureBox_MouseClick);
            // 
            // MatrixListBox
            // 
            this.MatrixListBox.FormattingEnabled = true;
            this.MatrixListBox.Location = new System.Drawing.Point(542, 44);
            this.MatrixListBox.Name = "MatrixListBox";
            this.MatrixListBox.Size = new System.Drawing.Size(217, 186);
            this.MatrixListBox.TabIndex = 8;
            // 
            // GenerateGraphGroupBox
            // 
            this.GenerateGraphGroupBox.Controls.Add(this.GraphSizeComboBox);
            this.GenerateGraphGroupBox.Controls.Add(this.label1);
            this.GenerateGraphGroupBox.Controls.Add(this.MultyGraphCheckBox);
            this.GenerateGraphGroupBox.Controls.Add(this.LoopGraphCheckBox);
            this.GenerateGraphGroupBox.Controls.Add(this.SimpleGraphCheckBox);
            this.GenerateGraphGroupBox.Controls.Add(this.FullGraphCheckBox);
            this.GenerateGraphGroupBox.Controls.Add(this.GenerateRandomGraphButton);
            this.GenerateGraphGroupBox.Location = new System.Drawing.Point(12, 128);
            this.GenerateGraphGroupBox.Name = "GenerateGraphGroupBox";
            this.GenerateGraphGroupBox.Size = new System.Drawing.Size(118, 174);
            this.GenerateGraphGroupBox.TabIndex = 10;
            this.GenerateGraphGroupBox.TabStop = false;
            this.GenerateGraphGroupBox.Text = "Generate Graph";
            // 
            // GraphSizeComboBox
            // 
            this.GraphSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GraphSizeComboBox.FormattingEnabled = true;
            this.GraphSizeComboBox.Location = new System.Drawing.Point(36, 140);
            this.GraphSizeComboBox.Name = "GraphSizeComboBox";
            this.GraphSizeComboBox.Size = new System.Drawing.Size(76, 21);
            this.GraphSizeComboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size:";
            // 
            // MultyGraphCheckBox
            // 
            this.MultyGraphCheckBox.AutoSize = true;
            this.MultyGraphCheckBox.Location = new System.Drawing.Point(6, 117);
            this.MultyGraphCheckBox.Name = "MultyGraphCheckBox";
            this.MultyGraphCheckBox.Size = new System.Drawing.Size(107, 17);
            this.MultyGraphCheckBox.TabIndex = 4;
            this.MultyGraphCheckBox.Text = "With Multiplicities";
            this.MultyGraphCheckBox.UseVisualStyleBackColor = true;
            this.MultyGraphCheckBox.CheckedChanged += new System.EventHandler(this.MultyGraphCheckBox_CheckedChanged);
            // 
            // LoopGraphCheckBox
            // 
            this.LoopGraphCheckBox.AutoSize = true;
            this.LoopGraphCheckBox.Location = new System.Drawing.Point(6, 94);
            this.LoopGraphCheckBox.Name = "LoopGraphCheckBox";
            this.LoopGraphCheckBox.Size = new System.Drawing.Size(80, 17);
            this.LoopGraphCheckBox.TabIndex = 3;
            this.LoopGraphCheckBox.Text = "With Loops";
            this.LoopGraphCheckBox.UseVisualStyleBackColor = true;
            this.LoopGraphCheckBox.CheckedChanged += new System.EventHandler(this.LoopGraphCheckBox_CheckedChanged);
            // 
            // SimpleGraphCheckBox
            // 
            this.SimpleGraphCheckBox.AutoSize = true;
            this.SimpleGraphCheckBox.Location = new System.Drawing.Point(6, 71);
            this.SimpleGraphCheckBox.Name = "SimpleGraphCheckBox";
            this.SimpleGraphCheckBox.Size = new System.Drawing.Size(57, 17);
            this.SimpleGraphCheckBox.TabIndex = 2;
            this.SimpleGraphCheckBox.Text = "Simple";
            this.SimpleGraphCheckBox.UseVisualStyleBackColor = true;
            this.SimpleGraphCheckBox.CheckedChanged += new System.EventHandler(this.SimpleGraphCheckBox_CheckedChanged);
            // 
            // FullGraphCheckBox
            // 
            this.FullGraphCheckBox.AutoSize = true;
            this.FullGraphCheckBox.Location = new System.Drawing.Point(6, 48);
            this.FullGraphCheckBox.Name = "FullGraphCheckBox";
            this.FullGraphCheckBox.Size = new System.Drawing.Size(42, 17);
            this.FullGraphCheckBox.TabIndex = 1;
            this.FullGraphCheckBox.Text = "Full";
            this.FullGraphCheckBox.UseVisualStyleBackColor = true;
            this.FullGraphCheckBox.CheckedChanged += new System.EventHandler(this.FullGraphCheckBox_CheckedChanged);
            // 
            // GenerateRandomGraphButton
            // 
            this.GenerateRandomGraphButton.Location = new System.Drawing.Point(11, 19);
            this.GenerateRandomGraphButton.Name = "GenerateRandomGraphButton";
            this.GenerateRandomGraphButton.Size = new System.Drawing.Size(86, 23);
            this.GenerateRandomGraphButton.TabIndex = 0;
            this.GenerateRandomGraphButton.Text = "Generate";
            this.GenerateRandomGraphButton.UseVisualStyleBackColor = true;
            this.GenerateRandomGraphButton.Click += new System.EventHandler(this.GenerateRandomGraphButton_Click);
            // 
            // MetrixMatrButton
            // 
            this.MetrixMatrButton.Location = new System.Drawing.Point(683, 12);
            this.MetrixMatrButton.Name = "MetrixMatrButton";
            this.MetrixMatrButton.Size = new System.Drawing.Size(76, 23);
            this.MetrixMatrButton.TabIndex = 11;
            this.MetrixMatrButton.Text = "Metrix Matrix";
            this.MetrixMatrButton.UseVisualStyleBackColor = true;
            this.MetrixMatrButton.Click += new System.EventHandler(this.MetrixMatrButton_Click);
            // 
            // EmptySubgraphButton
            // 
            this.EmptySubgraphButton.Location = new System.Drawing.Point(542, 236);
            this.EmptySubgraphButton.Name = "EmptySubgraphButton";
            this.EmptySubgraphButton.Size = new System.Drawing.Size(95, 23);
            this.EmptySubgraphButton.TabIndex = 12;
            this.EmptySubgraphButton.Text = "EmptySubgraph";
            this.EmptySubgraphButton.UseVisualStyleBackColor = true;
            this.EmptySubgraphButton.Click += new System.EventHandler(this.EmptySubraphButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 423);
            this.Controls.Add(this.EmptySubgraphButton);
            this.Controls.Add(this.MetrixMatrButton);
            this.Controls.Add(this.GenerateGraphGroupBox);
            this.Controls.Add(this.MatrixListBox);
            this.Controls.Add(this.DrawingAreaPictureBox);
            this.Controls.Add(this.CreateAdjMatrButton);
            this.Controls.Add(this.CreateIncMatrButton);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.DeleteElementButton);
            this.Controls.Add(this.DrawEdgeButton);
            this.Controls.Add(this.DrawVertexButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Visualiser";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingAreaPictureBox)).EndInit();
            this.GenerateGraphGroupBox.ResumeLayout(false);
            this.GenerateGraphGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DrawVertexButton;
        private System.Windows.Forms.Button DeleteElementButton;
        private System.Windows.Forms.Button DrawEdgeButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.Button CreateIncMatrButton;
        private System.Windows.Forms.Button CreateAdjMatrButton;
        private System.Windows.Forms.PictureBox DrawingAreaPictureBox;
        private System.Windows.Forms.ListBox MatrixListBox;
        private System.Windows.Forms.GroupBox GenerateGraphGroupBox;
        private System.Windows.Forms.Button GenerateRandomGraphButton;
        private System.Windows.Forms.CheckBox MultyGraphCheckBox;
        private System.Windows.Forms.CheckBox LoopGraphCheckBox;
        private System.Windows.Forms.CheckBox SimpleGraphCheckBox;
        private System.Windows.Forms.CheckBox FullGraphCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GraphSizeComboBox;
        private System.Windows.Forms.Button MetrixMatrButton;
        private System.Windows.Forms.Button EmptySubgraphButton;
    }
}

