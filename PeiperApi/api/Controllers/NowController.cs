using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class NowController : Controller
    {
        [HttpGet]
        public BaseResponse<string> Now()
        {
            var value = "Värde från apiet";
            return new BaseResponse<string>(value);
        }

        [HttpGet("add/{a}/{b}")]
        public BaseResponse<int> Add(int a, int b)
        {
            var value = a + b;
            return new BaseResponse<int>(value);
        }
    }
}
