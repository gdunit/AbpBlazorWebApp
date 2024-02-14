using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BookStore.Blazor;

public class BookStoreTenantProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BookStoreTenantProvider(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    public string GetCurrentTenant()
    {
        // This sample uses the path base as the tenant.
        // You can replace that by your own logic.
        var baseUrl = _httpContextAccessor.HttpContext?.Request.Host;
        // throw new Exception("FP!" + baseUrl.ToString());
        string? tenant = GetTenantName(baseUrl.ToString()!);

        if (string.IsNullOrEmpty(tenant))
        {
            tenant = "default";
        }

        return tenant;
    }
    
    private static readonly string[] ProtocolPrefixes = { "http://", "https://" };
    
    // This is a naive implementation which assumes [tenantdomain].[domain].[suffix]
    private static string? GetTenantName(string baseUrl)
    {
        if (baseUrl == null)
        {
            throw new ArgumentNullException(nameof(baseUrl));
        }

        var hostName = baseUrl.RemovePreFix(ProtocolPrefixes);
        var urlSplit = hostName.Split('.');
        // If the url has two (or even) splits ([domain].[suffix]) we assume the host.
        // If three (or odd), then we assume a tenant subomain is added and add the period also.
        return urlSplit.Length % 2 == 0 ? null : $"{urlSplit.FirstOrDefault()}.";
    } 
}