using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Abstract.Repositories;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldRepository helloworldRepository;
        public HelloWorldController(IHelloWorldRepository _helloworldRepo)
        {
            this.helloworldRepository = _helloworldRepo;
        }
        [HttpGet("GetMessage")]
        public async Task<ActionResult<string>> GetHelloWorldResponse()
        {
            try
            {
                var response = await helloworldRepository.FetchMessage();
                var result = response.Message;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}