var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDeclarationPlusFakeRepositoriesServices(builder.Configuration);
builder.Services.AddMapping();
builder.Services.AddQueries();
builder.Services.AddCommands();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/administrators/getallTerrioties", HandleAllTerrioties)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.MapGet("/territories/GetAllAdministrators", HandlAllAdministrators)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.MapGet("/declaration/getAllDeclarations", HandlAllDeclarations)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);


app.MapPost("/declaration/submitDeclaration", HandlAllDeclarations)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/declaration/AcceptDeclaration", HandlAllDeclarations)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/declaration/EvaluateDeclaration", HandlAllDeclarations)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/declaration/RejectDeclaration", HandlAllDeclarations)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound);

app.Run();



async ValueTask<IResult> HandleAllTerrioties(
    [FromServices] QueryHandler<GetAllTerriotiesQuery, GetAllTerriotiesQueryResponse> query,
    OrderByTerritoryOptions? filter,
    int? page,
    int? pageSize,
    CancellationToken ct
)
{
    Console.WriteLine("HandleAllTerrioties");
    var result = await query(GetAllTerriotiesQuery.With(filter, page, pageSize), ct);

    if (result.List == null || result.List.Count() == 0)
        return Results.BadRequest();

    return Results.Ok(result);
}


async ValueTask<IResult> HandlAllAdministrators(
    [FromServices] QueryHandler<GetAllAdministratorsQuery, GetAllAdministratorsQueryResponse> query,
    int? territoryid,
    CancellationToken ct
)
{
    Console.WriteLine("HandlAllAdministrators");
    var result = await query(new GetAllAdministratorsQuery(territoryid), ct);

    if (result.List == null || result.List.Count() == 0)
        return Results.BadRequest();

    return Results.Ok(result);
}

async ValueTask<IResult> HandlAllDeclarations(
    [FromServices] QueryHandler<GetAllDeclarationQuery, GetAllDeclarationQueryResponse> query,
    CancellationToken ct
)
{
    Console.WriteLine("HandlAllDeclarations");
    var result = await query(new GetAllDeclarationQuery(), ct);

    if (result.List == null)
        return Results.BadRequest();

    return Results.Ok(result);
}