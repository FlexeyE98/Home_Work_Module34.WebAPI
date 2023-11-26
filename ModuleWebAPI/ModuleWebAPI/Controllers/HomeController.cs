using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ModuleWebAPI.Configuration;
using System.Text;

namespace ModuleWebAPI.Controllers
{
    public class HomeController:ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("info")]
        public IActionResult Info() 
        {
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            return StatusCode(200, infoResponse);

        }

    }
}
