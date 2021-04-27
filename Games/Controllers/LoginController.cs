using System;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController
    {
        public IUsuarioBL _usuarioBL { get; set; }
        public LoginController(IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }

        [HttpPost]
        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _usuarioBL.Login(usuarioDTO);
        }
    }
}
