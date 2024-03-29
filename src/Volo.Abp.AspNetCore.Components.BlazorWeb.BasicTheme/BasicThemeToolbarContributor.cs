﻿using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.BlazorWeb.BasicTheme.Themes.Basic;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Volo.Abp.AspNetCore.Components.BlazorWeb.BasicTheme;

public class BasicThemeToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
        }

        return Task.CompletedTask;
    }
}
