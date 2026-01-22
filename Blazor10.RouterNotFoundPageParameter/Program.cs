using Blazor10.RouterNotFoundPageParameter.Components;

// Blazor now provides an improved way to display a "Not Found" page
// when navigating to a non-existent page. You can specify a page
// to render when NavigationManager.NotFound (described in the next section)
// is invoked by passing a page type to the Router component using the NotFoundPage parameter.
// The feature supports routing, works across code Status Code Pages Re-execution Middleware,
// and is compatible even with non-Blazor scenarios.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();