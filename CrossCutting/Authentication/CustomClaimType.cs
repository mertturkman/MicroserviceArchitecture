using System;

namespace CrossCutting.Authentication
{
    public class CustomClaimType
    {
        public const string Role = "Role";
        public const string Permission = "Permission";

        //User Permissions
        public const string Permission_UserGetAll = "UserGetAll";
        public const string Permission_UserFindById = "UserFindById";
        public const string Permission_UserCreate = "UserCreate";
        public const string Permission_UserUpdate = "UserUpdate";
        public const string Permission_UserDelete = "UserDelete";
        public const string Permission_AddRoleToUser = "AddRoleToUser";
        public const string Permission_DeleteRoleFromUser = "DeleteRoleFromUser";
        public const string Permission_ChangePassword = "ChangePassword";

        //Role Permissions
        public const string Permission_RoleGetAll = "RoleGetAll";
        public const string Permission_RoleFindById = "RoleFindById";
        public const string Permission_RoleCreate = "RoleCreate";
        public const string Permission_RoleUpdate = "RoleUpdate";
        public const string Permission_RoleDelete = "RoleDelete";
        public const string Permission_AddPermissionToRole = "AddPermissionToRole";
        public const string Permission_DeletePermissionFromRole = "DeletePermissionFromRole";

        //Permission permissions
        public const string Permission_PermissionGetAll = "PermissionGetAll";
        public const string Permission_PermissionFindById = "PermissionFindById";
        public const string Permission_PermissionCreate = "PermissionCreate";
        public const string Permission_PermissionUpdate = "PermissionUpdate";
        public const string Permission_PermissionDelete = "PermissionDelete";
    }
}
