// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Management.Compute.Models;

namespace Azure.Management.Compute
{
    /// <summary> The Disks service client. </summary>
    public partial class DisksClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal DisksRestClient RestClient { get; }
        /// <summary> Initializes a new instance of DisksClient for mocking. </summary>
        protected DisksClient()
        {
        }
        /// <summary> Initializes a new instance of DisksClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal DisksClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null)
        {
            RestClient = new DisksRestClient(clientDiagnostics, pipeline, subscriptionId, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Gets information about a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Disk>> GetAsync(string resourceGroupName, string diskName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DisksClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(resourceGroupName, diskName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets information about a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Disk> Get(string resourceGroupName, string diskName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DisksClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(resourceGroupName, diskName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all the disks under a resource group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Disk> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            async Task<Page<Disk>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await RestClient.ListByResourceGroupAsync(resourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Disk>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await RestClient.ListByResourceGroupNextPageAsync(nextLink, resourceGroupName, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disks under a resource group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Disk> ListByResourceGroup(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }

            Page<Disk> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = RestClient.ListByResourceGroup(resourceGroupName, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Disk> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = RestClient.ListByResourceGroupNextPage(nextLink, resourceGroupName, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disks under a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Disk> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Disk>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Disk>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.List");
                scope.Start();
                try
                {
                    var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disks under a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Disk> List(CancellationToken cancellationToken = default)
        {
            Page<Disk> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.List");
                scope.Start();
                try
                {
                    var response = RestClient.List(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Disk> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DisksClient.List");
                scope.Start();
                try
                {
                    var response = RestClient.ListNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Creates or updates a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="disk"> Disk object supplied in the body of the Put disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<DisksCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string diskName, Disk disk, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (disk == null)
            {
                throw new ArgumentNullException(nameof(disk));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.CreateOrUpdateAsync(resourceGroupName, diskName, disk, cancellationToken).ConfigureAwait(false);
                return new DisksCreateOrUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateCreateOrUpdateRequest(resourceGroupName, diskName, disk).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="disk"> Disk object supplied in the body of the Put disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual DisksCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string diskName, Disk disk, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (disk == null)
            {
                throw new ArgumentNullException(nameof(disk));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.CreateOrUpdate(resourceGroupName, diskName, disk, cancellationToken);
                return new DisksCreateOrUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateCreateOrUpdateRequest(resourceGroupName, diskName, disk).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates (patches) a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="disk"> Disk object supplied in the body of the Patch disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<DisksUpdateOperation> StartUpdateAsync(string resourceGroupName, string diskName, DiskUpdate disk, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (disk == null)
            {
                throw new ArgumentNullException(nameof(disk));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartUpdate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.UpdateAsync(resourceGroupName, diskName, disk, cancellationToken).ConfigureAwait(false);
                return new DisksUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateUpdateRequest(resourceGroupName, diskName, disk).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates (patches) a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="disk"> Disk object supplied in the body of the Patch disk operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual DisksUpdateOperation StartUpdate(string resourceGroupName, string diskName, DiskUpdate disk, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (disk == null)
            {
                throw new ArgumentNullException(nameof(disk));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartUpdate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Update(resourceGroupName, diskName, disk, cancellationToken);
                return new DisksUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateUpdateRequest(resourceGroupName, diskName, disk).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<DisksDeleteOperation> StartDeleteAsync(string resourceGroupName, string diskName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsync(resourceGroupName, diskName, cancellationToken).ConfigureAwait(false);
                return new DisksDeleteOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteRequest(resourceGroupName, diskName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual DisksDeleteOperation StartDelete(string resourceGroupName, string diskName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete(resourceGroupName, diskName, cancellationToken);
                return new DisksDeleteOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteRequest(resourceGroupName, diskName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Grants access to a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="grantAccessData"> Access data object supplied in the body of the get disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<DisksGrantAccessOperation> StartGrantAccessAsync(string resourceGroupName, string diskName, GrantAccessData grantAccessData, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (grantAccessData == null)
            {
                throw new ArgumentNullException(nameof(grantAccessData));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartGrantAccess");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.GrantAccessAsync(resourceGroupName, diskName, grantAccessData, cancellationToken).ConfigureAwait(false);
                return new DisksGrantAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateGrantAccessRequest(resourceGroupName, diskName, grantAccessData).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Grants access to a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="grantAccessData"> Access data object supplied in the body of the get disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual DisksGrantAccessOperation StartGrantAccess(string resourceGroupName, string diskName, GrantAccessData grantAccessData, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (grantAccessData == null)
            {
                throw new ArgumentNullException(nameof(grantAccessData));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartGrantAccess");
            scope.Start();
            try
            {
                var originalResponse = RestClient.GrantAccess(resourceGroupName, diskName, grantAccessData, cancellationToken);
                return new DisksGrantAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateGrantAccessRequest(resourceGroupName, diskName, grantAccessData).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Revokes access to a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async ValueTask<DisksRevokeAccessOperation> StartRevokeAccessAsync(string resourceGroupName, string diskName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartRevokeAccess");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.RevokeAccessAsync(resourceGroupName, diskName, cancellationToken).ConfigureAwait(false);
                return new DisksRevokeAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateRevokeAccessRequest(resourceGroupName, diskName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Revokes access to a disk. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual DisksRevokeAccessOperation StartRevokeAccess(string resourceGroupName, string diskName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DisksClient.StartRevokeAccess");
            scope.Start();
            try
            {
                var originalResponse = RestClient.RevokeAccess(resourceGroupName, diskName, cancellationToken);
                return new DisksRevokeAccessOperation(_clientDiagnostics, _pipeline, RestClient.CreateRevokeAccessRequest(resourceGroupName, diskName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}