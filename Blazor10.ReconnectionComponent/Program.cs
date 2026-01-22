using Blazor10.ReconnectionComponent.Components;

// The Blazor Web App project template now includes a ReconnectModal component,
// including collocated stylesheet and JavaScript files, for improved developer control
// over the reconnection UI when the client loses the WebSocket connection to the server.
// The component doesn't insert styles programmatically, ensuring compliance with
// stricter Content Security Policy (CSP) settings for the style-src policy.
// In prior releases, the default reconnection UI was created by the framework
// in a way that could cause CSP violations.
// Note that the default reconnection UI is still used as fallback when the app
// doesn't define the reconnection UI, such as by using the project template's
// ReconnectModal component or a similar custom component.

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