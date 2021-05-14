using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.DAL.Repositories.Contracts
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaDTO> Get();
    }
}
