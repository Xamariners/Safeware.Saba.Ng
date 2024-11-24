using Safeware.Saba.Ng.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Safeware.Saba.Ng.Permissions;

public class NgPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NgPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(NgPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(NgPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(NgPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(NgPermissions.Books.Delete, L("Permission:Books.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(NgPermissions.MyPermission1, L("Permission:MyPermission1"));

        var masterEntityPermission = myGroup.AddPermission(NgPermissions.MasterEntities.Default, L("Permission:MasterEntities"));
        masterEntityPermission.AddChild(NgPermissions.MasterEntities.Create, L("Permission:Create"));
        masterEntityPermission.AddChild(NgPermissions.MasterEntities.Edit, L("Permission:Edit"));
        masterEntityPermission.AddChild(NgPermissions.MasterEntities.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NgResource>(name);
    }
}