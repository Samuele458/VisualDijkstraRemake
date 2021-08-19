
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
            this.statesView1 = new VisualDijkstraRemake.Views.StatesView();
            this.toolbar = new System.Windows.Forms.TabControl();
            this.fileTab = new System.Windows.Forms.TabPage();
            this.saveAsButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.saveButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.openButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.exitButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.graphTab = new System.Windows.Forms.TabPage();
            this.solvePathButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.newGraphButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.addEdgeButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.deleteNodeButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.addNodeButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.styleTab = new System.Windows.Forms.TabPage();
            this.gridSlimRadioButton = new System.Windows.Forms.RadioButton();
            this.gridDarkRadioButton = new System.Windows.Forms.RadioButton();
            this.gridLightRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gridNoneRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomTrackbar = new System.Windows.Forms.TrackBar();
            this.zoomOutButton = new VisualDijkstraRemake.Controls.FlatButton();
            this.zoomInButton = new VisualDijkstraRemake.Controls.FlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.fileTab.SuspendLayout();
            this.graphTab.SuspendLayout();
            this.styleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackbar)).BeginInit();
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
            this.mainSplitContainer.Panel2.Controls.Add(this.statesView1);
            this.mainSplitContainer.Size = new System.Drawing.Size(1145, 553);
            this.mainSplitContainer.SplitterDistance = 858;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // scrollPanel1
            // 
            this.scrollPanel1.AutoScroll = true;
            this.scrollPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel1.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel1.Name = "scrollPanel1";
            this.scrollPanel1.Size = new System.Drawing.Size(856, 551);
            this.scrollPanel1.TabIndex = 0;
            // 
            // statesView1
            // 
            this.statesView1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statesView1.Controller = null;
            this.statesView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statesView1.Location = new System.Drawing.Point(0, 0);
            this.statesView1.Name = "statesView1";
            this.statesView1.Size = new System.Drawing.Size(281, 551);
            this.statesView1.TabIndex = 0;
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
            this.toolbar.Size = new System.Drawing.Size(1145, 125);
            this.toolbar.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.toolbar.TabIndex = 2;
            this.toolbar.TabStop = false;
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
            this.fileTab.Size = new System.Drawing.Size(1137, 97);
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
            this.saveAsButton.Image = global::VisualDijkstraRemake.Properties.Resources.saveas;
            this.saveAsButton.Location = new System.Drawing.Point(231, 6);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(70, 88);
            this.saveAsButton.TabIndex = 5;
            this.saveAsButton.Text = "Save as...";
            this.saveAsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveAsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = global::VisualDijkstraRemake.Properties.Resources.save;
            this.saveButton.Location = new System.Drawing.Point(155, 6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 88);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.AutoSize = true;
            this.openButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Image = global::VisualDijkstraRemake.Properties.Resources.folder;
            this.openButton.Location = new System.Drawing.Point(79, 6);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(70, 88);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open";
            this.openButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Image = global::VisualDijkstraRemake.Properties.Resources.logout;
            this.exitButton.Location = new System.Drawing.Point(3, 6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(70, 88);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // graphTab
            // 
            this.graphTab.Controls.Add(this.solvePathButton);
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
            // solvePathButton
            // 
            this.solvePathButton.AutoSize = true;
            this.solvePathButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.solvePathButton.FlatAppearance.BorderSize = 0;
            this.solvePathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solvePathButton.Image = global::VisualDijkstraRemake.Properties.Resources.path;
            this.solvePathButton.Location = new System.Drawing.Point(332, 6);
            this.solvePathButton.Name = "solvePathButton";
            this.solvePathButton.Size = new System.Drawing.Size(88, 88);
            this.solvePathButton.TabIndex = 10;
            this.solvePathButton.TabStop = false;
            this.solvePathButton.Text = "Evaluate path";
            this.solvePathButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.solvePathButton.UseVisualStyleBackColor = true;
            this.solvePathButton.Click += new System.EventHandler(this.solvePathButton_Click);
            // 
            // newGraphButton
            // 
            this.newGraphButton.AutoSize = true;
            this.newGraphButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGraphButton.FlatAppearance.BorderSize = 0;
            this.newGraphButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGraphButton.Image = global::VisualDijkstraRemake.Properties.Resources._new;
            this.newGraphButton.Location = new System.Drawing.Point(3, 3);
            this.newGraphButton.Name = "newGraphButton";
            this.newGraphButton.Size = new System.Drawing.Size(75, 88);
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
            this.addEdgeButton.Location = new System.Drawing.Point(246, 6);
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.Size = new System.Drawing.Size(80, 88);
            this.addEdgeButton.TabIndex = 8;
            this.addEdgeButton.Text = "Create edge";
            this.addEdgeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addEdgeButton.UseVisualStyleBackColor = true;
            this.addEdgeButton.Click += new System.EventHandler(this.addEdgeButton_Click);
            // 
            // deleteNodeButton
            // 
            this.deleteNodeButton.AutoSize = true;
            this.deleteNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteNodeButton.FlatAppearance.BorderSize = 0;
            this.deleteNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteNodeButton.Image = global::VisualDijkstraRemake.Properties.Resources.delete;
            this.deleteNodeButton.Location = new System.Drawing.Point(160, 6);
            this.deleteNodeButton.Name = "deleteNodeButton";
            this.deleteNodeButton.Size = new System.Drawing.Size(80, 88);
            this.deleteNodeButton.TabIndex = 7;
            this.deleteNodeButton.Text = "Delete node";
            this.deleteNodeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteNodeButton.UseVisualStyleBackColor = true;
            this.deleteNodeButton.Click += new System.EventHandler(this.deleteNodeButton_Click);
            // 
            // addNodeButton
            // 
            this.addNodeButton.AutoSize = true;
            this.addNodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addNodeButton.FlatAppearance.BorderSize = 0;
            this.addNodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNodeButton.Image = global::VisualDijkstraRemake.Properties.Resources.add;
            this.addNodeButton.Location = new System.Drawing.Point(84, 6);
            this.addNodeButton.Name = "addNodeButton";
            this.addNodeButton.Size = new System.Drawing.Size(70, 88);
            this.addNodeButton.TabIndex = 6;
            this.addNodeButton.TabStop = false;
            this.addNodeButton.Text = "Add node";
            this.addNodeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addNodeButton.UseVisualStyleBackColor = true;
            this.addNodeButton.Click += new System.EventHandler(this.addNodeButton_Click);
            // 
            // styleTab
            // 
            this.styleTab.Controls.Add(this.gridSlimRadioButton);
            this.styleTab.Controls.Add(this.gridDarkRadioButton);
            this.styleTab.Controls.Add(this.gridLightRadioButton);
            this.styleTab.Controls.Add(this.label2);
            this.styleTab.Controls.Add(this.gridNoneRadioButton);
            this.styleTab.Controls.Add(this.label1);
            this.styleTab.Controls.Add(this.zoomTrackbar);
            this.styleTab.Controls.Add(this.zoomOutButton);
            this.styleTab.Controls.Add(this.zoomInButton);
            this.styleTab.Location = new System.Drawing.Point(4, 24);
            this.styleTab.Name = "styleTab";
            this.styleTab.Padding = new System.Windows.Forms.Padding(3);
            this.styleTab.Size = new System.Drawing.Size(929, 97);
            this.styleTab.TabIndex = 3;
            this.styleTab.Text = "Style";
            this.styleTab.UseVisualStyleBackColor = true;
            // 
            // gridSlimRadioButton
            // 
            this.gridSlimRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gridSlimRadioButton.FlatAppearance.BorderSize = 0;
            this.gridSlimRadioButton.Image = global::VisualDijkstraRemake.Properties.Resources.preview_grid_3;
            this.gridSlimRadioButton.Location = new System.Drawing.Point(291, 47);
            this.gridSlimRadioButton.Name = "gridSlimRadioButton";
            this.gridSlimRadioButton.Size = new System.Drawing.Size(65, 52);
            this.gridSlimRadioButton.TabIndex = 8;
            this.gridSlimRadioButton.TabStop = true;
            this.gridSlimRadioButton.Text = "Slim";
            this.gridSlimRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gridSlimRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.gridSlimRadioButton.UseVisualStyleBackColor = true;
            this.gridSlimRadioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRadioButtons_MouseClick);
            // 
            // gridDarkRadioButton
            // 
            this.gridDarkRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gridDarkRadioButton.FlatAppearance.BorderSize = 0;
            this.gridDarkRadioButton.Image = global::VisualDijkstraRemake.Properties.Resources.preview_grid_2;
            this.gridDarkRadioButton.Location = new System.Drawing.Point(220, 47);
            this.gridDarkRadioButton.Name = "gridDarkRadioButton";
            this.gridDarkRadioButton.Size = new System.Drawing.Size(65, 52);
            this.gridDarkRadioButton.TabIndex = 7;
            this.gridDarkRadioButton.TabStop = true;
            this.gridDarkRadioButton.Text = "Dark";
            this.gridDarkRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gridDarkRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.gridDarkRadioButton.UseVisualStyleBackColor = true;
            this.gridDarkRadioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRadioButtons_MouseClick);
            // 
            // gridLightRadioButton
            // 
            this.gridLightRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gridLightRadioButton.FlatAppearance.BorderSize = 0;
            this.gridLightRadioButton.Image = global::VisualDijkstraRemake.Properties.Resources.preview_grid_1;
            this.gridLightRadioButton.Location = new System.Drawing.Point(148, 47);
            this.gridLightRadioButton.Name = "gridLightRadioButton";
            this.gridLightRadioButton.Size = new System.Drawing.Size(65, 52);
            this.gridLightRadioButton.TabIndex = 6;
            this.gridLightRadioButton.TabStop = true;
            this.gridLightRadioButton.Text = "Light";
            this.gridLightRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gridLightRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.gridLightRadioButton.UseVisualStyleBackColor = true;
            this.gridLightRadioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRadioButtons_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grid:";
            // 
            // gridNoneRadioButton
            // 
            this.gridNoneRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gridNoneRadioButton.FlatAppearance.BorderSize = 0;
            this.gridNoneRadioButton.Image = global::VisualDijkstraRemake.Properties.Resources.none;
            this.gridNoneRadioButton.Location = new System.Drawing.Point(77, 47);
            this.gridNoneRadioButton.Name = "gridNoneRadioButton";
            this.gridNoneRadioButton.Size = new System.Drawing.Size(65, 52);
            this.gridNoneRadioButton.TabIndex = 4;
            this.gridNoneRadioButton.TabStop = true;
            this.gridNoneRadioButton.Text = "None";
            this.gridNoneRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gridNoneRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.gridNoneRadioButton.UseVisualStyleBackColor = true;
            this.gridNoneRadioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridRadioButtons_MouseClick);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(18, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 2);
            this.label1.TabIndex = 3;
            // 
            // zoomTrackbar
            // 
            this.zoomTrackbar.AutoSize = false;
            this.zoomTrackbar.BackColor = System.Drawing.Color.White;
            this.zoomTrackbar.Location = new System.Drawing.Point(62, 15);
            this.zoomTrackbar.Maximum = 30;
            this.zoomTrackbar.Minimum = 1;
            this.zoomTrackbar.Name = "zoomTrackbar";
            this.zoomTrackbar.Size = new System.Drawing.Size(237, 22);
            this.zoomTrackbar.TabIndex = 0;
            this.zoomTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.zoomTrackbar.Value = 10;
            this.zoomTrackbar.ValueChanged += new System.EventHandler(this.zoomTrackbar_ValueChanged);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.FlatAppearance.BorderSize = 0;
            this.zoomOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOutButton.Image = global::VisualDijkstraRemake.Properties.Resources.zoom_out;
            this.zoomOutButton.Location = new System.Drawing.Point(12, 6);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(44, 40);
            this.zoomOutButton.TabIndex = 2;
            this.zoomOutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.FlatAppearance.BorderSize = 0;
            this.zoomInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomInButton.Image = global::VisualDijkstraRemake.Properties.Resources.zoom_in;
            this.zoomInButton.Location = new System.Drawing.Point(305, 6);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(44, 40);
            this.zoomInButton.TabIndex = 1;
            this.zoomInButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 678);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Visual Dijkstra";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.fileTab.ResumeLayout(false);
            this.fileTab.PerformLayout();
            this.graphTab.ResumeLayout(false);
            this.graphTab.PerformLayout();
            this.styleTab.ResumeLayout(false);
            this.styleTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackbar)).EndInit();
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
        private Views.StatesView statesView1;
        private Controls.FlatButton solvePathButton;
        private System.Windows.Forms.TrackBar zoomTrackbar;
        private Controls.FlatButton zoomInButton;
        private Controls.FlatButton zoomOutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton gridNoneRadioButton;
        private System.Windows.Forms.RadioButton gridSlimRadioButton;
        private System.Windows.Forms.RadioButton gridDarkRadioButton;
        private System.Windows.Forms.RadioButton gridLightRadioButton;
    }
}

