using System.Diagnostics;

namespace FlatDirectoryTray
{
    public partial class MainForm : Form
    {
        private List<string> flattenedDirectories;
        private List<string> folderFilters;

        public MainForm()
        {
            InitializeComponent();
            flattenedDirectories = new List<string>();
            folderFilters = new List<string>();

            SetupFilterGrid();
        }

        private void SetupFilterGrid()
        {
            // Configure the DataGridView for folder filters
            dataGridViewFilters.ColumnCount = 1;
            dataGridViewFilters.Columns[0].Name = "Folder Name to Skip";
            dataGridViewFilters.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Add some example row
            dataGridViewFilters.Rows.Add(".git");
            folderFilters.Add(".git");
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            string filter = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name to skip:", "Add Filter", "");

            if (!string.IsNullOrWhiteSpace(filter))
            {
                dataGridViewFilters.Rows.Add(filter);
                folderFilters.Add(filter);
            }
        }

        private void buttonRemoveFilter_Click(object sender, EventArgs e)
        {
            if (dataGridViewFilters.SelectedRows.Count > 0)
            {
                // Get the value of the selected folder name
                string selectedFilter = dataGridViewFilters.SelectedRows[0].Cells[0].Value.ToString();

                // Remove from the filters list
                folderFilters.Remove(selectedFilter);

                // Remove the selected row
                dataGridViewFilters.Rows.RemoveAt(dataGridViewFilters.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a filter to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panelFlatDirectory_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBoxDirectories_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxDirectories.SelectedItem != null)
            {
                string selectedPath = listBoxDirectories.SelectedItem.ToString();
                if (Directory.Exists(selectedPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = selectedPath,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                else
                {
                    MessageBox.Show("The selected directory does not exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CopyAndAddDirectory(string sourceDirectory)
        {
            string copiedDirectory = FolderCopyContextMenu.CopyFilesWithPrefix(sourceDirectory, folderFilters);
            if (!string.IsNullOrEmpty(copiedDirectory))
            {
                listBoxDirectories.Items.Add(copiedDirectory);
            }
        }
        // Handle resizing of the form and tab control
        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustTabControlSize();
        }
        // Handle drag and drop indicator
        private void tabPageMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                labelDropIndicator.Visible = true;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tabPageMain_DragLeave(object sender, EventArgs e)
        {
            labelDropIndicator.Visible = false;
        }
        private void tabControl_Resize(object sender, EventArgs e)
        {
            AdjustTabControlSize();
        }

        private void AdjustTabControlSize()
        {
            // Make sure tab control fills the form
            tabControl.Width = this.ClientSize.Width;
            tabControl.Height = this.ClientSize.Height;
        }
        private void panelFlatDirectory_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Hide drop indicator and show copy progress
                labelDropIndicator.Visible = false;
                progressBarCopy.Visible = true;
                labelCopyStatus.Visible = true;

                // Process each file
                foreach (string file in files)
                {
                    try
                    {
                        // Update status to show which file is being copied
                        labelCopyStatus.Text = $"Copying: {Path.GetFileName(file)}...";
                        Application.DoEvents(); // Allow UI to update

                        // Use the FolderCopyContextMenu class to flatten the directory
                        string copiedDirectory = FolderCopyContextMenu.CopyFilesWithPrefix(file, folderFilters);

                        if (!string.IsNullOrEmpty(copiedDirectory))
                        {
                            flattenedDirectories.Add(copiedDirectory);
                            listBoxDirectories.Items.Add(copiedDirectory);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error copying file {Path.GetFileName(file)}: {ex.Message}",
                            "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Hide progress indicators and show completion status
                progressBarCopy.Visible = false;
                labelCopyStatus.Text = "Files copied successfully!";

                // Hide the status message after a few seconds
                Task.Delay(3000).ContinueWith(_ => {
                    if (this.IsDisposed) return;
                    this.Invoke((Action)(() => {
                        labelCopyStatus.Visible = false;
                    }));
                });
            }

            // Always hide the drop indicator when operation is complete
            labelDropIndicator.Visible = false;
        }

    }
}
