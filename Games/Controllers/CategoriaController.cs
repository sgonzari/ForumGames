using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public ICategoriaBL _categoriaBL { get; set; }

        public CategoriaController(ICategoriaBL categoriaBL)
        {
            _categoriaBL = categoriaBL;
        }

        /*
         * Devuelve una lista con todas las categorías.
         */
        public ActionResult<IEnumerable<CategoriaDTO>> Get()
        {
            return Ok(_categoriaBL.Get());
        }
    }
}
