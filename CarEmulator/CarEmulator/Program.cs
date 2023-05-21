using CarEmulator;

IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices(services =>
	{
		services.AddSingleton<IHostedService, BackgroundService>(services => 
			new Worker(
				services.GetService<ILogger<Worker>>(),
				1
				)
		);
		
		services.AddSingleton<IHostedService, BackgroundService>(services => 
			new Worker(
				services.GetService<ILogger<Worker>>(),
				2
			)
		);
	})
	.Build();

host.Run();