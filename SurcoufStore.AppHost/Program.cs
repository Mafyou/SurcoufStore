var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SurcoufStore_Api>("surcoufstore");

builder.Build().Run();