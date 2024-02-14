using Volo.Abp.AspNetCore.Components.BlazorWeb.Theming;
using Volo.Abp.Modularity;

namespace Volo.Abp.PermissionManagement.Blazor.Web;

[DependsOn(
    typeof(AbpPermissionManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsBlazorWebThemingModule)
)]
public class AbpPermissionManagementBlazorWebModule : AbpModule
{
}
