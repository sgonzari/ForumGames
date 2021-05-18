using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioBL _usuarioBL { get; set; }
            
        public UsuarioController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }

        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            return Ok(_usuarioBL.Get());
        }

        [HttpGet]
        [Route("getData")]
        public ActionResult<UsuarioDTO> getDataFromUsername(string username)
        {
            return Ok(_usuarioBL.GetDataFromUsername(username));
        }

        [HttpPost]
        public ActionResult<bool> Add(UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Add(usuarioDTO);
            return Ok(true);
        }

        [HttpDelete]
        public ActionResult<bool> Remove(UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Remove(usuarioDTO);
            return Ok(true);
        }
    }
}
