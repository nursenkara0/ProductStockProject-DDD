using Application;

using Application.Features.Commands.CategoryCommands.CreateCategory;
using Application.Features.Commands.CategoryCommands.DeleteCategory;
using Application.Features.Commands.CategoryCommands.UpdateCategory;
using Application.Features.Commands.ProductCommands.CreateProduct;
using Application.Features.Commands.ProductCommands.DeleteProduct;
using Application.Features.Commands.ProductCommands.UpdateProduct;
using Application.Features.Commands.UserCommands.CreateUser;
using Application.Features.Commands.UserCommands.DeleteUser;
using Application.Features.Commands.UserCommands.UpdateUser;
using Application.Features.Queries.CategoryQueries.GetByIdCategory;
using Application.Features.Queries.ProductQueries.GetByIdProduct;
using Application.Features.Queries.UserQueries.GetByIdUser;
using FluentValidation.AspNetCore;
using Infrastructure.Attributes;
using Infrastructure.Extensions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(configuration => configuration
                    .RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<DeleteProductCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<GetByIdProductQueryValidator>()
                    .RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<UpdateCategoryCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<DeleteCategoryCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<GetByIdCategoryQueryValidator>()
                    .RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<UpdateUserCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<DeleteUserCommandValidator>()
                    .RegisterValidatorsFromAssemblyContaining<GetByIdUserQueryValidator>())
                .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});
var app = builder.Build();

// app.Environment.IsDevelopment()
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); // wwwroot
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
app.Run();
