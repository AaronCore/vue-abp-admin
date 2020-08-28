using VueAdmin.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace VueAdmin.Permissions
{
    public class VueAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(VueAdminPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(VueAdminPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<VueAdminResource>(name);
        }
    }
}
