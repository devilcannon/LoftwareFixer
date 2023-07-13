namespace LoftwareFixer
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        private string[]? _validFiles;
        private int _workerDelay;
        private string _folderPath = @"C:\\Users\\Public\\LoftwareFixer";

        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
            GetConfigFiles();
        }

        // Allow get configuration from appsettings.json
        private void GetConfigFiles()
        {
            Setting setting = InitFile.ReadSettingsFile(_folderPath);
            //Type of files
            _validFiles = setting.AllowedFileType;
            _workerDelay = setting.DelayTime;
            _folderPath = setting.Path ?? @"C:\\Users\\Public\\LoftwareFixer";
            _logger.LogInformation("Config file loaded correctly");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try { 
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("WorkerService running at: {time}", DateTimeOffset.Now);//Initial log
                    FileManage mg = new(_folderPath);
                    int value = mg.DoWork(fileTypes: _validFiles);
                    await Task.Delay(_workerDelay, stoppingToken);
                }
            }catch (OperationCanceledException) { }
            catch (Exception ex) { 
                _logger.LogError(ex,"{Message}",ex.Message);
                Environment.Exit(1);
            }
        }
    }
}