using System;
using System.Collections.Generic;
using System.Text;
using VueAdmin.Localization;
using Volo.Abp.Application.Services;

namespace VueAdmin
{
    /* Inherit your application services from this class.
     */
    public abstract class VueAdminAppService : ApplicationService
    {
        protected VueAdminAppService()
        {
            LocalizationResource = typeof(VueAdminResource);
        }
    }
}
