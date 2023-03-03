using Newtonsoft.Json;
namespace WebApicosmosdb.Models
{
    public class FamilyDetails
    {
        [JsonProperty("id")]
        public string Id { get;set; }
        [JsonProperty("firstname")]
        public string FirstName { get;set; }
        [JsonProperty("lastname")]
        public string LastName { get;set; }
        [JsonProperty("gender")]
        public string Gender { get;set;}
        [JsonProperty("Pincode")]
        public string Pincode { get;set; }
    }
}
