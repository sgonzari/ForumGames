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

        /*
         * Devuelve una lista con todos los usuarios.
         */
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            return Ok(_usuarioBL.Get());
        }

        /*
         * Devuelve la información de un usuario.
         */
        [HttpGet]
        [Route("getData")]
        public ActionResult<UsuarioDTO> getDataFromUsername(string username)
        {
            return Ok(_usuarioBL.GetDataFromUsername(username));
        }

        /*
         * Devuelve un status 200 si se ha añadido un usuario correctamente.
         */
        [HttpPost]
        public ActionResult<bool> Add(UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Add(usuarioDTO);
            return Ok(true);
        }

        /*
         * Devuelve un status 200 si se ha eliminado un usuario correctamente.
         */
        [HttpDelete]
        public ActionResult<bool> Remove(UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Remove(usuarioDTO);
            return Ok(true);
        }
    }
}
