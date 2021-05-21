using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.BL.Contracts
{
    public interface IJuegoBL
    {
        IEnumerable<JuegoDTO> Get();

        IEnumerable<JuegoDTO> GetData(string title, string username);

        IEnumerable<JuegoDTO> GetDataFromTitle(string title);

        IEnumerable<JuegoDTO> getDataFromUsername(string username);

        void Add(JuegoDTO juegoDTO);

        void UpdateGame(JuegoDTO juegoDTO);

        void Remove(JuegoDTO juegoDTO);
    }
}
