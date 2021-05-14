using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    public class PlataformaController : ControllerBase
    {
        public IPlataformaBL _plataformaBL { get; set; }

        public PlataformaController(IPlataformaBL plataformaBL)
        {
            _plataformaBL = plataformaBL;
        }

        public ActionResult<IEnumerable<PlataformaDTO>> Get()
        {
            return Ok(_plataformaBL.Get());
        }
    }
}
