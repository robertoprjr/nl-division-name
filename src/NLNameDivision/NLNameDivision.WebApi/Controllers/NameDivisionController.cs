using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NLNameDivision.Cross.DTO;
using NLNameDivision.Service.Abstraction;

namespace NLNameDivision.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameDivisionController : ControllerBase
    {
        private readonly INameDivisionService _nameDivisionService;
        public NameDivisionController(INameDivisionService nameDivisionService)
        {
            _nameDivisionService = nameDivisionService;
        }
        
        [HttpGet]
        [Route("ParticleList")]
        public ActionResult<IEnumerable<string>> GetParticleList()
        {
            return _nameDivisionService.ReportParticleList();
        }

        [HttpGet]
        [Route("SliceName/{nameToDivide}")]
        public ActionResult<NameSlicesDto> SliceName(string nameToDivide)
        {
            return _nameDivisionService.ReportNameSliced(nameToDivide);
        }

    }
}