using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatDirectoryTray
{
    public class FolderCopyContextMenu 
    {
     

        public static void CopyFilesWithPrefix(string DirectoryPath)
        {
            try
            {
                string sourceDir = DirectoryPath;
                string tempDir = Path.Combine(Path.GetTempPath(), "FolderCopy_" + Guid.NewGuid().ToString());

                Directory.CreateDirectory(tempDir);

                string[] files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);

                foreach (string filePath in files)
                {
                    string relativePath = Path.GetDirectoryName(filePath)
                        .Substring(sourceDir.Length)
                        .Trim(Path.DirectorySeparatorChar);

                    string fileName = Path.GetFileName(filePath);
                    string prefix = string.IsNullOrEmpty(relativePath)
                        ? ""
                        : relativePath.Replace(Path.DirectorySeparatorChar, '_') + "_";

                    string newFileName = prefix + fileName;
                    string destPath = Path.Combine(tempDir, newFileName);

                    File.Copy(filePath, destPath);
                }

                MessageBox.Show($"Files copied to: {tempDir}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
