using Microsoft.Azure.Cosmos.Table;

namespace Laba2CloudTechnologies;

public class AzureStorageManager
{
    private CloudTableClient tableClient;
    private CloudTable table;

    public AzureStorageManager(string storageConnectionString)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
        tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
        table = tableClient.GetTableReference("Contacts");
    }

    public async Task InitializeAsync()
    {
        await table.CreateIfNotExistsAsync();
    }

    public async Task InsertOrMergeEntityAsync(Contact entity)
    {
        TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
        await table.ExecuteAsync(insertOrMergeOperation);
    }
    public async Task DeleteEntityAsync(Contact entity)
    {
        TableOperation deleteOperation = TableOperation.Delete(entity);
        await table.ExecuteAsync(deleteOperation);
    }
    public List<Contact> GetAllContactsAsync()
    {
        return table.ExecuteQuery(new TableQuery<Contact>(), null).ToList();
    }

}