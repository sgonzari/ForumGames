using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        public IComentarioBL _comentarioBL { get; set; }

        public ComentarioController(IComentarioBL comentarioBL)
        {
            _comentarioBL = comentarioBL;
        }

        [HttpGet]
        [Route("getCommentIdGame")]
        public ActionResult<IEnumerable<JuegoDTO>> GetCommentFromId(int idGame)
        {
            return Ok(_comentarioBL.GetCommentFromId(idGame));
        }

        [HttpPost]
        public ActionResult<bool> Add(ComentarioDTO comentarioDTO)
        {
            _comentarioBL.Add(comentarioDTO);
            return Ok(true);
        }
    }
}
