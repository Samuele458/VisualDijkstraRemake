
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
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(3, 100, 3, 3);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.scrollPanel1);
            this.mainSplitContainer.Size = new System.Drawing.Size(800, 450);
            this.mainSplitContainer.SplitterDistance = 415;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // scrollPanel1
            // 
            this.scrollPanel1.AutoScroll = true;
            this.scrollPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel1.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel1.Name = "scrollPanel1";
            this.scrollPanel1.Size = new System.Drawing.Size(415, 450);
            this.scrollPanel1.TabIndex = 0;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.CanOverflow = false;
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
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(800, 39);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Visual Dijkstra";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

