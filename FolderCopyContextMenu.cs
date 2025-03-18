using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatDirectoryTray
{
    public class FolderCopyContextMenu 
    {

        /// <summary>
        /// Gets all files from a directory while excluding files from folders that match any name in the filter list
        /// </summary>
        /// <param name="directoryPath">The source directory path</param>
        /// <param name="folderFilters">List of folder names to exclude</param>
        /// <returns>A list of file paths excluding those in filtered folders</returns>
        private static IEnumerable<string> GetFilesExcludingFilteredFolders(string directoryPath, List<string> folderFilters)
        {
            // If no filters specified, return all files
            if (folderFilters == null || folderFilters.Count == 0)
            {
                return Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
            }

            var result = new List<string>();

            // Process the root directory first
            result.AddRange(Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly));

            // Process subdirectories recursively, skipping filtered ones
            foreach (var subDir in Directory.GetDirectories(directoryPath))
            {
                var dirName = Path.GetFileName(subDir);

                // Skip this directory if its name is in the filter list
                if (folderFilters.Contains(dirName, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Process this non-filtered directory
                result.AddRange(GetFilesExcludingFilteredFolders(subDir, folderFilters));
            }

            return result;
        }

        public static string CopyFilesWithPrefix(string DirectoryPath, List<string> folderFilters = null)
        {
            try
            {
                string sourceDir = DirectoryPath;
                string tempDir = Path.Combine(Path.GetTempPath(), "FolderCopy_" + Guid.NewGuid().ToString());

                Directory.CreateDirectory(tempDir);

                // Get all files from directory, except those in filtered folders
                var files = GetFilesExcludingFilteredFolders(sourceDir, folderFilters);
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
