using Volo.Abp.FeatureManagement.Blazor.Web;
using Volo.Abp.Modularity;

namespace Volo.Abp.TenantManagement.Blazor.Web;

[DependsOn(
    typeof(AbpTenantManagementBlazorModule),
    typeof(AbpFeatureManagementBlazorWebModule)
    )]
public class AbpTenantManagementBlazorWebModule : AbpModule
{

}
