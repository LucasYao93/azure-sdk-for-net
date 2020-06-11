// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <summary> Role Definitions filter. </summary>
    internal partial class RoleDefinitionFilter
    {
        /// <summary> Initializes a new instance of RoleDefinitionFilter. </summary>
        internal RoleDefinitionFilter()
        {
        }

        /// <summary> Initializes a new instance of RoleDefinitionFilter. </summary>
        /// <param name="roleName"> Returns role definition with the specific name. </param>
        internal RoleDefinitionFilter(string roleName)
        {
            RoleName = roleName;
        }

        /// <summary> Returns role definition with the specific name. </summary>
        public string RoleName { get; set; }
    }
}