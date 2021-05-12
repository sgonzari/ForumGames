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

        /*
         * Obtiene una lista de juegos
         */
        public ActionResult<IEnumerable<JuegoDTO>> Get()
        {
            return Ok(_juegoBL.Get());
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
