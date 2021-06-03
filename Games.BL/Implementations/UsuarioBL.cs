using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            var usuarios = await _usuarioRepository.Get();
            return usuarios;
        }

        public UsuarioDTO GetDataFromUsername(string username)
        {
            var usuario = _usuarioRepository.GetDataFromUsername(username);
            return usuario;
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Add(usuarioDTO);
        }

        public void Remove(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Remove(usuarioDTO);
        }
    }
}
