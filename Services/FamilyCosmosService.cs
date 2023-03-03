using Microsoft.Azure.Cosmos;
using WebApicosmosdb.Models;

namespace WebApicosmosdb.Services
{
    public class FamilyCosmosService : IFamilyCosmosService
    {
        private readonly Container _container;
        public FamilyCosmosService(CosmosClient Client, string databseName, string containerName)
        {
            _container=Client.GetContainer(databseName, containerName);
        }

        public async Task<List<FamilyDetails>> Get(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<FamilyDetails>(new QueryDefinition(sqlCosmosQuery));
            List<FamilyDetails> result = new List<FamilyDetails>();
            while(query.HasMoreResults)
            {
                var response=await query.ReadNextAsync();
                result.AddRange(response);
            }
            return result;
        }

        public async Task<FamilyDetails> Add(FamilyDetails newfamilyDetails)
        {
            var item = await _container.CreateItemAsync(newfamilyDetails, new PartitionKey(newfamilyDetails.Pincode));
            return item;
        }

        public async Task<FamilyDetails> Update(FamilyDetails ToUpdatefamilyDetails)
        {
            var item=await _container.UpsertItemAsync(ToUpdatefamilyDetails,new PartitionKey(ToUpdatefamilyDetails.Pincode));
            return item;
        }

        public async Task Delete(string id, string Pincode)
        {
            var item=await _container.DeleteItemAsync<FamilyDetails>(id,new PartitionKey(Pincode));
        }
    }
}
