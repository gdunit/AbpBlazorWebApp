using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;

namespace BookStore.Blazor;

public class BookStoreOpenIdConnectOptionsProvider : IOptionsMonitor<OpenIdConnectOptions>
{
    private readonly ConcurrentDictionary<(string name, string tenant), Lazy<OpenIdConnectOptions>> _cache;
    private readonly IOptionsFactory<OpenIdConnectOptions> _optionsFactory;
    private readonly BookStoreTenantProvider _tenantProvider;

    public BookStoreOpenIdConnectOptionsProvider(
        IOptionsFactory<OpenIdConnectOptions> optionsFactory,
        BookStoreTenantProvider tenantProvider)
    {
        _cache = new ConcurrentDictionary<(string, string), Lazy<OpenIdConnectOptions>>();
        _optionsFactory = optionsFactory;
        _tenantProvider = tenantProvider;
    }

    public OpenIdConnectOptions CurrentValue => Get(Options.DefaultName);

    public OpenIdConnectOptions Get(string? name)
    {
        var tenant = _tenantProvider.GetCurrentTenant();

        Lazy<OpenIdConnectOptions> Create() => new Lazy<OpenIdConnectOptions>(() => _optionsFactory.Create(name!));
        return _cache.GetOrAdd((name!, tenant), _ => Create()).Value;
    }

    public IDisposable? OnChange(Action<OpenIdConnectOptions, string> listener) => null;    
}