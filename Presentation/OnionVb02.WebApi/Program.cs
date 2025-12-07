using System.Linq;
using OnionVb02.Application.DependencyResolvers;
using OnionVb02.InnerInfrastructure.DependencyResolvers;
using OnionVb02.Persistence.DependencyResolvers;
using OnionVb02.WebApi.DependencyResolvers;
using OnionVb02.ValidatorStructor.DependencyResolvers;
using OnionVb02.WebApi.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Generate unique schema IDs while avoiding collisions between similarly named
    // request/response models that live in different namespaces.
    options.CustomSchemaIds(type =>
    {
        var baseName = type.FullName ?? type.Name;

        if (type.IsGenericType)
        {
            var typeArguments = string.Join(",", type.GetGenericArguments()
                .Select(t => t.FullName ?? t.Name));

            // Trim the ``1 suffix Swashbuckle adds for generics and append readable arguments.
            var tickIndex = baseName.IndexOf('`');
            var genericBaseName = tickIndex > 0 ? baseName[..tickIndex] : baseName;
            baseName = $"{genericBaseName}[{typeArguments}]";
        }

        // Replace + with . for nested classes to keep IDs readable and file-system friendly.
        return baseName.Replace("+", ".");
    });
});

builder.Services.AddDbContextService();
builder.Services.AddDtoMapperService();
builder.Services.AddManagerService();
builder.Services.AddRepositoryService();
builder.Services.AddVmMapperService();
builder.Services.AddHandlerService();
builder.Services.AddValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
