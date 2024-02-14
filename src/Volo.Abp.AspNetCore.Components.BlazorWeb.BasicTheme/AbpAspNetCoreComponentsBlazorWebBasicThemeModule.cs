using Volo.Abp.AspNetCore.Components.BlazorWeb.BasicTheme.Bundling;
using Volo.Abp.AspNetCore.Components.BlazorWeb.Theming;
using Volo.Abp.AspNetCore.Components.BlazorWeb.Theming.Bundling;
using Volo.Abp.AspNetCore.Components.Web.BasicTheme;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Components.BlazorWeb.BasicTheme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebBasicThemeModule),
    typeof(AbpAspNetCoreComponentsBlazorWebThemingModule)
    )]
public class AbpAspNetCoreComponentsBlazorWebBasicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new BasicThemeToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(BlazorBasicThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                        .AddContributors(typeof(BlazorBasicThemeStyleContributor));
                });

            options
                .ScriptBundles
                .Add(BlazorBasicThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                        .AddContributors(typeof(BlazorBasicThemeScriptContributor));
                });
        });
    }
}
