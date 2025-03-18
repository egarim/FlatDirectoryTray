namespace FlatDirectoryTray
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFlatDirectory;
        private System.Windows.Forms.Panel panelDirectoryList;
        private System.Windows.Forms.ListBox listBoxDirectories;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.DataGridView dataGridViewFilters;
        private System.Windows.Forms.Button buttonAddFilter;
        private System.Windows.Forms.Button buttonRemoveFilter;
        private System.Windows.Forms.Label labelDropIndicator;
        private System.Windows.Forms.ProgressBar progressBarCopy;
        private System.Windows.Forms.Label labelCopyStatus;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Form1";

            this.panelFlatDirectory = new System.Windows.Forms.Panel();
            this.panelDirectoryList = new System.Windows.Forms.Panel();
            this.listBoxDirectories = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.dataGridViewFilters = new System.Windows.Forms.DataGridView();
            this.buttonAddFilter = new System.Windows.Forms.Button();
            this.buttonRemoveFilter = new System.Windows.Forms.Button();
            this.labelDropIndicator = new System.Windows.Forms.Label();
            this.progressBarCopy = new System.Windows.Forms.ProgressBar();
            this.labelCopyStatus = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 500);
            this.tabControl.TabIndex = 0;
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageFilters);
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.Resize += new System.EventHandler(this.tabControl_Resize);

            // 
            // tabPageMain
            // 
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(792, 472);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Directories";
            this.tabPageMain.UseVisualStyleBackColor = true;
            this.tabPageMain.Controls.Add(this.labelDropIndicator);
            this.tabPageMain.Controls.Add(this.progressBarCopy);
            this.tabPageMain.Controls.Add(this.labelCopyStatus);
            this.tabPageMain.Controls.Add(this.panelDirectoryList);
            this.tabPageMain.Controls.Add(this.panelFlatDirectory);
            this.tabPageMain.AllowDrop = true;
            this.tabPageMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabPageMain_DragEnter);
            this.tabPageMain.DragLeave += new System.EventHandler(this.tabPageMain_DragLeave);

            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Location = new System.Drawing.Point(4, 24);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(792, 472);
            this.tabPageFilters.TabIndex = 1;
            this.tabPageFilters.Text = "Folder Filters";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            this.tabPageFilters.Controls.Add(this.dataGridViewFilters);
            this.tabPageFilters.Controls.Add(this.buttonAddFilter);
            this.tabPageFilters.Controls.Add(this.buttonRemoveFilter);

            // 
            // labelDropIndicator
            // 
            this.labelDropIndicator.AutoSize = true;
            this.labelDropIndicator.BackColor = System.Drawing.Color.LightBlue;
            this.labelDropIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDropIndicator.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDropIndicator.Location = new System.Drawing.Point(12, 12);
            this.labelDropIndicator.Name = "labelDropIndicator";
            this.labelDropIndicator.Padding = new System.Windows.Forms.Padding(10);
            this.labelDropIndicator.Size = new System.Drawing.Size(250, 47);
            this.labelDropIndicator.TabIndex = 2;
            this.labelDropIndicator.Text = "Drop Files Here";
            this.labelDropIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDropIndicator.Visible = true;

            // 
            // progressBarCopy
            // 
            this.progressBarCopy.Location = new System.Drawing.Point(12, 285);
            this.progressBarCopy.Name = "progressBarCopy";
            this.progressBarCopy.Size = new System.Drawing.Size(200, 23);
            this.progressBarCopy.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarCopy.TabIndex = 3;
            this.progressBarCopy.Visible = false;

            // 
            // labelCopyStatus
            // 
            this.labelCopyStatus.AutoSize = true;
            this.labelCopyStatus.Location = new System.Drawing.Point(218, 289);
            this.labelCopyStatus.Name = "labelCopyStatus";
            this.labelCopyStatus.Size = new System.Drawing.Size(122, 15);
            this.labelCopyStatus.TabIndex = 4;
            this.labelCopyStatus.Text = "Copying files...";
            this.labelCopyStatus.Visible = false;

            // 
            // panelFlatDirectory
            // 
            this.panelFlatDirectory.AllowDrop = true;
            this.panelFlatDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFlatDirectory.Location = new System.Drawing.Point(12, 12);
            this.panelFlatDirectory.Name = "panelFlatDirectory";
            this.panelFlatDirectory.Size = new System.Drawing.Size(300, 300);
            this.panelFlatDirectory.TabIndex = 0;
            this.panelFlatDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelFlatDirectory_DragDrop);
            this.panelFlatDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelFlatDirectory_DragEnter);

            // 
            // panelDirectoryList
            // 
            this.panelDirectoryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDirectoryList.Controls.Add(this.listBoxDirectories);
            this.panelDirectoryList.Location = new System.Drawing.Point(318, 12);
            this.panelDirectoryList.Name = "panelDirectoryList";
            this.panelDirectoryList.Size = new System.Drawing.Size(462, 448);
            this.panelDirectoryList.TabIndex = 1;
            this.panelDirectoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                           | System.Windows.Forms.AnchorStyles.Left)
                                           | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // listBoxDirectories
            // 
            this.listBoxDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDirectories.FormattingEnabled = true;
            this.listBoxDirectories.ItemHeight = 15;
            this.listBoxDirectories.Location = new System.Drawing.Point(0, 0);
            this.listBoxDirectories.Name = "listBoxDirectories";
            this.listBoxDirectories.Size = new System.Drawing.Size(460, 446);
            this.listBoxDirectories.TabIndex = 0;
            this.listBoxDirectories.DoubleClick += new System.EventHandler(this.listBoxDirectories_DoubleClick);

            // 
            // dataGridViewFilters
            // 
            this.dataGridViewFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilters.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewFilters.Name = "dataGridViewFilters";
            this.dataGridViewFilters.Size = new System.Drawing.Size(768, 400);
            this.dataGridViewFilters.TabIndex = 0;
            this.dataGridViewFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                             | System.Windows.Forms.AnchorStyles.Left)
                                             | System.Windows.Forms.AnchorStyles.Right)));

            // 
            // buttonAddFilter
            // 
            this.buttonAddFilter.Location = new System.Drawing.Point(12, 418);
            this.buttonAddFilter.Name = "buttonAddFilter";
            this.buttonAddFilter.Size = new System.Drawing.Size(100, 23);
            this.buttonAddFilter.TabIndex = 1;
            this.buttonAddFilter.Text = "Add Filter";
            this.buttonAddFilter.UseVisualStyleBackColor = true;
            this.buttonAddFilter.Click += new System.EventHandler(this.buttonAddFilter_Click);
            this.buttonAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

            // 
            // buttonRemoveFilter
            // 
            this.buttonRemoveFilter.Location = new System.Drawing.Point(118, 418);
            this.buttonRemoveFilter.Name = "buttonRemoveFilter";
            this.buttonRemoveFilter.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveFilter.TabIndex = 2;
            this.buttonRemoveFilter.Text = "Remove Filter";
            this.buttonRemoveFilter.UseVisualStyleBackColor = true;
            this.buttonRemoveFilter.Click += new System.EventHandler(this.buttonRemoveFilter_Click);
            this.buttonRemoveFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Flat Directory Tray";
            this.Resize += new System.EventHandler(this.MainForm_Resize);

            this.panelDirectoryList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilters)).BeginInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
