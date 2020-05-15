// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Management.Network.Models
{
    /// <summary> The list of RouteTables to advertise the routes to. </summary>
    public partial class PropagatedRouteTable
    {
        /// <summary> Initializes a new instance of PropagatedRouteTable. </summary>
        public PropagatedRouteTable()
        {
        }

        /// <summary> Initializes a new instance of PropagatedRouteTable. </summary>
        /// <param name="labels"> The list of labels. </param>
        /// <param name="ids"> The list of resource ids of all the RouteTables. </param>
        internal PropagatedRouteTable(IList<string> labels, IList<SubResource> ids)
        {
            Labels = labels;
            Ids = ids;
        }

        /// <summary> The list of labels. </summary>
        public IList<string> Labels { get; set; }
        /// <summary> The list of resource ids of all the RouteTables. </summary>
        public IList<SubResource> Ids { get; set; }
    }
}