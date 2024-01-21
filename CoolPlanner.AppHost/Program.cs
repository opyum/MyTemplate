var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var apiservice = builder.AddProject<Projects.CoolPlanner_ApiService>("apiservice");

//builder.AddProject<Projects.CoolPlanner_Web>("webfrontend")
//    .WithReference(cache)
//    .WithReference(apiservice);

var apiLogin = builder.AddProject<Projects.CoolPlanner_ApiLogin>("apilogin");

builder.AddProject<Projects.TestSF>("front")
    .WithReference(cache)
    .WithReference(apiservice)
    .WithReference(apiLogin);

builder.Build().Run();
