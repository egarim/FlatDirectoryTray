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
            SetupDirectoryListContextMenu(); // Set up the context menu
            LoadDirectories(); // Load saved directories

            // Add form closing event to save directories when the application closes
            this.FormClosing += MainForm_FormClosing;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDirectories(); // Save directories when the form is closing
        }

        private readonly string filtersFileName = "filters.txt";
        // File name for storing directories
        private readonly string directoriesFileName = "directories.txt";

        // Save directories to file
        private void SaveDirectories()
        {
            try
            {
                // Get the application's current directory
                string filePath = Path.Combine(Application.StartupPath, directoriesFileName);

                // Create a list to store valid directories
                List<string> validDirectories = new List<string>();

                // Check if directories still exist before saving them
                foreach (string dir in flattenedDirectories)
                {
                    if (Directory.Exists(dir))
                    {
                        validDirectories.Add(dir);
                    }
                }

                // Write all valid directories to the file
                File.WriteAllLines(filePath, validDirectories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving directories: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load directories from file
        private void LoadDirectories()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, directoriesFileName);

                // If file exists, load it
                if (File.Exists(filePath))
                {
                    // Clear existing directories
                    flattenedDirectories.Clear();
                    listBoxDirectories.Items.Clear();

                    // Read all directories from the file and add them
                    string[] savedDirectories = File.ReadAllLines(filePath);
                    foreach (string directory in savedDirectories)
                    {
                        if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
                        {
                            flattenedDirectories.Add(directory);
                            listBoxDirectories.Items.Add(directory);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading directories: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFilters()
        {
            try
            {
                // Get the application's current directory
                string filePath = Path.Combine(Application.StartupPath, filtersFileName);

                // Write all filters to the file
                File.WriteAllLines(filePath, folderFilters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving filters: {ex.Message}", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilters()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, filtersFileName);

                // If file exists, load it
                if (File.Exists(filePath))
                {
                    // Clear existing filters
                    folderFilters.Clear();
                    dataGridViewFilters.Rows.Clear();

                    // Read all filters from the file and add them
                    string[] savedFilters = File.ReadAllLines(filePath);
                    foreach (string filter in savedFilters)
                    {
                        if (!string.IsNullOrWhiteSpace(filter))
                        {
                            folderFilters.Add(filter);
                            dataGridViewFilters.Rows.Add(filter);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filters: {ex.Message}", "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupFilterGrid()
        {
            // Configure the DataGridView for folder filters
            dataGridViewFilters.ColumnCount = 1;
            dataGridViewFilters.Columns[0].Name = "Folder Name to Skip";
            dataGridViewFilters.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Load filters from file if it exists
            LoadFilters();

            // If no filters were loaded, add default ones
            if (folderFilters.Count == 0)
            {
                // Add common folders to skip in a C# solution
                string[] commonFolders = new string[]
                {
            ".git",
            ".vs",
            "bin",
            "obj",
            "node_modules",
            "packages",
            ".github",
            "TestResults",
            ".nuget",
            ".svn",
            "Debug",
            "Release",
            "x64",
            "x86",
            "AnyCPU"
                };

                // Add all folder filters
                foreach (var folder in commonFolders)
                {
                    dataGridViewFilters.Rows.Add(folder);
                    folderFilters.Add(folder);
                }

                // Save the default filters
                SaveFilters();
            }
        }



        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            string filter = Microsoft.VisualBasic.Interaction.InputBox("Enter folder name to skip:", "Add Filter", "");

            if (!string.IsNullOrWhiteSpace(filter))
            {
                dataGridViewFilters.Rows.Add(filter);
                folderFilters.Add(filter);
                SaveFilters(); // Save after adding a filter
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

                SaveFilters(); // Save after removing a filter
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

                // Save directories after adding new ones
                SaveDirectories();

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
        // Add this to the InitializeComponent method in MainForm.Designer.cs or create a separate method and call it in the constructor
        private void SetupDirectoryListContextMenu()
        {
            // Create context menu for the listBoxDirectories
            ContextMenuStrip directoryContextMenu = new ContextMenuStrip();

            // Add "Open" menu item
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open");
            openMenuItem.Click += (sender, e) =>
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
                }
            };

            // Add "Remove" menu item
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("Remove");
            removeMenuItem.Click += (sender, e) =>
            {
                if (listBoxDirectories.SelectedItem != null)
                {
                    string selectedPath = listBoxDirectories.SelectedItem.ToString();
                    flattenedDirectories.Remove(selectedPath);
                    listBoxDirectories.Items.Remove(selectedPath);
                    SaveDirectories(); // Save after removing an item
                }
            };

            // Add menu items to context menu
            directoryContextMenu.Items.Add(openMenuItem);
            directoryContextMenu.Items.Add(removeMenuItem);

            // Assign context menu to listBoxDirectories
            listBoxDirectories.ContextMenuStrip = directoryContextMenu;
        }


    }
}
