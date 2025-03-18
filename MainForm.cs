using System.Diagnostics;

namespace FlatDirectoryTray
{
    public partial class MainForm : Form
    {
        private List<string> flattenedDirectories;

        public MainForm()
        {
            InitializeComponent();
            flattenedDirectories = new List<string>();
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
            string copiedDirectory = FolderCopyContextMenu.CopyFilesWithPrefix(sourceDirectory);
            if (!string.IsNullOrEmpty(copiedDirectory))
            {
                listBoxDirectories.Items.Add(copiedDirectory);
            }
        }
        private void panelFlatDirectory_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    // Use the FolderCopyContextMenu class to flatten the directory
                    string copiedDirectory = FolderCopyContextMenu.CopyFilesWithPrefix(file);
                    if (!string.IsNullOrEmpty(copiedDirectory))
                    {
                        flattenedDirectories.Add(copiedDirectory);
                        listBoxDirectories.Items.Add(copiedDirectory);
                    }
                }
            }
        }

    }
}
