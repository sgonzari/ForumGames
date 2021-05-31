using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlataformaController : ControllerBase
    {
        public IPlataformaBL _plataformaBL { get; set; }

        public PlataformaController(IPlataformaBL plataformaBL)
        {
            _plataformaBL = plataformaBL;
        }

        /*
         * Devuelve una lista con todas las plataformas.
         */
        public ActionResult<IEnumerable<PlataformaDTO>> Get()
        {
            return Ok(_plataformaBL.Get());
        }
    }
}
