var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.nvDong_Day3>("nvdong-day3");

builder.Build().Run();
