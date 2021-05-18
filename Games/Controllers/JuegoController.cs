using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuegoController : ControllerBase
    {
        public IJuegoBL _juegoBL { get; set; }

        public JuegoController(IJuegoBL juegoBL)
        {
            _juegoBL = juegoBL;
        }

        public ActionResult<IEnumerable<JuegoDTO>> Get()
        {
            return Ok(_juegoBL.Get());
        }

        [HttpGet]
        [Route("getData")]
        public ActionResult<IEnumerable<JuegoDTO>> getData(string title, string username)
        {
            return Ok(_juegoBL.GetData(title, username));
        }

        [HttpGet]
        [Route("getDataTitle")]
        public ActionResult<IEnumerable<JuegoDTO>> getDataFromTitle(string title)
        {
            return Ok(_juegoBL.GetDataFromTitle(title));
        }

        [HttpGet]
        [Route("getDataUsername")]
        public ActionResult<IEnumerable<JuegoDTO>> getDataFromUsername(string username)
        {
            return Ok(_juegoBL.getDataFromUsername(username));
        }

        [HttpPost]
        public ActionResult<bool> Add(JuegoDTO juegoDTO)
        {
            _juegoBL.Add(juegoDTO);
            return Ok(true);
        }

        [HttpDelete]
        public ActionResult<bool> Remove(JuegoDTO juegoDTO)
        {
            _juegoBL.Remove(juegoDTO);
            return Ok(true);
        }
    }
}
