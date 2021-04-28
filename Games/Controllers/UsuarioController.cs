using System;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController
    {
        public IUsuarioBL _usuarioBL { get; set; }
        public UsuarioController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }

        [HttpPost]
        public void Add(UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Add(usuarioDTO);
        }
    }
}
