using System;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Games.DAL.Repositories.Contracts;

namespace Games.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioBL(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _usuarioRepository.Login(usuarioDTO);
        }
    }
}
