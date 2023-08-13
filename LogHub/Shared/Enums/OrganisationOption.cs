namespace Shared.Enums;

public enum OrganisationOption
{
    [EnumInfo("Update Organisation Details", "Set permissions for updating the organisation details.")]
    UpdateDetails,

    [EnumInfo("View Sub-Organisations", "Set permissions for viewing the sub-organisations.")]
    ViewSubOrganisations,

    [EnumInfo("Add Sub-Organisations", "Set permissions for adding sub-organisations.")]
    AddSubOrganisations,

    [EnumInfo("Remove Sub-Organisations", "Set permissions for removing sub-organisations.")]
    RemoveSubOrganisations,

    [EnumInfo("Update Sub-Organisations", "Set permissions for updating sub-organisations.")]
    UpdateSubOrganisations,

    [EnumInfo("View Users", "Set permissions for viewing users.")]
    ViewUsers,

    [EnumInfo("Add Users", "Set permissions for adding users.")]
    AddUsers,

    [EnumInfo("Remove Users", "Set permissions for removing users.")]
    RemoveUsers,

    [EnumInfo("Update User Roles", "Set permissions for updating user roles.")]
    UpdateUserRoles,

    [EnumInfo("View Projects", "Set permissions for viewing projects.")]
    ViewProjects,

    [EnumInfo("Add Projects", "Set permissions for adding projects.")]
    AddProjects,

    [EnumInfo("Remove Projects", "Set permissions for removing projects.")]
    RemoveProjects,

    [EnumInfo("Update Project Roles", "Set permissions for updating project roles.")]
    UpdateProjectRoles,

    [EnumInfo("View Organisation Settings", "Set permissions for viewing the organisation settings.")]
    ViewOrganisationSettings,

    [EnumInfo("Update Organisation Settings", "Set permissions for updating the organisation settings.")]
    UpdateOrganisationSettings
}
