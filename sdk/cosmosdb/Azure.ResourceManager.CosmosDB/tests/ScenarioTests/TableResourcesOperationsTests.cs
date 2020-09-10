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
    //Message: The CosmosDB SDK does not support create the Table type accoun.Becaue need to manually create a Table type account.
    //TODO: When SDK support.
    public class TableResourcesOperationsTests: CosmosDBManagementClientBase
    {
        private string location;

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        private string resourceGroupName;
        private string databaseAccountName;
        private string tableName;
        private string tableName2;

        private string tableThroughputType = "Microsoft.DocumentDB/databaseAccounts/tables/throughputSettings";

        private int sampleThroughput = 700;

        private Dictionary<string, string> additionalProperties = new Dictionary<string, string>
        {
            {"foo","bar" }
        };
        private Dictionary<string, string> tags = new Dictionary<string, string>
        {
            {"key3","value3"},
            {"key4","value4"}
        };
        public TableResourcesOperationsTests(bool isAsync) : base(isAsync)
        {

        }
        private void GenerateRandomVariables()
        {
            location = "West US"; //CosmosDBTestUtilities.Location;
            resourceGroupName = "cosmosdbrg-test-8381"; //Create manually. Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
            databaseAccountName = "azuretable-test01"; //Create manually. Recording.GenerateAssetName("cosmosdb");
            tableName = Recording.GenerateAssetName("tableName");
            tableName2 = Recording.GenerateAssetName("tableName");
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
            // await CleanupResourceGroupsAsync();
            await Task.Delay(2000);
        }
        [Test]
        public async Task TableCRUDTests()
        {
            // Create client
            CosmosDBManagementClient cosmosDBManagementClient = GetCosmosDBManagementClient();

            int isDatabaseNameExists = (await cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName)).Status;

            if (isDatabaseNameExists != 200)
            {
                return;
            }

            TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
            (
                new TableResource(tableName),
                new CreateUpdateOptions()
            );

            TableGetResults tableGetResults = await WaitForCompletionAsync(await cosmosDBManagementClient.TableResources.StartCreateUpdateTableAsync(resourceGroupName, databaseAccountName, tableName, tableCreateUpdateParameters));
            Assert.NotNull(tableGetResults);
            Assert.AreEqual(tableName, tableGetResults.Name);

            TableGetResults tableGetResults2 = (await cosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName)).Value;
            Assert.NotNull(tableGetResults2);
            Assert.AreEqual(tableName, tableGetResults2.Name);

            VerifyEqualTables(tableGetResults, tableGetResults2);

            TableCreateUpdateParameters tableCreateUpdateParameters2 = new TableCreateUpdateParameters
            (
                id: default(string),
                name: default(string),
                type: default(string),
                location: location,
                tags: tags,
                resource: new TableResource(tableName2),
                options: new CreateUpdateOptions
                {
                    Throughput = sampleThroughput
                }
            );

            TableGetResults tableGetResults3 = await WaitForCompletionAsync(await cosmosDBManagementClient.TableResources.StartCreateUpdateTableAsync(resourceGroupName, databaseAccountName, tableName2, tableCreateUpdateParameters2));
            Assert.NotNull(tableGetResults3);
            Assert.AreEqual(tableName2, tableGetResults3.Name);

            IAsyncEnumerable<TableGetResults> tables = cosmosDBManagementClient.TableResources.ListTablesAsync(resourceGroupName, databaseAccountName);
            Assert.NotNull(tables);

            ThroughputSettingsGetResults throughputSettingsGetResults = (await cosmosDBManagementClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName2)).Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(throughputSettingsGetResults.Resource.Throughput, sampleThroughput);
            Assert.AreEqual(tableThroughputType, throughputSettingsGetResults.Type);

            await foreach (TableGetResults table in tables)
            {
                await cosmosDBManagementClient.TableResources.StartDeleteTableAsync(resourceGroupName, databaseAccountName, table.Name);
            }
        }
        private void VerifyEqualTables(TableGetResults expectedValue, TableGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }
    }
}
