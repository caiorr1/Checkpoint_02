using CP2.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();

// Configura o Swagger com comentários XML
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);  // Inclui a documentação XML, caso exista
});

Bootstrap.Start(builder.Services, builder.Configuration); // Chama o bootstrap para adicionar os serviços

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    // Ativa o Swagger e configura o Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1"); // Define o endpoint do Swagger
        c.RoutePrefix = string.Empty;  // Define o Swagger como a rota padrão
    });
}

app.UseHttpsRedirection();  // Garante que as requisições sejam redirecionadas para HTTPS

app.UseAuthorization();

app.MapControllers();  // Mapeia os controllers da API

app.Run();
