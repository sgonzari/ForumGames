﻿using System;
using Games.CORE.DTO;


namespace Games.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        bool Login(UsuarioDTO usuarioDTO);
        void Add(UsuarioDTO usuarioDTO);
    }
}
