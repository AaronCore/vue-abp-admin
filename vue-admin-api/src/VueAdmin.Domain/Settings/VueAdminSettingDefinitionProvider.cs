using Volo.Abp.Settings;

namespace VueAdmin.Settings
{
    public class VueAdminSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(VueAdminSettings.MySetting1));
        }
    }
}
