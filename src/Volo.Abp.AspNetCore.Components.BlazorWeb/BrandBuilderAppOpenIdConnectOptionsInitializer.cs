using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

namespace BookStore.Blazor;

public class BookStoreOpenIdConnectOptionsInitializer : IConfigureNamedOptions<OpenIdConnectOptions>
{
    private readonly IDataProtectionProvider _dataProtectionProvider;
    private readonly BookStoreTenantProvider _tenantProvider;

    public BookStoreOpenIdConnectOptionsInitializer(
        IDataProtectionProvider dataProtectionProvider,
        BookStoreTenantProvider tenantProvider)
    {
        _dataProtectionProvider = dataProtectionProvider;
        _tenantProvider = tenantProvider;
    }

    public void Configure(string? name, OpenIdConnectOptions options)
    {
        if (!string.Equals(name, "oidc", StringComparison.Ordinal))
        {
            return;
        }
        
        var tenant = _tenantProvider.GetCurrentTenant();

        // Create a tenant-specific data protection provider to ensure
        // encrypted states can't be read/decrypted by the other tenants.
        options.DataProtectionProvider = _dataProtectionProvider.CreateProtector(tenant);
        options.Authority = options.Authority?.Replace("{0}.", tenant);
        options.MetadataAddress = options.MetadataAddress?.Replace("{0}.", tenant);

        // Other tenant-specific options like options.Authority can be registered here.
    }

    public void Configure(OpenIdConnectOptions options)
        => Debug.Fail("This infrastructure method shouldn't be called.");
}