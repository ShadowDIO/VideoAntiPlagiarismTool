var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Services>("services");
builder.AddProject<Projects.Services>("dal");

builder.Build().Run();
