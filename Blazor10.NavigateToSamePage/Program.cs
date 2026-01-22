using Blazor10.NavigateToSamePage.Components;

// Previously, NavigationManager.NavigateTo scrolled to the top of the page for same-page navigations.
// This behavior has been changed in .NET 10 so that the browser no longer scrolls to the top of the page
// when navigating to the same page. This means the viewport is no longer reset when making updates
// to the address for the current page, such as changing the query string or fragment.

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