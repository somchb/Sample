public static class ContactApiExtensions
{
    public static IServiceCollection UseContactApi(
        this IServiceCollection services
    )
    {
        services.AddTransient<ContactRepository>();
        return services;
    }
    public static WebApplication MapContactsApi(this WebApplication app)
    {
        app.MapGet("/contacts", (ContactRepository repo) =>
        {
            return Results.Ok(repo.Get());
        });

        app.MapGet("/contact/{id:int}", (int id, ContactRepository repo) =>
        {
            Contact? value = repo.GetById(id);
            if(value == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(value);
        });

        // app.Map comment first

        return app;
    }
}
