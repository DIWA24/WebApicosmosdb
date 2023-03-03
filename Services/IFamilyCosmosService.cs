using WebApicosmosdb.Models;

namespace WebApicosmosdb.Services
{
    public interface IFamilyCosmosService
    {
        Task<List<FamilyDetails>> Get(string sqlCosmosQuery);
        Task<FamilyDetails> Add(FamilyDetails newfamilyDetails);
        Task<FamilyDetails> Update(FamilyDetails ToUpdatefamilyDetails);
        Task Delete(string id, string Pincode);
    }
}
