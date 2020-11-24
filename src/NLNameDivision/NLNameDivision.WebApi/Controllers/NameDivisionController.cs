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
        public ActionResult<IEnumerable<string>> ReportParticleList()
        {
            return _nameDivisionService.ReportParticleList();
        }

        [HttpGet]
        [Route("SliceName/{nameToDivide}")]
        public ActionResult<NameSlicesDto> GetNameSliced(string nameToDivide)
        {
            return _nameDivisionService.GetNameSliced(nameToDivide);
        }

        [HttpGet]
        [Route("PartName/{nameToDivide}")]
        public ActionResult<NamePartsDto> GetNameParted(string nameToDivide)
        {
            return _nameDivisionService.GetNameParted(nameToDivide);
        }

        [HttpGet]
        [Route("DivisionName/{nameToDivide}")]
        public ActionResult<NamePartsDto> GetNameDivided(string nameToDivide)
        {
            return _nameDivisionService.GetNameDivided(nameToDivide);
        }

        [HttpGet]
        [Route("Structure/{nameToDivide}")]
        public ActionResult<NameStructuredDto> GetNameStructured(string nameToDivide)
        {
            return _nameDivisionService.GetNameStructured(nameToDivide);
        }

    }
}