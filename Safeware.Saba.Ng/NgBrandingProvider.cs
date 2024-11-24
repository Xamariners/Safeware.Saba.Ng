using Microsoft.Extensions.Localization;
using Safeware.Saba.Ng.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Safeware.Saba.Ng;

[Dependency(ReplaceServices = true)]
public class NgBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<NgResource> _localizer;

    public NgBrandingProvider(IStringLocalizer<NgResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}