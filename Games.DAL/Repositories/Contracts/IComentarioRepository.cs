﻿using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.DAL.Repositories.Contracts
{
    public interface IComentarioRepository
    {
        IEnumerable<ComentarioDTO> GetCommentFromId(int idGame);
        void Add(ComentarioDTO comentarioDTO);
    }
}
