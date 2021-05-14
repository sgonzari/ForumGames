using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.BL.Contracts
{
    public interface ICategoriaBL
    {
        IEnumerable<CategoriaDTO> Get();
    }
}
