using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        bool Login(UsuarioDTO usuarioDTO);

        IEnumerable<UsuarioDTO> Get();

        void Add(UsuarioDTO usuarioDTO);

        void Remove(UsuarioDTO usuarioDTO);
    }
}
