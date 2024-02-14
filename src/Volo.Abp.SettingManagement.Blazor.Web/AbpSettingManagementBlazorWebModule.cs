using Volo.Abp.AspNetCore.Components.BlazorWeb.Theming;
using Volo.Abp.Modularity;

namespace Volo.Abp.SettingManagement.Blazor.Web;

[DependsOn(
    typeof(AbpSettingManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsBlazorWebThemingModule)
)]
public class AbpSettingManagementBlazorWebModule : AbpModule
{
}
