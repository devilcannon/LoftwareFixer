namespace LoftwareFixer
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        private string[] _validFiles;
        private int _workerDelay;
        private string _folderPath;

        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
            GetConfigFiles();
        }

        private void GetConfigFiles()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json");
            var config = configuration.Build();
            //Type of files
            _validFiles = config.GetSection("AllowedFileTypes").Get<string[]>();
            _workerDelay = config.GetValue<int>("DelayTime");
            _folderPath = config.GetValue<string>("FolderPath");
            _workerDelay += 1000;//Debug only
            _logger.LogInformation("Config file loaded correctly");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try { 
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("WorkerService running at: {time}", DateTimeOffset.Now);//Initial log
                    FileManage mg = new(_folderPath);
                    int value = mg.DoWork(_validFiles);
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