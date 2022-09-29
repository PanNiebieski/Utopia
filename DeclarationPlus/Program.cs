using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDeclarationPlusFakeRepositoriesServices(builder.Configuration);
builder.Services.AddMapping();
builder.Services.AddScoringRulesFactory();
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

app.MapPost("/declaration/submitDeclaration", HandleSubmitDeclaration)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);

app.MapPost("/declaration/AcceptDeclaration", HandleAcceptDeclaration)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);


app.MapPost("/declaration/EvaluateDeclaration", HandleEvaluateDeclaration)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);

app.MapPost("/declaration/RejectDeclaration", HandleRejectDeclaration)
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);


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

async ValueTask<IResult> HandleSubmitDeclaration(
    [FromServices] CommandHandler<SubmitDeclarationCommand, SubmitDeclarationCommandResponse> commandH,
    SubmitDeclarationCommand command,
    CancellationToken ct
)
{
    var result = await commandH(command,ct);

    if (result.Success)
        return Results.Ok(result.Value);
    else
        return Results.BadRequest(result.MessageError);

}


async ValueTask<IResult> HandleRejectDeclaration(
    [FromServices] CommandHandler<RejectDeclarationCommand, RejectDeclarationCommandResponse> commandH,
    int declarationId,
    int administratorId,
    CancellationToken ct
)
{
    var result = await commandH(new RejectDeclarationCommand(declarationId, administratorId),ct);

    if (result.Success)
        return Results.NoContent();
    else
        return Results.BadRequest(result.Message);
}

async ValueTask<IResult> HandleEvaluateDeclaration(
    [FromServices] CommandHandler<EvaluateDeclarationCommand, EvaluateDeclarationCommandResponse> commandH,
    int declarationId,
CancellationToken ct
)
{
    var result = await commandH(new EvaluateDeclarationCommand(declarationId), ct);

    if (result.Success)
        return Results.NoContent();
    else
        return Results.BadRequest(result.Message);

}

async ValueTask<IResult> HandleAcceptDeclaration(
    [FromServices] CommandHandler<AcceptDeclarationCommand, AcceptDeclarationCommandResponse> commandH,
    int declarationId,
    int administratorId,
    CancellationToken ct
)
{
    var result = await commandH(new AcceptDeclarationCommand(declarationId, administratorId), ct);

    if (result.Success)
        return Results.NoContent();
    else
        return Results.BadRequest(result.Message);
}