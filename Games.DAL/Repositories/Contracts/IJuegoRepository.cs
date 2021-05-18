using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.DAL.Repositories.Contracts
{
    public interface IJuegoRepository
    {
        IEnumerable<JuegoDTO> Get();

        IEnumerable<JuegoDTO> GetDataFromTitle(string title, string username);

        IEnumerable<JuegoDTO> GetDataFromTitle(string title);

        void Add(JuegoDTO juegoDTO);

        void Remove(JuegoDTO juegoDTO);
    }
}
