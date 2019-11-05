Basic Logger Library
========

Features
--------

- Static (RAM) Based Log Strategy
- API Call Log Strategy
- File Log Strategy


Usage
----------
Getting instance of static logger: 

    Logger logger = new LoggerCreator.LoggerFactory("loggerName", LogStrategy.STATIC);

Getting instance of file logger:
	with default log.txt:

    	Logger logger = new LoggerCreator.LoggerFactory("loggerName", LogStrategy.FILE);

   	with custom log.txt:

   		// new FileStrategy(string FilePath)
   		FileStrategy strategy = new FileStrategy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
   		Logger logger = new LogCreator.LoggerFactory("loggerName", strategy);

Initialize a new Record and send as a log:

	Record record = new Record("This is a test Log");

	logger.Debug(record);
	logger.Info(record);
	logger.Notice(record);
	logger.Warning(record);
	logger.Error(record);
	logger.Critical(record);
	logger.Alert(record);
	logger.Emergency(record);

or: 
	
	record.setLevel(LogLevel.Alert);
	logger.Log(record);

Getting Log List:

	List<IRecord> list = logger.getLogs();