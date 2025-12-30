namespace PharmaBlockchainBackend.Api.Features.DataValidation.Validate
{
    public static class Endpoint
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/dataValidation/validate", async (
                Request request,
                Handler handler,
                CancellationToken ct) =>
            {
                try
                {
                    var response = await handler.Handle(request, ct);
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
            .Produces<Response>(StatusCodes.Status200OK)
            .Produces<string>(StatusCodes.Status400BadRequest);
        }
    }
}
