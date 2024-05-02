using BlazorWeb8WASM.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
static AuthorizationPolicy IsMemberPolicy()
{
    return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireClaim("Member Type", "Member").Build();
}

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddAuthorizationCore(x =>
{

    x.AddPolicy("IsMember", IsMemberPolicy());
});


await builder.Build().RunAsync();
