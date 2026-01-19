using MissionConfigManager.Core;
using MissionConfigManager.Data;
using Microsoft.EntityFrameworkCore;
using MissionConfigManager.Api.DTOs;



//Console.WriteLine("Program.cs started...");
var builder = WebApplication.CreateBuilder(args);


//Console.WriteLine("Before AddDbContext...");
builder.Services.AddDbContext<MissionDbContext>(options =>
    options.UseSqlite("Data Source=../MissionConfigManager.Data/mission.db"));
//Console.WriteLine("After AddDbContext...");

//Console.WriteLine("Before Build...");
var app = builder.Build();
//Console.WriteLine("After Build...");


//Console.WriteLine("Before MapPost...");
app.MapPost("/import-xml", async (MissionDbContext db, HttpRequest request) =>
{
    if (!request.HasFormContentType)
        return Results.BadRequest("Upload an XML file using multipart/form-data.");

    var form = await request.ReadFormAsync();
    var file = form.Files.GetFile("file");

    if (file == null)
        return Results.BadRequest("Missing XML file.");

    using var stream = file.OpenReadStream();
    using var reader = new StreamReader(stream);
    var xmlContent = await reader.ReadToEndAsync();

    // Parse XML into modules
    var modules = XmlConfigLoader.LoadFromString(xmlContent);

    // Save to DB
    db.Modules.AddRange(modules);
    await db.SaveChangesAsync();

    return Results.Ok(new { Imported = modules.Count });
});
//Console.WriteLine("After MapPost...");

//Console.WriteLine("Before MapGet...");
app.MapGet("/modules", async (MissionDbContext db) =>
{
    var modules = await db.Modules
        .Include(m => m.Parameters)
        .ToListAsync();

    return modules.Select(m => new ModuleDto
    {
        Id = m.Id,
        Name = m.Name,
        Parameters = m.Parameters.Select(p => new ParameterDto
        {
            Key = p.Key,
            Value = p.Value
        }).ToList()
    });
});
//Console.WriteLine("After MapGet...");
app.Run();