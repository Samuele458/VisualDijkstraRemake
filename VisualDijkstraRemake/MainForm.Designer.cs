
namespace VisualDijkstraRemake
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.scrollPanel1 = new VisualDijkstraRemake.Controls.ScrollPanel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newGraphButton = new System.Windows.Forms.ToolStripButton();
            this.openGraphButton = new System.Windows.Forms.ToolStripButton();
            this.saveGraphButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNodeButton = new System.Windows.Forms.ToolStripButton();
            this.removeNodeButton = new System.Windows.Forms.ToolStripButton();
            this.addEdgeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.calculatePathButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.adjMatrixButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.CausesValidation = false;
            this.mainSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 118);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(3, 100, 3, 3);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.scrollPanel1);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainSplitContainer.Panel2.Controls.Add(this.mainToolStrip);
            this.mainSplitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.mainSplitContainer_Panel2_Paint);
            this.mainSplitContainer.Size = new System.Drawing.Size(792, 406);
            this.mainSplitContainer.SplitterDistance = 410;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // scrollPanel1
            // 
            this.scrollPanel1.AutoScroll = true;
            this.scrollPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel1.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel1.Name = "scrollPanel1";
            this.scrollPanel1.Size = new System.Drawing.Size(408, 404);
            this.scrollPanel1.TabIndex = 0;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.CanOverflow = false;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGraphButton,
            this.openGraphButton,
            this.saveGraphButton,
            this.toolStripSeparator1,
            this.addNodeButton,
            this.removeNodeButton,
            this.addEdgeButton,
            this.toolStripSeparator2,
            this.calculatePathButton,
            this.toolStripSeparator3,
            this.adjMatrixButton});
            this.mainToolStrip.Location = new System.Drawing.Point(10, 16);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(349, 39);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // newGraphButton
            // 
            this.newGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newGraphButton.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.newGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newGraphButton.Name = "newGraphButton";
            this.newGraphButton.Size = new System.Drawing.Size(36, 36);
            this.newGraphButton.Text = "New graph";
            this.newGraphButton.Click += new System.EventHandler(this.newGraphButton_Click);
            // 
            // openGraphButton
            // 
            this.openGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openGraphButton.Image = global::VisualDijkstraRemake.Properties.Resources.folder;
            this.openGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openGraphButton.Name = "openGraphButton";
            this.openGraphButton.Size = new System.Drawing.Size(36, 36);
            this.openGraphButton.Text = "Open";
            this.openGraphButton.ToolTipText = "Open";
            // 
            // saveGraphButton
            // 
            this.saveGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveGraphButton.Image = global::VisualDijkstraRemake.Properties.Resources.save;
            this.saveGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveGraphButton.Name = "saveGraphButton";
            this.saveGraphButton.Size = new System.Drawing.Size(36, 36);
            this.saveGraphButton.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // addNodeButton
            // 
            this.addNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNodeButton.Image = global::VisualDijkstraRemake.Properties.Resources.add;
            this.addNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNodeButton.Name = "addNodeButton";
            this.addNodeButton.Size = new System.Drawing.Size(36, 36);
            this.addNodeButton.Text = "Create node";
            this.addNodeButton.Click += new System.EventHandler(this.addNodeButton_Click);
            // 
            // removeNodeButton
            // 
            this.removeNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeNodeButton.Image = global::VisualDijkstraRemake.Properties.Resources.delete;
            this.removeNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeNodeButton.Name = "removeNodeButton";
            this.removeNodeButton.Size = new System.Drawing.Size(36, 36);
            this.removeNodeButton.Text = "toolStripButton1";
            this.removeNodeButton.ToolTipText = "Remove node";
            // 
            // addEdgeButton
            // 
            this.addEdgeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addEdgeButton.Image = global::VisualDijkstraRemake.Properties.Resources.route;
            this.addEdgeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.Size = new System.Drawing.Size(36, 36);
            this.addEdgeButton.Text = "Create new edge";
            this.addEdgeButton.ToolTipText = "Create new edge. Click on two nodes to link them.";
            this.addEdgeButton.Click += new System.EventHandler(this.addEdgeButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // calculatePathButton
            // 
            this.calculatePathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.calculatePathButton.Image = global::VisualDijkstraRemake.Properties.Resources.path;
            this.calculatePathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.calculatePathButton.Name = "calculatePathButton";
            this.calculatePathButton.Size = new System.Drawing.Size(36, 36);
            this.calculatePathButton.Text = "Calculate path";
            this.calculatePathButton.ToolTipText = "Calculate path between two nodes. Click on two nodes to calculate the path.";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // adjMatrixButton
            // 
            this.adjMatrixButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.adjMatrixButton.Image = global::VisualDijkstraRemake.Properties.Resources.matrix;
            this.adjMatrixButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adjMatrixButton.Name = "adjMatrixButton";
            this.adjMatrixButton.Size = new System.Drawing.Size(36, 36);
            this.adjMatrixButton.Text = "Calculate adjacency matrix";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(7, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 118);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(784, 93);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button5.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.button5.Location = new System.Drawing.Point(430, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 94);
            this.button5.TabIndex = 4;
            this.button5.Text = "New";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button4.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.button4.Location = new System.Drawing.Point(324, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 94);
            this.button4.TabIndex = 3;
            this.button4.Text = "New";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button3.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.button3.Location = new System.Drawing.Point(218, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 94);
            this.button3.TabIndex = 2;
            this.button3.Text = "New";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.button2.Location = new System.Drawing.Point(112, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 94);
            this.button2.TabIndex = 1;
            this.button2.Text = "New";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "New";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 76);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 524);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Visual Dijkstra";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newGraphButton;
        private System.Windows.Forms.ToolStripButton openGraphButton;
        private System.Windows.Forms.ToolStripButton saveGraphButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addNodeButton;
        private System.Windows.Forms.ToolStripButton removeNodeButton;
        private System.Windows.Forms.ToolStripButton addEdgeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton calculatePathButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton adjMatrixButton;
        private Controls.ScrollPanel scrollPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

