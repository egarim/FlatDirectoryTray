using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatDirectoryTray
{
    public class FolderCopyContextMenu 
    {


        public static string CopyFilesWithPrefix(string DirectoryPath)
        {
            try
            {
                string sourceDir = DirectoryPath;
                string tempDir = Path.Combine(Path.GetTempPath(), "FolderCopy_" + Guid.NewGuid().ToString());

                Directory.CreateDirectory(tempDir);

                string[] files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
                Dictionary<string, string> fileIndex = new Dictionary<string, string>();

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
                    fileIndex[filePath] = destPath;
                }

                string indexPath = Path.Combine(tempDir, "DirectoryFileIndex.txt");
                using (StreamWriter writer = new StreamWriter(indexPath))
                {
                    foreach (var entry in fileIndex)
                    {
                        writer.WriteLine($"{entry.Key} -> {entry.Value}");
                    }
                }

                MessageBox.Show($"Files copied to: {tempDir}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return tempDir;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
