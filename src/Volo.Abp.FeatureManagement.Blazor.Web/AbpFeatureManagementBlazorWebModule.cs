using Volo.Abp.AspNetCore.Components.BlazorWeb.Theming;
using Volo.Abp.Modularity;

namespace Volo.Abp.FeatureManagement.Blazor.Web;

[DependsOn(
    typeof(AbpFeatureManagementBlazorModule),
    typeof(AbpAspNetCoreComponentsBlazorWebThemingModule)
    )]
public class AbpFeatureManagementBlazorWebModule : AbpModule
{

}
