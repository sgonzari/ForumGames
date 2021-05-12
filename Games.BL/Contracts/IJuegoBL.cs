using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.BL.Contracts
{
    public interface IJuegoBL
    {
        // Interfaz para obtener lista de juegos
        IEnumerable<JuegoDTO> Get();

        // Interfaz para añadir juegos
        void Add(JuegoDTO juegoDTO);

        // Interfaz para eliminar juegos
        void Remove(JuegoDTO juegoDTO);
    }
}
