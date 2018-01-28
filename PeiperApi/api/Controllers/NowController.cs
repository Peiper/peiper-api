using Microsoft.AspNetCore.Mvc;
using PeiperApi.Domain.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class NowController : Controller
    {
        [HttpGet]
        public Response<string> Now()
        {
            var value = "Nytt värde från apiet";
            return new Response<string>(value);
        }
    }
}
