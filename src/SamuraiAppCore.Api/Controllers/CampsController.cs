using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamuraiAppCore.Interface;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SamuraiAppCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        private readonly CampRepository _repo;

        public CampsController(CampRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var camp = _repo.GetAllCamps();
            if (camp == null) return NotFound($"{camp} nnot found");
            return Ok(camp);
        }
    }
}
