namespace LoftwareFixer
{
    public sealed class FileManage
    {

        public string Path { get; set; }

        public FileManage(string path)
        {
            Path = path;
        }

        public int DoWork(string[] fileTypes)
        {
            return ProcessFiles(files: GetFiles(),fileTypes);
        }


        private int ProcessFiles(FileInfo[] files, string[] fileTypes)
        {
            int counter = 0;
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    if (file.Extension != null && file.Exists && !fileTypes.Contains(file.Extension))//Remove this harcoded file type
                    {
                        DeleteFile(file.FullName); counter++;
                    }
                }
            }
            return counter;
        }

        private bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath)) { File.Delete(filePath); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

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
