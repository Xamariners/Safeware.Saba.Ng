using Volo.Abp.Application.Services;
using Safeware.Saba.Ng.Localization;

namespace Safeware.Saba.Ng.Services;

/* Inherit your application services from this class. */
public abstract class NgAppService : ApplicationService
{
    protected NgAppService()
    {
        LocalizationResource = typeof(NgResource);
    }
}