using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Games.DAL.Repositories.Contracts;

namespace Games.BL.Implementations
{
    public class JuegoBL : IJuegoBL
    {
        public IJuegoRepository _juegoRepository { get; set; }

        public JuegoBL(IJuegoRepository juegoRepository)
        {
            _juegoRepository = juegoRepository;
        }

        public IEnumerable<JuegoDTO> Get()
        {
            var juegos = _juegoRepository.Get();
            return juegos;
        }
    }
}
