
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
            this.toolbar = new System.Windows.Forms.TabControl();
            this.fileTab = new System.Windows.Forms.TabPage();
            this.saveAsButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.saveButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.openButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.exitButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.graphTab = new System.Windows.Forms.TabPage();
            this.newGraphButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.addEdgeButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.deleteNodeButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.addNodeButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.styleTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.fileTab.SuspendLayout();
            this.graphTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.CausesValidation = false;
            this.mainSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 125);
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
            this.mainSplitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.mainSplitContainer_Panel2_Paint);
            this.mainSplitContainer.Size = new System.Drawing.Size(937, 446);
            this.mainSplitContainer.SplitterDistance = 482;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // scrollPanel1
            // 
            this.scrollPanel1.AutoScroll = true;
            this.scrollPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel1.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel1.Name = "scrollPanel1";
            this.scrollPanel1.Size = new System.Drawing.Size(480, 444);
            this.scrollPanel1.TabIndex = 0;
            // 
            // toolbar
            // 
            this.toolbar.Controls.Add(this.fileTab);
            this.toolbar.Controls.Add(this.graphTab);
            this.toolbar.Controls.Add(this.styleTab);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.ItemSize = new System.Drawing.Size(100, 20);
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.SelectedIndex = 0;
            this.toolbar.Size = new System.Drawing.Size(937, 125);
            this.toolbar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.toolbar.TabIndex = 1;
            // 
            // fileTab
            // 
            this.fileTab.Controls.Add(this.saveAsButton);
            this.fileTab.Controls.Add(this.saveButton);
            this.fileTab.Controls.Add(this.openButton);
            this.fileTab.Controls.Add(this.exitButton);
            this.fileTab.Location = new System.Drawing.Point(4, 24);
            this.fileTab.Name = "fileTab";
            this.fileTab.Padding = new System.Windows.Forms.Padding(3);
            this.fileTab.Size = new System.Drawing.Size(929, 97);
            this.fileTab.TabIndex = 0;
            this.fileTab.Text = "File";
            this.fileTab.UseVisualStyleBackColor = true;
            // 
            // saveAsButton
            // 
            this.saveAsButton.AutoSize = true;
            this.saveAsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveAsButton.FlatAppearance.BorderSize = 0;
            this.saveAsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAsButton.Image = global::VisualDijkstraRemake.Properties.Resources.save;
            this.saveAsButton.Location = new System.Drawing.Point(254, 6);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(76, 89);
            this.saveAsButton.TabIndex = 5;
            this.saveAsButton.Text = "Save as...";
            this.saveAsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveAsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveAsButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = global::VisualDijkstraRemake.Properties.Resources.save;
            this.saveButton.Location = new System.Drawing.Point(172, 6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(76, 89);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // openButton
            // 
            this.openButton.AutoSize = true;
            this.openButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Image = global::VisualDijkstraRemake.Properties.Resources.folder;
            this.openButton.Location = new System.Drawing.Point(90, 6);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(76, 89);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open";
            this.openButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Image = global::VisualDijkstraRemake.Properties.Resources.logout;
            this.exitButton.Location = new System.Drawing.Point(8, 6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(76, 89);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // graphTab
            // 
            this.graphTab.Controls.Add(this.newGraphButton);
            this.graphTab.Controls.Add(this.addEdgeButton);
            this.graphTab.Controls.Add(this.deleteNodeButton);
            this.graphTab.Controls.Add(this.addNodeButton);
            this.graphTab.Location = new System.Drawing.Point(4, 24);
            this.graphTab.Name = "graphTab";
            this.graphTab.Padding = new System.Windows.Forms.Padding(3);
            this.graphTab.Size = new System.Drawing.Size(929, 97);
            this.graphTab.TabIndex = 2;
            this.graphTab.Text = "Graph";
            this.graphTab.UseVisualStyleBackColor = true;
            // 
            // newGraphButton
            // 
            this.newGraphButton.AutoSize = true;
            this.newGraphButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGraphButton.FlatAppearance.BorderSize = 0;
            this.newGraphButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGraphButton.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.newGraphButton.Location = new System.Drawing.Point(262, 6);
            this.newGraphButton.Name = "newGraphButton";
            this.newGraphButton.Size = new System.Drawing.Size(80, 89);
            this.newGraphButton.TabIndex = 9;
            this.newGraphButton.Text = "New graph";
            this.newGraphButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newGraphButton.UseVisualStyleBackColor = true;
            this.newGraphButton.Click += new System.EventHandler(this.newGraphButton_Click);
            // 
            // addEdgeButton
            // 
            this.addEdgeButton.AutoSize = true;
            this.addEdgeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addEdgeButton.FlatAppearance.BorderSize = 0;
            this.addEdgeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEdgeButton.Image = global::VisualDijkstraRemake.Properties.Resources.route;
            this.addEdgeButton.Location = new System.Drawing.Point(176, 6);
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.Size = new System.Drawing.Size(80, 89);
            this.addEdgeButton.TabIndex = 8;
            this.addEdgeButton.Text = "Create edge";
            this.addEdgeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addEdgeButton.UseVisualStyleBackColor = true;
            // 
            // deleteNodeButton
            // 
            this.deleteNodeButton.AutoSize = true;
            this.deleteNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteNodeButton.FlatAppearance.BorderSize = 0;
            this.deleteNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteNodeButton.Image = global::VisualDijkstraRemake.Properties.Resources.delete;
            this.deleteNodeButton.Location = new System.Drawing.Point(90, 6);
            this.deleteNodeButton.Name = "deleteNodeButton";
            this.deleteNodeButton.Size = new System.Drawing.Size(80, 89);
            this.deleteNodeButton.TabIndex = 7;
            this.deleteNodeButton.Text = "Delete node";
            this.deleteNodeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteNodeButton.UseVisualStyleBackColor = true;
            // 
            // addNodeButton
            // 
            this.addNodeButton.AutoSize = true;
            this.addNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addNodeButton.FlatAppearance.BorderSize = 0;
            this.addNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNodeButton.Image = global::VisualDijkstraRemake.Properties.Resources.add;
            this.addNodeButton.Location = new System.Drawing.Point(8, 6);
            this.addNodeButton.Name = "addNodeButton";
            this.addNodeButton.Size = new System.Drawing.Size(76, 89);
            this.addNodeButton.TabIndex = 6;
            this.addNodeButton.Text = "Add node";
            this.addNodeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addNodeButton.UseVisualStyleBackColor = true;
            // 
            // styleTab
            // 
            this.styleTab.Location = new System.Drawing.Point(4, 24);
            this.styleTab.Name = "styleTab";
            this.styleTab.Padding = new System.Windows.Forms.Padding(3);
            this.styleTab.Size = new System.Drawing.Size(929, 97);
            this.styleTab.TabIndex = 3;
            this.styleTab.Text = "Style";
            this.styleTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(937, 571);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Visual Dijkstra";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.fileTab.ResumeLayout(false);
            this.fileTab.PerformLayout();
            this.graphTab.ResumeLayout(false);
            this.graphTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private Controls.ScrollPanel scrollPanel1;
        private System.Windows.Forms.TabControl toolbar;
        private System.Windows.Forms.TabPage fileTab;
        private System.Windows.Forms.TabPage graphTab;
        private System.Windows.Forms.TabPage styleTab;
        private Controls.FlatButton openButton;
        private Controls.FlatButton exitButton;
        private Controls.FlatButton saveAsButton;
        private Controls.FlatButton saveButton;
        private Controls.FlatButton addNodeButton;
        private Controls.FlatButton deleteNodeButton;
        private Controls.FlatButton addEdgeButton;
        private Controls.FlatButton newGraphButton;
    }
}

