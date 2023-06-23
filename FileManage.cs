namespace LoftwareFixer
{
    /// <summary>
    /// A sealed class that manages files in a specified directory.
    /// </summary>
    public sealed class FileManage
    {
        /// <summary>
        /// Gets or sets the path to the directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the FileManage class with the specified path.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        public FileManage(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Processes files in the directory that do not have the specified file types.
        /// </summary>
        /// <param name="fileTypes">An array of file types to exclude from processing.</param>
        /// <returns>The number of files processed.</returns>
        public int DoWork(string[] fileTypes)
        {
            return ProcessFiles(files: GetFiles(), fileTypes);
        }

        /// <summary>
        /// Processes the specified files that do not have the specified file types.
        /// </summary>
        /// <param name="files">An array of FileInfo objects representing the files to process.</param>
        /// <param name="fileTypes">An array of file types to exclude from processing.</param>
        /// <returns>The number of files processed.</returns>
        private int ProcessFiles(FileInfo[] files, string[] fileTypes)
        {
            int counter = 0;
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    if (file.Extension != null && file.Exists && !fileTypes.Contains(file.Extension))
                    {
                        DeleteFile(file.FullName); counter++;
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// Deletes the file at the specified path.
        ///</summary>
        ///<param name="filePath">The path to the file to delete.</param>
        ///<returns>true if the file was deleted; otherwise, false.</returns>
        private bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath)) { File.Delete(filePath); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }


        ///<summary> 
        ///<para>Gets an array of FileInfo objects representing all files in the directory.</para> 
        ///<para>If the Path property is null or if the directory does not exist, this method returns null.</para> 
        ///</summary> 
        ///<returns>An array of FileInfo objects representing all files in the directory; or null if the Path property is null or if the directory does not exist.</returns> 
        private FileInfo[]? GetFiles()
        {
            if (Path != null && Directory.Exists(Path))
            {
                DirectoryInfo d = new DirectoryInfo(Path);
                FileInfo[] fileInfo = d.GetFiles("*");
                return fileInfo;
            }
            return null;
        }

    }
}
