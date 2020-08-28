using VueAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VueAdmin.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class VueAdminController : AbpController
    {
        protected VueAdminController()
        {
            LocalizationResource = typeof(VueAdminResource);
        }
    }
}