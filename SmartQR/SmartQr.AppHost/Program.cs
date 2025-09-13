var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SmartQr_Api>("smartqr-api");

builder.Build().Run();
