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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            this.panelFlatDirectory = new System.Windows.Forms.Panel();
            this.panelDirectoryList = new System.Windows.Forms.Panel();
            this.listBoxDirectories = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // 
            // panelFlatDirectory
            // 
            this.panelFlatDirectory.AllowDrop = true;
            this.panelFlatDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFlatDirectory.Location = new System.Drawing.Point(12, 12);
            this.panelFlatDirectory.Name = "panelFlatDirectory";
            this.panelFlatDirectory.Size = new System.Drawing.Size(200, 200);
            this.panelFlatDirectory.TabIndex = 0;
            this.panelFlatDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelFlatDirectory_DragDrop);
            this.panelFlatDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelFlatDirectory_DragEnter);

            // 
            // panelDirectoryList
            // 
            this.panelDirectoryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDirectoryList.Controls.Add(this.listBoxDirectories);
            this.panelDirectoryList.Location = new System.Drawing.Point(218, 12);
            this.panelDirectoryList.Name = "panelDirectoryList";
            this.panelDirectoryList.Size = new System.Drawing.Size(200, 200);
            this.panelDirectoryList.TabIndex = 1;

            // 
            // listBoxDirectories
            // 
            this.listBoxDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDirectories.FormattingEnabled = true;
            this.listBoxDirectories.ItemHeight = 15;
            this.listBoxDirectories.Location = new System.Drawing.Point(0, 0);
            this.listBoxDirectories.Name = "listBoxDirectories";
            this.listBoxDirectories.Size = new System.Drawing.Size(198, 198);
            this.listBoxDirectories.TabIndex = 0;
            this.listBoxDirectories.DoubleClick += new System.EventHandler(this.listBoxDirectories_DoubleClick);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 225);
            this.Controls.Add(this.panelDirectoryList);
            this.Controls.Add(this.panelFlatDirectory);
            this.Name = "MainForm";
            this.Text = "Flat Directory Tray";
            this.panelDirectoryList.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
