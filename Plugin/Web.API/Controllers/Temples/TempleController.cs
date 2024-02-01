using CloudVOffice.Data.DTO.SanatanMandir.Temples;
using CloudVOffice.Services.SanatanMandir.Temples;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Temples
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TempleController : Controller
    {
        private readonly ITempleService _templeService;
        public TempleController(ITempleService templeService)
        {
            _templeService = templeService;
        }
        [HttpPost]
        public IActionResult TempleCreate(TempleDTO templeDTO)
        {
            try
            {
                var a = _templeService.TempleCreate(templeDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult TempleList()
        {
            var a = _templeService.GetTempleList();
            return Ok(a);
        }

        [HttpGet("{templeId}")]
        public IActionResult SingleTempleListbyId(int templeId)
        {
            var a = _templeService.GetTempleById(templeId);
            return Ok(a);
        }

        [HttpPost]
        public IActionResult UpdateTemple(TempleDTO templeDTO)
        {
            try
            {
                var a = _templeService.TempleUpdate(templeDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{templeId}/{DeletedBy}")]
        public ActionResult DeleteTemple(int templeId, int DeletedBy)
        {
            var a = _templeService.DeleteTemple(templeId, DeletedBy);
            return Ok(a);
        }

    }
}
