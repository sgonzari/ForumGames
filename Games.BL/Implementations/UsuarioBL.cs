using System;
using Games.BL.Contracts;
using Games.CORE.DTO;

namespace Games.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public UsuarioBL() { }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.Username.Equals("sebas") && usuarioDTO.Password.Equals("holi"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
