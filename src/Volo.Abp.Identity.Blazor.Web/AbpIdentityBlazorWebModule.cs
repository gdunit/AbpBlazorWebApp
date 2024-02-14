using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Blazor.Web;

namespace Volo.Abp.Identity.Blazor.Web;

[DependsOn(
    typeof(AbpIdentityBlazorModule),
    typeof(AbpPermissionManagementBlazorWebModule)
)]
public class AbpIdentityBlazorWebModule : AbpModule
{
}
