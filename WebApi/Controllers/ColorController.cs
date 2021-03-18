using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepo _colorRepo;
        public ColorController(IColorRepo colorRepo)
        {
            _colorRepo = colorRepo;
        }

        [HttpGet]
        public IActionResult GetAllColors()
        {
            return Ok(_colorRepo.GetAll());
        }
    }
}
