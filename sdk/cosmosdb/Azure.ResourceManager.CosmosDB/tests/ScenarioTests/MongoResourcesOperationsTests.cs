// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class MongoResourcesOperationsTests: CosmosDBManagementClientBase
    {
        private string location ;

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        private string resourceGroupName ;
        public MongoResourcesOperationsTests(bool isAsync) : base(isAsync)
        {

        }
        private void GenerateRandomVariables()
        {
            location = CosmosDBTestUtilities.Location;
            resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            GenerateRandomVariables();
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                //Creates or updates a resource group
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    location,
                    resourceGroupName);
            }
        }
        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }
        [Test]
        public async Task MongoCRUDTests()
        {
            await Task.Delay(2000);
        }
    }
}
