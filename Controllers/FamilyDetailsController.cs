using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApicosmosdb.Models;
using WebApicosmosdb.Services;

namespace WebApicosmosdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyDetailsController : ControllerBase
    {
        private readonly IFamilyCosmosService _familyCosmosService;
        public FamilyDetailsController(IFamilyCosmosService familyCosmosService)
        {
            _familyCosmosService = familyCosmosService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlCosmosQuery = "Select * from c";
            var result = await _familyCosmosService.Get(sqlCosmosQuery);
            return Ok(result);
        }
        [HttpPost] 
        public async Task<IActionResult> Post(FamilyDetails newfamilyDetails)
        {
            if(newfamilyDetails.Id == null)
            {
                newfamilyDetails.Id=Guid.NewGuid().ToString();
            }
            var result=await _familyCosmosService.Add(newfamilyDetails);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(FamilyDetails ToUpdatefamilyDetails)
        {
            var result=await _familyCosmosService.Update(ToUpdatefamilyDetails);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, string Pincode)
        {
            await _familyCosmosService.Delete(id, Pincode);
            return Ok();
        }
    }
}
