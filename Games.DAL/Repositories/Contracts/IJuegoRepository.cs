using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.DAL.Repositories.Contracts
{
    public interface IJuegoRepository
    {
        IEnumerable<JuegoDTO> Get();

        void Add(JuegoDTO juegoDTO);

        void Remove(JuegoDTO juegoDTO);
    }
}
