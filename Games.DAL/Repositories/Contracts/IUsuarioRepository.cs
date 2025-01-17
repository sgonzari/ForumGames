﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Games.CORE.DTO;

namespace Games.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        bool Login(UsuarioDTO usuarioDTO);

        Task<IEnumerable<UsuarioDTO>> Get();

        UsuarioDTO GetDataFromUsername(string username);

        void Add(UsuarioDTO usuarioDTO);

        void Remove(UsuarioDTO usuarioDTO);
    }
}
