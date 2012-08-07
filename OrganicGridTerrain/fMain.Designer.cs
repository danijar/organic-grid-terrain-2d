namespace OrganicGridTerrain
{
    partial class fMain
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
            this.btSave = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.pControls = new System.Windows.Forms.Panel();
            this.lEdges = new System.Windows.Forms.Label();
            this.cBEdgesBottom = new System.Windows.Forms.CheckBox();
            this.cBEdgesTop = new System.Windows.Forms.CheckBox();
            this.tBGridSize = new System.Windows.Forms.TrackBar();
            this.lGridSize = new System.Windows.Forms.Label();
            this.pControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBGridSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(121, 3);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(50, 23);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(65, 3);
            this.btReset.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(50, 23);
            this.btReset.TabIndex = 2;
            this.btReset.Text = "reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(9, 3);
            this.btLoad.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(50, 23);
            this.btLoad.TabIndex = 1;
            this.btLoad.Text = "load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // pControls
            // 
            this.pControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pControls.Controls.Add(this.lEdges);
            this.pControls.Controls.Add(this.cBEdgesBottom);
            this.pControls.Controls.Add(this.cBEdgesTop);
            this.pControls.Controls.Add(this.tBGridSize);
            this.pControls.Controls.Add(this.lGridSize);
            this.pControls.Controls.Add(this.btLoad);
            this.pControls.Controls.Add(this.btReset);
            this.pControls.Controls.Add(this.btSave);
            this.pControls.Location = new System.Drawing.Point(0, 445);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(752, 29);
            this.pControls.TabIndex = 0;
            // 
            // lEdges
            // 
            this.lEdges.Location = new System.Drawing.Point(334, 8);
            this.lEdges.Name = "lEdges";
            this.lEdges.Size = new System.Drawing.Size(57, 18);
            this.lEdges.TabIndex = 6;
            this.lEdges.Text = "smoothing";
            // 
            // cBEdgesBottom
            // 
            this.cBEdgesBottom.Checked = true;
            this.cBEdgesBottom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBEdgesBottom.Location = new System.Drawing.Point(432, 3);
            this.cBEdgesBottom.Name = "cBEdgesBottom";
            this.cBEdgesBottom.Size = new System.Drawing.Size(59, 24);
            this.cBEdgesBottom.TabIndex = 5;
            this.cBEdgesBottom.Text = "bottom";
            this.cBEdgesBottom.UseVisualStyleBackColor = true;
            this.cBEdgesBottom.CheckedChanged += new System.EventHandler(this.Repaint);
            // 
            // cBEdgesTop
            // 
            this.cBEdgesTop.Checked = true;
            this.cBEdgesTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBEdgesTop.Location = new System.Drawing.Point(394, 3);
            this.cBEdgesTop.Name = "cBEdgesTop";
            this.cBEdgesTop.Size = new System.Drawing.Size(41, 24);
            this.cBEdgesTop.TabIndex = 1;
            this.cBEdgesTop.Text = "top";
            this.cBEdgesTop.UseVisualStyleBackColor = true;
            this.cBEdgesTop.CheckedChanged += new System.EventHandler(this.Repaint);
            // 
            // tBGridSize
            // 
            this.tBGridSize.AutoSize = false;
            this.tBGridSize.LargeChange = 10;
            this.tBGridSize.Location = new System.Drawing.Point(225, 6);
            this.tBGridSize.Maximum = 100;
            this.tBGridSize.Minimum = 10;
            this.tBGridSize.Name = "tBGridSize";
            this.tBGridSize.Size = new System.Drawing.Size(104, 23);
            this.tBGridSize.TabIndex = 4;
            this.tBGridSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tBGridSize.Value = 10;
            this.tBGridSize.ValueChanged += new System.EventHandler(this.tBGridSize_ValueChanged);
            // 
            // lGridSize
            // 
            this.lGridSize.Location = new System.Drawing.Point(180, 8);
            this.lGridSize.Name = "lGridSize";
            this.lGridSize.Size = new System.Drawing.Size(50, 18);
            this.lGridSize.TabIndex = 0;
            this.lGridSize.Text = "grid size";
            this.lGridSize.DoubleClick += new System.EventHandler(this.lGridSize_DoubleClick);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 474);
            this.Controls.Add(this.pControls);
            this.MinimumSize = new System.Drawing.Size(512, 368);
            this.Name = "fMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organic Grid Terrain";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.fMain_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fMain_MouseDown);
            this.Resize += new System.EventHandler(this.fMain_Resize);
            this.pControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBGridSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.TrackBar tBGridSize;
        private System.Windows.Forms.Label lGridSize;
        private System.Windows.Forms.CheckBox cBEdgesTop;
        private System.Windows.Forms.CheckBox cBEdgesBottom;
        private System.Windows.Forms.Label lEdges;

    }
}

