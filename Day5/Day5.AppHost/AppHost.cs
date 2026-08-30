var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Day5>("day5");

builder.Build().Run();
