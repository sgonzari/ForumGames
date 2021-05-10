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
    }
}
