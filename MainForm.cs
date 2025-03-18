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

        private void panelFlatDirectory_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    // Use the FolderCopyContextMenu class to flatten the directory
                    // Assuming FolderCopyContextMenu.FlattenDirectory is a static method
                    FolderCopyContextMenu.CopyFilesWithPrefix(file);
                    flattenedDirectories.Add(file);
                    listBoxDirectories.Items.Add(file);
                }
            }
        }
    }
}
