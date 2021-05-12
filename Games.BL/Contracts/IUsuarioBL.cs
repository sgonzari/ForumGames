using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.BL.Contracts
{
    public interface IUsuarioBL
    {
        // Interfaz para login
        bool Login(UsuarioDTO usuarioDTO);

        // Interfaz para obtener lista de usuarios
        IEnumerable<UsuarioDTO> Get();

        // Interfaz para añadir usuarios
        void Add(UsuarioDTO usuarioDTO);
    }
}
